// ***********************************************************************
// Assembly         : DDocument
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="RepositoryHandler.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Web;
using System.Web.SessionState;
using AraneaUtilities.Auth.Roles;
using BusinessObject;
using BusinessObject.Classes;

public sealed class RepositoryHandler : IHttpHandler, IRequiresSessionState
{
    private string ADMIN = DFleetGlobals.UserRoles.Admin;
    private const string AuthSubpath = "repository/";
#pragma warning disable IDE0052 // Remove unread private members
    private string testFolder;
#pragma warning restore IDE0052 // Remove unread private members
    private string authPath;
    private string url;
    
    private string pathRequestedFile;


    public RepositoryHandler()
    {
    } 
       
    bool IHttpHandler.IsReusable
    {
        get { return true; }
    }
    void IHttpHandler.ProcessRequest(HttpContext context)
    {
        // url della richiesta
        url = context.Request.Url.ToString().ToLower(CultureInfo.CurrentCulture);
        // se c'e ".aspx" lo elimino        
        //url = url.Substring(0, url.IndexOf(".aspx"));
        url = url.Replace(".aspx", "");
        // path autorizzato in cui cercare file
        authPath = AuthPath(context);
        // cartella da valutare
        testFolder = TestFolder(context, authPath);
        //  nome del file richiesto
        // percorso fisico del file + file
        pathRequestedFile = PathRequestedFile();
        

        switch (context.Request.HttpMethod)
        {
            case "GET":
                if (context.Request.Url != null)
                {
                    // IF sono admin: concedo il file richiesto
                    if (context.User.IsInRole(ADMIN))
                        if (IsAuthFolder())
                            SendContentTypeAndFile(context, pathRequestedFile);
                        else
                            HttpContext.Current.Response.Redirect("../../../UnauthorizedAccess.html");


                    // ELSE: analizzo cosa mi è stato chiesto
                    else
                    {
                        // IF NON ha come inizio un percorso autorizzabile: RIFIUTO
                        if (!url.StartsWith(authPath, StringComparison.CurrentCulture))
                            throw new UnauthorizedAccessException();

                        // ELSE: valuto se l'utente è autorizzato
                        else
                        {
                            // valuto l'autorizzazione alla cartella
                            if (IsAuthFolder())
                            {
                                SendContentTypeAndFile(context, pathRequestedFile);
                            }
                            else
                            {
                                if (IsAuthFolder())
                                {
                                    SendContentTypeAndFile(context, pathRequestedFile);
                                }
                                else
                                {
                                    HttpContext.Current.Response.Redirect("../../../UnauthorizedAccess.html");
                                }
                            }
                        }
                    }
                }
                break;
            case "POST":
                throw new UnauthorizedAccessException();

            default:
                // do the default action
                break;
        }
    }

    private string AuthPath(HttpContext context)
    {
        return (context.Session["DomainName"].ToString() + AuthSubpath).ToLower(CultureInfo.CurrentCulture);
    }

    private string TestFolder(HttpContext context, string authPath)
    {
        String folder = context.Request.Url.ToString().Remove(0, authPath.Length);
        String[] folders = folder.Split('/');
        return folders[0].ToLower(CultureInfo.CurrentCulture);
    }

    private string PathRequestedFile()
    {
        int i = url.IndexOf(AuthSubpath, StringComparison.CurrentCulture);
        string path;
        if (i >= 0)
            path = url.Remove(0, i);
        else
            throw new UnauthorizedAccessException();
        return path;
    }

   

    private bool IsAuthFolder()
    {
        return true;
    }

    private string GetContentType(string filename)
    {
        return MimeMapping.GetMimeMapping(filename);
    }

    HttpContext SendContentTypeAndFile(HttpContext context, String strFile)
    {
        if (String.IsNullOrEmpty(strFile))
        {
            return null;
        }
        else
        {
            context.Response.ContentType = GetContentType(pathRequestedFile);
            context.Response.TransmitFile("~/" + pathRequestedFile);
            context.Response.End();
            return context;
        }
    }
   
}

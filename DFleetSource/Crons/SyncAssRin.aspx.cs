// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="SyncAssRin.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text.RegularExpressions;
using System.Web;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;

namespace DFleet.Crons
{
    public partial class SyncAssRin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = RequestExtensions.GetPathPhisicalApplication() + "/Repository";

            string[] myDirs = Directory.GetDirectories(path);

            foreach (var myDir in myDirs)
            {
                DirectoryInfo di = new DirectoryInfo(myDir);
                string nomedirectory = di.Name;

                if (nomedirectory.ToUpper() == "ASSICURAZIONI")
                {
                    FileInfo[] files = di.GetFiles("*.*");

                    foreach (FileInfo file in files)
                    {

                        string containerName = "contratti";
                        string blobName = file.Name;
                        string fileName = file.Name;
                        string fileSourcePath = myDir + "/";
                        string fileTargetPath = myDir + "/";
                        string sas = Global.sas;

                        AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                        string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                        Response.Write(resultBlob + "<br />");


                        //salva file assicurazione
                        string[] arraypt = file.Name.Split('_');
                        string targa = arraypt[0];

                        IContrattiBL servizioContratti = new ContrattiBL();

                        IContratti contrattoNew = new Contratti
                        {
                            Tipofile = SeoHelper.EncodeString("Tagliando Assicurativo"),
                            Anno = 2022,
                            Targa = targa,
                            Nomefile = file.Name
                        };
                        servizioContratti.InsertDocAuto(contrattoNew);

                    }
                }

            }
        }
    }
}

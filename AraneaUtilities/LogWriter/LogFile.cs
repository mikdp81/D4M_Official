// ***********************************************************************
// Assembly         : AraneaUtilities
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="LogFile.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace AraneaUtilities.LogWriter
{
    public static class LogFile
    {
        public static void Write(string[] lines, string suffix)
        {

            // These examples assume a "C:\Users\Public\TestFolder" folder on your machine.
            // You can modify the path if necessary.

            // Example #1: Write an array of strings to a file.
            // Create a string array that consists of three lines.
            string filename = "DFleetLOG"  + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + "-" + suffix;

            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\" + filename +".txt", lines);

        
        }
    }
}



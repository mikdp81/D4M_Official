// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="PageInfo.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Classes
{
    public class PageInfo
    {
        public string FolderName {get;}
        public string PageName { get; }
        public bool ReadOnly { get; }

        public PageInfo(string folderName, string pageName, bool readOnly)
        {
            FolderName = folderName;
            PageName = pageName;
            ReadOnly = readOnly;
        }
    }
}

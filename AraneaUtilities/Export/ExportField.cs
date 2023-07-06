// ***********************************************************************
// Assembly         : AraneaUtilities
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ExportField.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace AraneaUtilities.Export
{
    public class ExportField
    {
        public string Label { get;}
        public string Table { get; }
        public string Field { get; }
        public string Where { get; }
        public string ValoreFisso { get; }
        public bool IsFisso { get; }

        //** creo un field legato a un campo sul DB (non ha valoreFisso)
        public ExportField(string label, string table, string field, string where)
        {
            this.Label = label;
            this.Table = table;
            this.Field = field;
            this.Where = where;

            this.IsFisso = false;
        }

        //** creo un field con valore fisso (extra DB)
        public ExportField(string label, string valoreFisso)
        {
            this.Label = label;
            this.ValoreFisso = valoreFisso;

            this.IsFisso = true;
        }
    }
}

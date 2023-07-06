// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Car.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace BusinessObject
{
    [Serializable]
   
    public class Cars : ICars
    {
        public static string _stringEmpty = string.Empty;

        //********************************************  parametri generici

        public Guid Uid { get; set; }
        public Guid Uidsocieta { get; set; }
        public Guid UserIDIns { get; set; }
        public Guid UserIdMod { get; set; }
        public DateTime Datauserins { get; set; }
        public DateTime Datausermod { get; set; }
        public Guid Uidtenant { get; set; }

        //********************************************  parametri EF_carlistauto

        public int Idcarlistauto { get; set; }
        public decimal Consumo { get; set; }
        public decimal Consumourbano{ get; set; }
        public decimal Consumoextraurbano{ get; set; }
        public decimal Emissioni { get; set; }
        public decimal Costoautobase { get; set; }
        public decimal Costoaci { get; set; }
        public decimal Canoneleasing { get; set; }
        public decimal Fringebenefitbase { get; set; }
        public int Giorniconsegna { get; set; }
        public int Mesicontratto { get; set; }
        public decimal Serbatoio { get; set; }
        public int Checkoptionalpag { get; set; }

        private string _codcarlist = _stringEmpty;
        private string _codfornitore = _stringEmpty;
        private string _codjatoauto = _stringEmpty;
        private string _marca = _stringEmpty;
        private string _modello = _stringEmpty;
        private string _cilindrata = _stringEmpty;
        private string _alimentazione = _stringEmpty;
        private string _alimentazionesecondaria = _stringEmpty;
        private string _fotoauto = _stringEmpty;
        private string _cambio = _stringEmpty;
        private string _note = _stringEmpty;
        private string _excodcarpolicy = _stringEmpty;
        private string _visibile = _stringEmpty;
        private string _ordinecorrente = _stringEmpty;
        private string _kwcv = _stringEmpty;

        public string Codcarlist { get { return _codcarlist; } set { _codcarlist = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codfornitore { get { return _codfornitore; } set { _codfornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codjatoauto { get { return _codjatoauto; } set { _codjatoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Marca { get { return _marca; } set { _marca = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Modello { get { return _modello; } set { _modello = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cilindrata { get { return _cilindrata; } set { _cilindrata = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Alimentazione { get { return _alimentazione; } set { _alimentazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Alimentazionesecondaria { get { return _alimentazionesecondaria; } set { _alimentazionesecondaria = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fotoauto { get { return _fotoauto; } set { _fotoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cambio { get { return _cambio; } set { _cambio = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Note { get { return _note; } set { _note = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Excodcarpolicy { get { return _excodcarpolicy; } set { _excodcarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Visibile { get { return _visibile; } set { _visibile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ordinecorrente { get { return _ordinecorrente; } set { _ordinecorrente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Kwcv { get { return _kwcv; } set { _kwcv = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_carlist

        private string _carlist = _stringEmpty;

        public string Carlist { get { return _carlist; } set { _carlist = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_carpolicy

        public DateTime Validodal { get; set; }
        public DateTime Validoal { get; set; }

        private string _codcarpolicy = _stringEmpty;
        private string _codfuelcard = _stringEmpty;
        private string _codsocieta = _stringEmpty;
        private string _codpersontype = _stringEmpty;
        private string _codgrade = _stringEmpty;
        private string _codsubgrade = _stringEmpty;
        private string _grade = _stringEmpty;
        private string _societa = _stringEmpty;

        public string Codcarpolicy { get { return _codcarpolicy; } set { _codcarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codfuelcard { get { return _codfuelcard; } set { _codfuelcard = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codsocieta { get { return _codsocieta; } set { _codsocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codpersontype { get { return _codpersontype; } set { _codpersontype = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codgrade { get { return _codgrade; } set { _codgrade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codsubgrade { get { return _codsubgrade; } set { _codsubgrade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Grade { get { return _grade; } set { _grade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Societa { get { return _societa; } set { _societa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_carlist_optional_categorie

        public int Livello { get; set; }
        public int Ordine { get; set; }

        private string _codcategoriaoptional = _stringEmpty;
        private string _categoriaoptional = _stringEmpty;
        private string _codpadrecategoria = _stringEmpty;

        public string Codcategoriaoptional { get { return _codcategoriaoptional; } set { _codcategoriaoptional = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Categoriaoptional { get { return _categoriaoptional; } set { _categoriaoptional = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codpadrecategoria { get { return _codpadrecategoria; } set { _codpadrecategoria = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_carlist_optional

        public decimal Importooptional { get; set; }
        public int Giorniconsegnaagg { get; set; }

        private string _codoptional = _stringEmpty;
        private string _codsottocategoriaoptional = _stringEmpty;
        private string _optional = _stringEmpty;
        private string _sottocategoriaoptional = _stringEmpty;
        private string _optcolore = _stringEmpty;

        public string Codoptional { get { return _codoptional; } set { _codoptional = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codsottocategoriaoptional { get { return _codsottocategoriaoptional; } set { _codsottocategoriaoptional = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Optional { get { return _optional; } set { _optional = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Sottocategoriaoptional { get { return _sottocategoriaoptional; } set { _sottocategoriaoptional = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Optcolore { get { return _optcolore; } set { _optcolore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri view_report_dimissionari

        public DateTime Dataassunzione { get; set; }
        public DateTime Dataprevistadimissione { get; set; }
        public DateTime Datadimissioni { get; set; }
        public DateTime Datadocpolicy { get; set; }
        public DateTime Dataordine { get; set; }
        public DateTime Datainiziocontratto { get; set; }
        public DateTime Datainiziouso { get; set; }
        public DateTime Datafinecontratto { get; set; }
        public int Totparcoauto { get; set; }

        public decimal Importoforfettario { get; set; }
        public decimal Penaleordine { get; set; }
        public decimal Penaleritiro { get; set; }
        public decimal Canoneoptional { get; set; }
        public int Mesiresidui { get; set; }
        public decimal Residuooptional { get; set; }
        public int Multe { get; set; }
        public decimal Fuel { get; set; }
        public decimal Rimborsoconcur { get; set; }
        public decimal Speseamministrative { get; set; }

        private string _cognome = _stringEmpty;
        private string _nome = _stringEmpty;
        private string _matricola = _stringEmpty;
        private string _siglasocieta = _stringEmpty;
        private string _targa = _stringEmpty;
        private string _fornitore = _stringEmpty;
        private string _Ordinestatus = _stringEmpty;
        private string _Erratasederestituzione = _stringEmpty;
        private string __Erratarestituzionegomme = _stringEmpty;
        private string _Penaledenuncia = _stringEmpty;

        public string Cognome { get { return _cognome; } set { _cognome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nome { get { return _nome; } set { _nome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Matricola { get { return _matricola; } set { _matricola = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Siglasocieta { get { return _siglasocieta; } set { _siglasocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Targa { get { return _targa; } set { _targa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fornitore { get { return _fornitore; } set { _fornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ordinestatus { get { return _Ordinestatus; } set { _Ordinestatus = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Erratasederestituzione { get { return _Erratasederestituzione; } set { _Erratasederestituzione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Erratarestituzionegomme { get { return __Erratarestituzionegomme; } set { __Erratarestituzionegomme = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Penaledenuncia { get { return _Penaledenuncia; } set { _Penaledenuncia = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

    }
}

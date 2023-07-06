// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ICar.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface ICars

    {
        //********************************************  parametri generici

        Guid Uid { get; set; }
        Guid Uidsocieta { get; set; }
        Guid UserIDIns { get; set; }
        Guid UserIdMod { get; set; }
        DateTime Datauserins { get; set; }
        DateTime Datausermod { get; set; }
        Guid Uidtenant { get; set; }

        //********************************************  parametri EF_carlist_auto

        int Idcarlistauto { get; set; }
        decimal Consumo { get; set; }
        decimal Consumourbano { get; set; }
        decimal Consumoextraurbano { get; set; }
        decimal Emissioni { get; set; }
        decimal Costoautobase { get; set; }
        decimal Costoaci { get; set; }
        string Codcarlist { get; set; }
        string Codfornitore { get; set; }
        string Codjatoauto { get; set; }
        string Marca { get; set; }
        string Modello { get; set; }
        string Cilindrata { get; set; }
        string Alimentazione { get; set; }
        string Alimentazionesecondaria { get; set; }
        decimal Canoneleasing { get; set; }
        decimal Fringebenefitbase { get; set; }
        string Fotoauto { get; set; }
        string Cambio { get; set; }
        int Giorniconsegna { get; set; }
        int Mesicontratto { get; set; }
        string Note { get; set; }
        decimal Serbatoio { get; set; }
        string Excodcarpolicy { get; set; }
        int Checkoptionalpag { get; set; }
        string Visibile { get; set; }
        string Ordinecorrente { get; set; }
        string Kwcv { get; set; }

        //********************************************  parametri EF_carlist

        string Carlist { get; set; }

        //********************************************  parametri EF_carpolicy

        string Codcarpolicy { get; set; }
        string Codfuelcard { get; set; }
        string Codsocieta { get; set; }
        string Codpersontype { get; set; }
        string Codgrade { get; set; }
        string Codsubgrade { get; set; }
        string Grade { get; set; }
        string Societa { get; set; }
        DateTime Validodal { get; set; }
        DateTime Validoal { get; set; }

        //********************************************  parametri EF_carlist_optional_categorie

        string Codcategoriaoptional { get; set; }
        string Categoriaoptional { get; set; }
        int Livello { get; set; }
        int Ordine { get; set; }
        string Codpadrecategoria { get; set; }

        //********************************************  parametri EF_carlist_optional

        string Codoptional { get; set; }
        string Codsottocategoriaoptional { get; set; }
        string Optional { get; set; }
        string Sottocategoriaoptional { get; set; }
        decimal Importooptional { get; set; }
        string Optcolore { get; set; }
        int Giorniconsegnaagg { get; set; }

        //********************************************  parametri view_report_dimissionari

        string Cognome { get; set; }
        string Nome { get; set; }
        string Matricola { get; set; }
        string Siglasocieta { get; set; }
        DateTime Dataassunzione { get; set; }
        DateTime Dataprevistadimissione { get; set; }
        DateTime Datadimissioni { get; set; }
        DateTime Datadocpolicy { get; set; }
        DateTime Dataordine { get; set; }
        string Targa { get; set; }
        string Fornitore { get; set; }
        DateTime Datainiziocontratto { get; set; }
        DateTime Datainiziouso { get; set; }
        DateTime Datafinecontratto { get; set; }
        int Totparcoauto { get; set; }
        decimal Importoforfettario { get; set; }
        decimal Penaleordine { get; set; }
        decimal Penaleritiro { get; set; }
        decimal Canoneoptional { get; set; }
        int Mesiresidui { get; set; }
        decimal Residuooptional { get; set; }
        int Multe { get; set; }
        decimal Fuel { get; set; }
        decimal Rimborsoconcur { get; set; }
        decimal Speseamministrative { get; set; }
        string Ordinestatus { get; set; }
        string Erratasederestituzione { get; set; }
        string Erratarestituzionegomme { get; set; }
        string Penaledenuncia { get; set; }
    }
}
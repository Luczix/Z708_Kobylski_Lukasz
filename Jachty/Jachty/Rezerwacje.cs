//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jachty
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezerwacje
    {
        public int id_rezerwacji { get; set; }
        public Nullable<int> id_klienta { get; set; }
        public Nullable<int> id_jachtu { get; set; }
        public Nullable<System.DateTime> Data_Poczatek { get; set; }
        public Nullable<System.DateTime> Data_Koniec { get; set; }
        public Nullable<int> Cena_Total { get; set; }
        public Nullable<int> Cena_Zaliczka { get; set; }
    
        public virtual Dane_Klientow Dane_Klientow { get; set; }
        public virtual Jachty Jachty { get; set; }
    }
}

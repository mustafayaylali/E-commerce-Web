//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelefonAksesuar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yorumlar
    {
        public int YorumNo { get; set; }
        public int UrunID { get; set; }
        public string KullaniciAdi { get; set; }
        public string YorumTarih { get; set; }
        public string Yorum { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}
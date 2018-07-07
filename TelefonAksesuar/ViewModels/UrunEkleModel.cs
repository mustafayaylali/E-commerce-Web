using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonAksesuar.ViewModels
{
    public class UrunEkleModel
    {
        public int UrunID { get; set; }

        [Required(ErrorMessage = "*Boş bırakmayınız")]
        public string Kategori { get; set; }

        [Required(ErrorMessage = "*Boş bırakmayınız")]
        public string Marka { get; set; }

        [Required(ErrorMessage = "*Boş bırakmayınız")]
        public string Model { get; set; }

        [Required(ErrorMessage = "*Boş bırakmayınız")]
        public string Fiyat { get; set; }

        [Required(ErrorMessage = "*Boş bırakmayınız")]
        public string Stok { get; set; }

        public HttpPostedFileBase Resim { get; set; }

        public string AdmineMesaj { get; set; }
    }
}
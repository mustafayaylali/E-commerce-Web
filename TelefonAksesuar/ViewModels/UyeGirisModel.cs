using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonAksesuar.ViewModels
{
    public class UyeGirisModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz",AllowEmptyStrings=false)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.",AllowEmptyStrings =false)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        public bool Hatirla { get; set; }

        public string KullaniciyaMesaj { get; set; }
    }
}
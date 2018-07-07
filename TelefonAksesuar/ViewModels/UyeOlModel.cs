using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonAksesuar.ViewModels
{
    public class UyeOlModel
    {
        [Required(ErrorMessage = "*Lütfen adınızı giriniz")]
        [Display(Name = "Ad")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "*Adınız en az 3 karakter olabilir")]
        public string Ad { get; set; }
       

        [Required(ErrorMessage = "*Lütfen soyadınızı giriniz")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "*Soyadınız en az 3 karakter olabilir")]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "*Lütfen e-posta adresinizi giriniz")]
        [EmailAddress(ErrorMessage = "*Lütfen e - posta adresinizi geçerli bir formatta giriniz")]
        [Display(Name = "E mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Lütfen kullanıcı adınızı giriniz")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "*Kullanıcı adınız en az 3 karakter olabilir")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*Lütfen şifrenizi giriniz.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "*Şifreniz en az 4 karakterden oluşabilir")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "*Lütfen yaşınızı  giriniz")]
        [Display(Name = "Yaş")]
        public string Yas { get; set; }

        [Required(ErrorMessage = "*Lütfen şehir giriniz")]
        [Display(Name = "Şehir")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "*Lütfen adres giriniz")]
        [StringLength(1500, MinimumLength = 10, ErrorMessage = "*Lütfen adresinizi daha açıklayıcı şekilde giriniz.")]
        [MaxLength(350,ErrorMessage ="*Adres de fazla karakter var")]
        [Display(Name = "Adres")]
        public string Adres { get; set; }


        public string KullaniciyaMesaj { get; set; }

        

    }
}
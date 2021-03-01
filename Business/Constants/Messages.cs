using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string BrandAddedMessage = "Marka Eklendi";
        public static string BrandDeletedMessage = "Marka Silindi";
        public static string BrandUpdateMessage = "Marka güncellendi";
        public static string BrandErrorMessage = "En az iki karakter girişi yapmanız gerekli";
        public static string CarAddedMessage = "Araba Eklendi";
        public static string CarDeletedMessage = "Araba Silindi";
        public static string CarUpdatedMessage = "Araba Güncellendi";
        public static string ColorAddedMessage = "Renk Eklendi";
        public static string ColorDeletedMessage = "Renk Silindi";
        public static string ColorUpdatedMessage = "Renk Güncellendi";
        public static string CarErrorMessage = "Araba Özellikleri boş bırakılamaz";
        public static string ColorErrorMessage = "Araba Rengi en az 3 karekter olmalıdır";
        public static string DataResultListMessage = "Ürünler listelendi";
        public static string DataResultErrorMessage = "Bakım zamanı";
        public static string RentalAddedMessage = "Araba kiralama bilgisi eklendi";
        public static string RentalDeletedMessage = "Araba kiralama bilgisi silindi";
        public static string RentalUpdatedMessage = "Araba kiralama bilgisi güncellendi";
        public static string DataResultReturnTimeMessage = "Araba daha teslim alınamadı";
        public static string UserRegistered="Kullanıcı kayıt edildi";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Sifre hatası";
        public static string SuccessfulLogin="Başarılı giriş yapıldı";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated= "Erişim Jetonu Oluşturuldu";
    }
}

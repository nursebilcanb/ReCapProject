using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {

        public static string DescriptionsInvalid = "Lütfen açıklama kısmını iki karakterden fazla yazın";

        public static string DailyPriceInvalid = "Lütfen günlük fiyatı 0 dan büyük bir fiyat giriniz";

        public static string ReturnDateNull = "Lütfen aracınızı teslim edin";

        public static string Added = "Eklendi";

        public static string Deleted = "Silindi";

        public static string Updated = "Güncellendi";

        public static string CarsListed = "Arabalar listelendi";
        
        public static string BrandsListed = "Markalar listelendi";

        public static string ColorsListed = "Renkler listelendi";

        public static string RentalsListed = "Kiralamalar listelendi";

        public static string ImagesListed = "Fotoğraflar listelendi";
        
        public static string CarImageExceed = "Car images exceed";

        public static string UserRegistered = "Kaydoldu";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre hatalı";

        public static string AccessTokenCreated = "Token başarılı bir şekilde oluşturuldu";

        public static string SuccessfulLogin = "Giriş başarılı";

        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";

        public static string RentedCarAlreadyExists = "This rental car already exists";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string CarNotFound = "TBu araç bulunamadı";

        public static string CustomerUpdated = "Müşteri bilgileri güncellendi";

        public static string CustomerFindexPointIsZero = "Müşterinin findex puanı 0";

        public static string CustomerScoreInvalid = "Müşterinin findex puanı bu aracı kiralamak için yeterli değil";

        public static string CarAlreadyRented = "Bu araç hala kirada";

    }
}

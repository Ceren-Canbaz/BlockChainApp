using Core.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product Added";

        public static string AuthorizationDenied = "Yetkiniz bulunmamaktadır";
        internal static string UserRegistered = "Kayıt Olundu";
        internal static string UserNotFound = "Kullanıcı Bulunamadı";
        internal static string PasswordError = "Şifreyi Yanlış girdiniz";
        internal static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
        internal static string UserAlreadyExists = "Kullanıcı zaten mevcur.";
        internal static string AccessTokenCreated = "Giriş Tokenı Yaratıldı";


        internal static string ClaimAlreadyExists = "Claim Already Exists";

    }
}

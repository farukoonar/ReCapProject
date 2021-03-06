using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi!";
        public static string InvalidCarName = "Hatalı giriş yaptınız!";
        public static string MaintenanceTime = "22:00 ile 24:00 arası işlem yapamazsınız!";
        public static string CarIsNotAvaible = "Araba henüz teslim alınmadı";
        public static string UserNotFound="Kullanıcı bulunamadı!";
        public static string PasswordError="Hatalı şifre!";
        public static string SuccesfulLogin="Giriş başarılı!";
        public static string UserAlreadyExists="Kullanıcı zaten mevcut!";
        public static string UserRegistered="Kullanıcı başarıyla kayıt edildi!";
        public static string AccessTokenCreated="Access Token başarıyla oluşturuldu!";
    }
}

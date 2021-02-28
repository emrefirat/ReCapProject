using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Constants
{
    public static class Messages
    {
        public static string CarAdded =   "Araba basariyla eklendi.";
        public static string CarDeleted = "Araba basariyla silindi.";
        public static string CarUpdated = "Araba basariyla güncellendi..";
        //
        public static string CarNameInvalid = "Araba ismi gecersiz veya çok kısa!";
        public static string AllCarListed = "Tüm arabalar listelendi.";
        public static string CarListedByBrandId = "Tüm arabalar markaya göre listelendi.";
        public static string BrandAdded= "Marka basariyla eklendi.";
        public static string BrandDeleted = "Marka basariyla silindi.";
        public static string BrandUpdated = "Marka basariyla güncellendi..";
        public static string AllBrandListed = "Tüm markalar listelendi.";
        public static string BrandListedById = "Tüm markalar id'ye göre listelendi.";
        public static string ColorAdded = "Renk basariyla eklendi.";
        public static string ColorUpdated = "Renk basariyla güncellendi..";
        public static string ColorDeleted = "Renk basariyla silindi.";
        public static string AllColorListed = "Renk basariyla güncellendi..";
        public static string ColorListedById = "Tüm renkler id'ye göre listelendi";
        public static string UserAdded = "Kullanici basariyla eklendi.";
        public static string UserUpdated;
        public static string UserDeleted;
        public static string AllUserListed;
        public static string CustomerAdded = "Müsteri basariyla eklendi.";
        public static string CustomerUpdated;
        public static string CustomerDeleted;
        public static string AllCustomerListed;
        public static string GetCustomerById;
        public static string RentalAdded = "Araç Kiralandı" ;
        public static string RentalDeleted = "Kiralama basariyla silindi.";
        public static string RentalUpdated = "Kiralama basariyla güncellendi.";
        public static string CustomerNotFound = "Boyle bir Musteri Bulunamadi" ;
        public static string CustomerExist = "Böyle bir müşteri zaten var" ;
        public static string CustomerExistForTheUser = "Kullanıcıya ait aynı şirkete ait bir müşteri hesabı zaten var.";
        public static string RentalIsNotReturned = "Kiralama henüz İade Edilmedi" ;
        public static string CarNotFound = "Araba bulunamadı" ;
        public static string AllCarImagesListed = "Tüm araç resimleri listelendi.";
        public static string CarImagesAdded = "Araba resmi yüklendi";
        public static string CarImageLimitExceeded = "Aynı arabaya ait en fazla 5 görüntü eklenebilir.";
        public static string CarImageNotAdded = "Araba resmi eklenemedi";
        public static string CarImageUpdated =  "Araba ait resim güncellendi." ;
        public static string CarImageDeleted = "Araç resmi silindi.";


        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";


    }
}

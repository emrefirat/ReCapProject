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
        public static string ColorDeleted = "Renk basariyla silindi.";
        public static string AllColorListed = "Renk basariyla güncellendi..";
        public static string ColorListedById = "Tüm renkler id'ye göre listelendi";
        internal static string UserAdded;
        internal static string UserUpdated;
        internal static string UserDeleted;
        internal static string AllUserListed;

        public static object ColorUpdated { get; internal set; }
    }
}

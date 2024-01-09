using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi.";
        public static string CarNameInvalid = "Araç ismi geçersiz.";
        public static string MaintenanceTime="Sistem bakımda.";
        public static string CarsListed="Araçlar Listelendi.";
        public static string DailyPriceInvalid="Ücret geçersiz.";
        public static string CarCountError ="Bir markadan en fazla 10 araç eklenebilir.";
        public static string CarNameAlreadyExists="Bu isimde bir araç mevcut.";
        public static string RentalNotAdded="Araç Kiralanamadı.";
        public static string RentalAdded="Araç Kiralandı";
        public static string ImageAdded="Görsel eklendi.";
        public static string ImageDeleted="Görsel Silindi.";
        public static string ImagesUpdated="Görsel Güncellendi.";
        public static string CarImageLimitReached= "Araç görseli ekleme sınırına ulaşıldı";
        public static string CarImageAlreadyExists="Görsel zaten mevcut. ";
    }
}

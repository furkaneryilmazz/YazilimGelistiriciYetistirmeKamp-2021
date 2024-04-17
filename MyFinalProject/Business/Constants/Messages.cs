using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages //static verilmesinin sebebi new'lenmesin diye
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        internal static string ProductNameAlreadyExists ="Bu isimde zaten başka bir ürün var";
        internal static string CategoryLimitExceded ="Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        internal static string AuthorizationDenied ="Yetkiniz yok.";
    }
}

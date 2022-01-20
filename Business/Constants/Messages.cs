

namespace Business.Constant
{
    public static class Messages
    {
        public static string CompanyAdded = "Firma Başarı ile eklendi";
        public static string CompanyUpdated = "Firma Başarı ile güncellendi";
        public static string CompanyDeleted = "Firma Başarı ile silindi";

        //public static string DatabaseAdded = "Database Bilgisi Başarı ile eklendi";
        //public static string DatabaseUpdated = "Database Bilgisi Başarı ile güncellendi";
        //public static string DatabaseDeleted = "Database Bilgisi Başarı ile silindi";

        //public static string LicenceAdded = "Lisans Bilgisi Başarı ile eklendi";
        //public static string LicenceUpdated = "Lisans Bilgisi Başarı ile güncellendi";
        //public static string LicenceDeleted = "Lisans Bilgisi Başarı ile silindi";

        public static string LocalsAdded = "Şube Bilgisi Başarı ile eklendi";
        public static string LocalsUpdated = "Şube Bilgisi Başarı ile güncellendi";
        public static string LocalsDeleted = "Şube Bilgisi Başarı ile silindi";

        //public static string rolesAdded = "Rol Bilgisi Başarı ile eklendi";
        //public static string rolesUpdated = "Rol Bilgisi Başarı ile güncellendi";
        //public static string rolesDeleted = "Rol Bilgisi Başarı ile silindi";


        public static string UsersAdded = "Kullanici Başarı ile eklendi";
        public static string UsersUpdated = "Kullanici Bilgisi Başarı ile güncellendi";
        public static string UsersDeleted = "Kullanici Bilgisi Başarı ile silindi";

        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Kullanıcı veya Sifre Hatali";
        public static string SuccessfullLogin = "Sisteme Giris Basarili";
        public static string UserAlreadyExist = "Kullanıcı daha önce kayıt olmuştur.";
        public static string AccessTokenCreated = "Token Oluşturuldu.";


        #region ValidationMessages

        public static string TaxNumberValidationError = "Vergi Numarasi Boş Bırakılamaz.";
        public static string TaxNumberLengtValidationError = "Vergi Numarasi Uzunluğu hatası";

        #endregion


        public static string AuthorizationDenied = "Yetkiniz Bu İşlemi Yapmaya Uygun Değil.";

        public static string CompanyTaxNumberExistError = "Firma Daha Önce Kayıt Edilmiştir.";

        public static string EmailCanNotBlank = "Mail Adresi Bos Birakilamaz";
       
        internal static string rolesAdded = "Rol Eklendi.";
        public static string rolesDeleted = "Rol Silindi.";
        public static string rolesUpdated = "Rol Güncellendi.";
        

        public static string WareHouseUpdated ="Ambar Güncellendi";
        public static string WareHouseDeleted = "Ambar Silindi";
        public static string WareHouseAdded = "Ambar Eklendi";

        public static string WareHouseFloorAdded = "Kat Eklendi";
        public static string WareHouseFloorDeleted = "Kat Silindi";
        public static string WareHouseFloorUpdated = "Kat Güncellendi";

        public static string WareHouseShelfAdded   = "Raf Eklendi";
        public static string WareHouseShelfDeleted = "Raf Silindi";
        public static string WareHouseShelfUpdated = "Raf Güncellendi";


        public static string WareHouseBenchAdded =   "Sıra Eklendi";
        public static string WareHouseBenchDeleted = "Sıra Silindi";
        public static string WareHouseBenchUpdated = "Sıra Güncellendi";

        public static string WareHouseCorridorAdded =   "Koridor Eklendi";
        public static string WareHouseCorridorDeleted = "Koridor Silindi";
        public static string WareHouseCorridorUpdated = "Koridor Güncellendi";
    }
}
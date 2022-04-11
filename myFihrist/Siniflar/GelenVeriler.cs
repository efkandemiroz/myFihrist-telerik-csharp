using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myFihrist.Siniflar
{
    // Bu sınıfta statik olarak formlar arası veri taşımak için kullanılacaktır.
    class GelenVeriler 

    {
        private static string _ad;

        public static string Ad
        {
            get { return GelenVeriler._ad; }
            set { GelenVeriler._ad = value; }
        }

        private static string _soyad;

        public static string Soyad
        {
            get { return GelenVeriler._soyad; }
            set { GelenVeriler._soyad = value; }
        }
        private static DateTime _dogumTarihi;

        public static DateTime DogumTarihi
        {
            get { return GelenVeriler._dogumTarihi; }
            set { GelenVeriler._dogumTarihi = value; }
        }
        private static string _kanGrubu;

        public static string KanGrubu
        {
            get { return GelenVeriler._kanGrubu; }
            set { GelenVeriler._kanGrubu = value; }
        }
        private static string _notlar;

        public static string Notlar
        {
            get { return GelenVeriler._notlar; }
            set { GelenVeriler._notlar = value; }
        }
        private static string _cepTel;

        public static string CepTel
        {
            get { return GelenVeriler._cepTel; }
            set { GelenVeriler._cepTel = value; }
        }
        private static string _evTel;

        public static string EvTel
        {
            get { return GelenVeriler._evTel; }
            set { GelenVeriler._evTel = value; }
        }
        private static string _isTel;

        public static string IsTel
        {
            get { return GelenVeriler._isTel; }
            set { GelenVeriler._isTel = value; }
        }
        private static string _faks;

        public static string Faks
        {
            get { return GelenVeriler._faks; }
            set { GelenVeriler._faks = value; }
        }
        private static string _sirket;

        public static string Sirket
        {
            get { return GelenVeriler._sirket; }
            set { GelenVeriler._sirket = value; }
        }
        private static string _isUnvani;

        public static string IsUnvani
        {
            get { return GelenVeriler._isUnvani; }
            set { GelenVeriler._isUnvani = value; }
        }
        private static string _evAdres;

        public static string EvAdres
        {
            get { return GelenVeriler._evAdres; }
            set { GelenVeriler._evAdres = value; }
        }
        private static string _isAdres;

        public static string IsAdres
        {
            get { return GelenVeriler._isAdres; }
            set { GelenVeriler._isAdres = value; }
        }
        private static string _eMail;

        public static string EMail
        {
            get { return GelenVeriler._eMail; }
            set { GelenVeriler._eMail = value; }
        }
        private static string _webAdres;

        public static string WebAdres
        {
            get { return GelenVeriler._webAdres; }
            set { GelenVeriler._webAdres = value; }
        }
        private static string _facebook;

        public static string Facebook
        {
            get { return GelenVeriler._facebook; }
            set { GelenVeriler._facebook = value; }
        }
        private static string _twitter;

        public static string Twitter
        {
            get { return GelenVeriler._twitter; }
            set { GelenVeriler._twitter = value; }
        }
        private static string _kullaniciId;

        public static string KullaniciId
        {
            get { return GelenVeriler._kullaniciId; }
            set { GelenVeriler._kullaniciId = value; }
        }
        private static int _kanGrubuIndex;

        public static int KanGrubuIndex
        {
            get { return GelenVeriler._kanGrubuIndex; }
            set { GelenVeriler._kanGrubuIndex = value; }
        }


    }
}

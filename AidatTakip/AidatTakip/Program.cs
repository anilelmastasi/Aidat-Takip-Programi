/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2019-2020 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........:01
** ÖĞRENCİ ADI............:ANIL ELMASTAŞI
** ÖĞRENCİ NUMARASI.......:B191200005
** DERSİN ALINDIĞI GRUP...:A
****************************************************************************/

using System;
using System.Globalization; //CultureInfo.CurrentCulture.TextInfo.ToTitleCase yani kelimelerin baş harfini büyük yapmak için
                            //kullanılan metot bu kütühanenin içinde.  
                            

namespace AidatTakip
{
    class Program
    {
        static void Main(string[] args)
        {
            //Değişken Tanımlamaları
            double havuzBakim_ucret = 30, apartmanTemizlik_ucret = 10, guvenlik_ucret = 45, kapici_ucret = 25,
                asansorBakim_ucret = 20, bahceBakim_ucret = 20, apartmanElektrik_ucret = 5,yonetici_ucret=10,catiBakim_ucret=5 ;
            //double kullandım çünkü ücretler buçuklu yazılabilir.

            double toplamAidat_adet = havuzBakim_ucret+ apartmanTemizlik_ucret + guvenlik_ucret + kapici_ucret
                + asansorBakim_ucret + bahceBakim_ucret+ apartmanElektrik_ucret+ yonetici_ucret+ catiBakim_ucret;
            //daire başına düşen 1 aylık aidat miktarını bu değişkenle buldum.

            

            string odeyenlerAd = "", odeyenlerBlok = "", odeyenlerDaire = "", odeyenlerAy = "",
                odeyenlerAidat="",odeyenlerBorc=""; //aidat ödeme kısmında üstüne yazdırıp aidat ödeyenler kısmında yazdıracağım.




            char anamenusecim = '0', altmenusecim = '0', aidatfiyatguncelle = '0'; //menü yönlendirme mantıksal değerlendirmesinde kullanılacak.


            Console.WriteLine("***********AİDAT TAKİP PROGRAMI***********");
            Console.WriteLine();

            Console.WriteLine("Lütfen site bilgilerini giriniz. ");

            Console.Write("Yönetici adı soyadı: ");
            string yoneticiBilgi = Console.ReadLine();
            yoneticiBilgi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(yoneticiBilgi);
            //yukarıdaki metodu yonetici bilgilerinin baş harflerinin büyük başlaması için kullandım.
            //bu metodu kullanmak için System.Globalization kütüphanesini dahil ettim.

            Console.Write("Sitede kaç blok var: "); 
            int blokSayisi = Convert.ToInt32(Console.ReadLine());

            Console.Write("Bloklardaki daire sayısı: ");    

            int daireSayisi = Convert.ToInt32(Console.ReadLine());

            int aysayisi = 12; 
            int[,,] blokdaire = new int[blokSayisi, daireSayisi,aysayisi];                      //bu dizileri aidat ödeme kısmında
            string[] odeyenadsoyadDizi = new string[(daireSayisi*aysayisi*blokSayisi)];         //içi boş string değişkenlerle toplayıp
            string[] odeyenblokDizi = new string[(blokSayisi * daireSayisi * aysayisi)];        //aidat ödeyenler kısmında yazdıracağım.
            string[] odeyendaireDizi = new string[(blokSayisi * daireSayisi * aysayisi)];
            string[] odeyenayDizi = new string[(blokSayisi * daireSayisi * aysayisi)];
            string[] odeyenaidatDizi = new string[blokSayisi * daireSayisi * aysayisi];
            string[] odeyenborcDizi = new string[blokSayisi * daireSayisi * aysayisi];

            Console.Clear();
            Console.WriteLine("***********AİDAT TAKİP PROGRAMI***********");
            Console.WriteLine();
            Console.WriteLine("Hoşgeldiniz, {0}. Lütfen bir işlem seçiniz: ", yoneticiBilgi);
            Console.WriteLine();

        MENU: //anamenuye tekrar dondurmek icin bu etiketi kullandım.
            Console.WriteLine("1-Aidat Ücretlerini Göster");
            Console.WriteLine("2-Aidat Ücretlerini Güncelle");
            Console.WriteLine("3-Aidat Ödemesi Gir");
            Console.WriteLine("4-Ödenmiş Aidatları Göster");
            Console.WriteLine("5-Çıkış");

            Console.Write("Seçiminiz yapınız [1,2,3,4,5]: ");
            anamenusecim = Convert.ToChar(Console.ReadLine());

            if (anamenusecim == '1') //AİDAT ÜCRETLERİNİ GÖSTERMESİ İÇİN 1 E BASMASI GEREKLİ.
            {
                Console.Clear();
                Console.WriteLine(">>Aidat Ücretlerini Göster<<");
                Console.WriteLine();
                Console.WriteLine("Havuz Bakım Ücreti: {0}TL", havuzBakim_ucret);
                Console.WriteLine("Bahçe Bakım Ücreti: {0}TL", bahceBakim_ucret);
                Console.WriteLine("Asansör Bakım Ücreti: {0}TL", asansorBakim_ucret);
                Console.WriteLine("Çatı Bakım Ücreti: {0}TL", catiBakim_ucret);
                Console.WriteLine("Apartman Temizlik Ücreti: {0}TL", apartmanTemizlik_ucret);
                Console.WriteLine("Apartman Elektrik Ücreti: {0}TL", apartmanElektrik_ucret);
                Console.WriteLine("Güvenlik Ücreti: {0}TL", guvenlik_ucret);
                Console.WriteLine("Kapıcı Ücreti: {0}TL", kapici_ucret);
                Console.WriteLine("Yönetici Ücreti: {0}TL", yonetici_ucret);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Toplam: {0} TL", toplamAidat_adet);
                Console.WriteLine();

            ALTMENU: //ALTMENU etiketi sayesinde programdan çıkmaya gerek kalmıyor. ana menüye dönebiliriz ya da programı kaparız.
                Console.Write("Seçiminizi Yapınız [1-Ana Menüye Dön 2-Programı Kapat]:");
                altmenusecim = Convert.ToChar(Console.ReadLine());
                if (altmenusecim == '1')
                {
                    Console.Clear();
                    goto MENU;
                }
                else if (altmenusecim == '2')
                {
                    Environment.Exit(0); //programı bu kod ile kapatabiliriz.
                }
                else
                {
                    Console.WriteLine("1,2 dışında seçenekleri dışında seçim yaptınız.");
                    goto ALTMENU;

                }
            }


            else if (anamenusecim == '2') //AİDAT ÜCRETLERİNİ GÜNCELLEMESİ İÇİN 2 YE BASMASI GEREKLİ.
            {
                Console.Clear();
                Console.WriteLine(">>Aidat Ücretlerini Güncelle<<");
                Console.WriteLine();
            AIDATTIPI:
                Console.WriteLine("Aidat Türünü Seçiniz:");       //if e eşitlemek için başlarına harf verdik.
                Console.WriteLine("[1-Havuz Bakım Ücreti, 2-Bahçe Bakım Ücreti, 3-Asansör Bakım Ücreti");
                Console.WriteLine("4-Çatı Bakım Ücreti, 5-Apartman Temizlik Ücreti, 6-Apartman Elektrik Ücreti");
                Console.WriteLine("7-Güvenlik Ücreti, 8-Kapıcı Ücreti, 9-Yönetici Ücreti]");

                aidatfiyatguncelle = Convert.ToChar(Console.ReadLine());//klavyeden girilen her değer default olarak stringtir
                                                                        //bizim bunu chara dönüştürmemiz gerek.

                if (aidatfiyatguncelle == '1') //Havuz bakım ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Havuz bakım ücreti:{0} TL", havuzBakim_ucret);
                    Console.Write("Havuz bakım için yeni fiyat girin:");
                    havuzBakim_ucret = Convert.ToDouble(Console.ReadLine()); //yeni havuz bakım ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Havuz bakım ücreti:{0} TL", havuzBakim_ucret);
                    Console.WriteLine();
                }

                else if (aidatfiyatguncelle == '2') //Bahçe bakım ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Bahçe bakım ücreti:{0} TL", bahceBakim_ucret);
                    Console.Write("Bahçe bakım için yeni fiyat girin:");
                    bahceBakim_ucret = Convert.ToDouble(Console.ReadLine()); //yeni bahçe bakım ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Bahçe bakım ücreti:{0} TL", bahceBakim_ucret);
                    Console.WriteLine();
                }

                else if (aidatfiyatguncelle == '3') //Asansör bakım ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Asansör bakım ücreti:{0} TL", asansorBakim_ucret);
                    Console.Write("Asansör bakım için yeni fiyat girin:");
                    asansorBakim_ucret = Convert.ToDouble(Console.ReadLine()); //yeni asansör bakım ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Asansör bakım ücreti:{0} TL", asansorBakim_ucret);
                    Console.WriteLine();
                }

                else if (aidatfiyatguncelle == '4') //Çatı bakım ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Çatı bakım ücreti:{0} TL", catiBakim_ucret);
                    Console.Write("Çatı bakım için yeni fiyat girin:");
                    catiBakim_ucret = Convert.ToDouble(Console.ReadLine()); //yeni çatı bakım ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Çatı bakım ücreti:{0} TL", catiBakim_ucret);
                    Console.WriteLine();
                }

                else if (aidatfiyatguncelle == '5') //Apartman temizlik ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Apartman temizlik ücreti:{0} TL", apartmanTemizlik_ucret);
                    Console.Write("Apartman temizlik için yeni fiyat girin:");
                    apartmanTemizlik_ucret = Convert.ToDouble(Console.ReadLine()); //yeni Apartman temizlik ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Apartman temizlik ücreti:{0} TL", apartmanTemizlik_ucret);
                    Console.WriteLine();
                }

                else if (aidatfiyatguncelle == '6') //Apartman elektrik ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Apartman temizlik ücreti:{0} TL", apartmanTemizlik_ucret);
                    Console.Write("Apartman elektrik için yeni fiyat girin:");
                    apartmanElektrik_ucret = Convert.ToDouble(Console.ReadLine()); //yeni Apartman elektrik ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Apartman elektrik ücreti:{0} TL", apartmanElektrik_ucret);
                    Console.WriteLine();
                }

                else if (aidatfiyatguncelle == '7') //Site güvenlik ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Site güvenlik ücreti:{0} TL", guvenlik_ucret);
                    Console.Write("Site güvenlik için yeni fiyat girin:");
                    guvenlik_ucret = Convert.ToDouble(Console.ReadLine()); //yeni Site güvenlik ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Site güvenlik ücreti:{0} TL", guvenlik_ucret);
                    Console.WriteLine();
                }

                else if (aidatfiyatguncelle == '8') // kapıcı ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Site güvenlik ücreti:{0} TL", kapici_ucret);
                    Console.Write("Kapıcı için yeni fiyat girin:");
                    kapici_ucret = Convert.ToDouble(Console.ReadLine()); //yeni kapıcı ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Kapıcı ücreti:{0} TL", kapici_ucret);
                    Console.WriteLine();
                }

                else if (aidatfiyatguncelle == '9') //Site yönetici ücreti için değişiklik yaparız.
                {
                    Console.WriteLine("Site yönetici ücreti:{0} TL", yonetici_ucret);
                    Console.Write("Site yönetici için yeni fiyat girin:");
                    yonetici_ucret = Convert.ToDouble(Console.ReadLine()); //yeni Site yönetici ücretini değişkene aktarıyoruz.
                    Console.WriteLine("Değişiklik Yapılmıştır.");
                    Console.WriteLine("Yeni Site yönetici ücreti:{0} TL", yonetici_ucret);
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("Hatalı Seçim Yaptınız!");
                    goto AIDATTIPI; //HATALI BİR TUŞ GİRİŞİNDE TEKRAR SEÇTİRMEK İÇİN ETİKETİ KULLANDIM
                }

                toplamAidat_adet = havuzBakim_ucret + apartmanTemizlik_ucret + guvenlik_ucret + kapici_ucret
                + asansorBakim_ucret + bahceBakim_ucret + apartmanElektrik_ucret + yonetici_ucret + catiBakim_ucret;
            //programın başındaki sabit değerlerle sonra yazdığımız değerlerin değişmesi için buraya koydum.

            ALTMENU:
                Console.Write("Seçiminizi Yapınız [1-Ana Menüye Dön 2-Başka Aidat Fiyatı Değiştir 3-Programı Kapat]:");
                altmenusecim = Convert.ToChar(Console.ReadLine());
                if (altmenusecim == '1')
                {
                    Console.Clear();
                    goto MENU;
                }

                else if (altmenusecim == '2')
                {
                    Console.Clear();
                    goto AIDATTIPI;
                }
                else if (altmenusecim == '3')
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("1,2 dışında seçenekleri dışında seçim yaptınız.");
                    goto ALTMENU;

                }
            }
            else if (anamenusecim == '3') //AİDAT ÖDEMESİ GİRMESİ İÇİN 3 E BASMASI GEREKLİ.
            {
            ODEMEGIR:
                Console.Clear();
                Console.WriteLine(">>Aidat Ödemesi Gir<<");
                Console.WriteLine();
                //for döngüsü için
                Console.Write("Adı Soyadı: ");
                for (int i = 1; i < 2; i++)
                {

                    odeyenadsoyadDizi[i] = Console.ReadLine();
                    odeyenlerAd = odeyenlerAd + "\t" + odeyenadsoyadDizi[i];
                    odeyenlerAd = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(odeyenlerAd); //aidat ödeyenler kısmında başharfleri büyük olmalı.
                }


            BLOKSECME:  //Yanlış blok seçiminde tekrar buraya yönlendirmesi için bu etiketi koydum.
                Console.WriteLine("Kaçıncı Blokta Oturuyor?");
                int sayac = 0;
                for (sayac = 1; sayac <= blokSayisi; sayac++)       //Girilen Blok sayısına kadar saydırması için döngüye soktum.            
                {
                    Console.Write("[{0}].  ", sayac);
                }
                string odeyenBlok = Console.ReadLine();             //odeyenBlok değişkenine  klavyeden
                                                                    // girilen kaçıncı blokta oturduğunu aktardım.

                int odeyenBlokKontrol = Convert.ToInt32(odeyenBlok); //int odeyenBlokKontrol ile klavyeden girilen blok sayısını
                                                                     //int değerine dönüştürüp kontrolde kullanmak için değişkene akatardım.


                if (odeyenBlokKontrol > blokSayisi || odeyenBlokKontrol < 0) //yanlış blok seçiminin önüne geçmek için bu mantıksal
                {                                                        //sınamayı kurdum.
                    Console.WriteLine();
                    Console.WriteLine("Lütfen geçerli bir blok seçiniz.");  //eğer ilk başta girilen blok sayısından yukarda
                    goto BLOKSECME;                                         //değer girilirse hata veriyor ve başa dönüdürüyorum.
                }

                Console.WriteLine();

                

                for (int i = 1; i < 2; i++)                                                        //burdaki amacım klavyeden girilen blokların
                {                                                                                  //bellekte tutulup daha sonra aidat ödeyenler
                                                                                                   //kısmında yazdırılması
                    odeyenblokDizi[i] = odeyenBlok;                                                //aynı işlemi daire ay ödenen aidat ve borçta da uyguladım.
                    odeyenlerBlok = odeyenlerBlok + "\t       " + odeyenblokDizi[i];

                }



            DAIRESECME:     //Yanlış daire seçiminde tekrar buraya yönlendirmesi için bu etiketi koydum.
                Console.WriteLine("Hangi Dairede Oturuyor: ");
                for (sayac = 1; sayac <= daireSayisi; sayac++)       //Girilen daire sayısına kadar saydırması için döngüye soktum.            
                {
                    Console.Write("[{0}].  ", sayac);
                }
                string odeyenDaire = Console.ReadLine();             //odeyenDaire değişkenine  klavyeden
                                                                     // girilen kaçıncı dairede oturduğunu aktardım.
                int odeyenDaireKontrol = Convert.ToInt32(odeyenDaire); //int odeyenDaireKontrol ile klavyeden girilen daire sayısını
                                                                       //int değerine dönüştürüp kontrolde kullanmak için değişkene akatardım.
                if (odeyenDaireKontrol > daireSayisi || odeyenDaireKontrol < 0) //yanlış daire seçiminin önüne geçmek için bu mantıksal
                {                                                               //sınamayı kurdum.
                    Console.WriteLine();
                    Console.WriteLine("Lütfen geçerli bir daire seçiniz.");  //eğer ilk başta girilen daire sayısından yukarda
                    goto DAIRESECME;                                         //değer girilirse hata veriyor ve başa dönüdürüyorum.
                }

                Console.WriteLine();


                for (int i = 1; i < 2; i++)
                {

                    odeyendaireDizi[i] = odeyenDaire;
                    odeyenlerDaire = odeyenlerDaire + "\t       " + odeyendaireDizi[i];

                }

            AYSECME:                                            //Yanlış Ay seçiminde tekrar buraya yönlendirmesi için bu etiketi koydum.
                Console.Write("Hangi Ay İçin Aidat Ödüyor: ");
                int aysirala;                                   //1 den 12 ye boşuna yazmamak için hemen döngü kullandım.
                for (aysirala = 1; aysirala <= 12; aysirala++)
                {
                    Console.Write("[{0}] ", aysirala);
                }
                Console.WriteLine();
                Console.WriteLine("                             1-Ocak       2-Şubat     3-Mart");          //Tasarımın güzel görünmesi için
                Console.WriteLine("                             4-Nisan      5-Mayıs     6-Haziran");       //yukarıdaki döngüde sıralanan rakamların
                Console.WriteLine("                             7-Temmuz     8-Ağustos   9-Eylül");         //altına gelecek şekilde ayarladım.
                Console.WriteLine("                             10-Ekim      11-Kasım    12-Aralık");

                string odenenAy = Console.ReadLine();

                int odenenAyKontrol = Convert.ToInt32(odenenAy);    //int odenenenAyKontrol ile klavyeden girilen daire sayısını
                                                                    //int değerine dönüştürüp kontrolde kullanmak için değişkene akatardım.
                if (odenenAyKontrol > 12 || odenenAyKontrol < 0) //yanlış daire seçiminin önüne geçmek için bu mantıksal
                {                                                               //sınamayı kurdum.
                    Console.WriteLine();
                    Console.WriteLine("Lütfen geçerli bir ayseçiniz.");  //eğer ilk başta girilen daire sayısından yukarda
                    goto AYSECME;                                         //değer girilirse hata veriyor ve başa dönüdürüyorum.
                }

                //odeyenlerAy = odenenAy + odeyenlerAy;

                for (int i = 1; i < 2; i++)
                {

                    odeyenayDizi[i] = odenenAy;
                    odeyenlerAy = odeyenlerAy + "\t       " + odeyenayDizi[i];

                }

                Console.WriteLine();

                Console.WriteLine("Aylık Aidat Ücreti:{0} TL", toplamAidat_adet);

                Console.Write("Kaç TL Aidat Ödenecek: ");
                string odenenAidat = Console.ReadLine();
                int odenenAidatInteger = Convert.ToInt32(odenenAidat);// DAHA SONRA HESAPLARDA KULLANMAK İÇİN İNT E ÇEVİRDİM.
                for (int i = 1; i < 2; i++)
                {

                    odeyenaidatDizi[i] = odenenAidat;
                    odeyenlerAidat = odeyenlerAidat + "\t       " + odeyenaidatDizi[i];

                }


                Console.WriteLine();

                Console.WriteLine("Ödeme Tamamlanmıştır.");
                double odeyenBorc = toplamAidat_adet - odenenAidatInteger;
                Console.WriteLine("Bu aydan kalan borç:{0} TL", odeyenBorc);
                string odeyenBorcString = Convert.ToString(odeyenBorc);
                for (int i = 1; i < 2; i++)
                {

                    odeyenborcDizi[i] = odeyenBorcString;
                    odeyenlerBorc = odeyenlerBorc + "\t       " + odeyenborcDizi[i];

                }


                Console.WriteLine();
            ALTMENU:
                Console.Write("Seçiminizi Yapınız [1-Ana Menüye Dön 2-Başka Aidat Öde 3-Programı Kapat]:");
                altmenusecim = Convert.ToChar(Console.ReadLine());
                if (altmenusecim == '1')
                {
                    Console.Clear();
                    goto MENU;
                }

                else if (altmenusecim == '2')
                {
                    Console.Clear();
                    goto ODEMEGIR;
                }
                else if (altmenusecim == '3')
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("1,2 dışında seçenekleri dışında seçim yaptınız.");
                    goto ALTMENU;

                }
            }

            else if (anamenusecim == '4')           //Ödenmiş aidatları göstermek için 4e basarız.

            {

                Console.Clear();
                Console.WriteLine(">>Ödenmiş Aidatları Göster<<");
                Console.WriteLine();
                Console.WriteLine("=====================================================================================================================");
                Console.WriteLine("Adı Soyadı | {0}", odeyenlerAd);
                Console.WriteLine("=====================================================================================================================");
                Console.WriteLine("Blok       | {0}                     ", odeyenlerBlok);
                Console.WriteLine("=====================================================================================================================");
                Console.WriteLine("Daire      | {0}                ", odeyenlerDaire);
                Console.WriteLine("=====================================================================================================================");
                Console.WriteLine("Ay         | {0}                ",odeyenlerAy);
                Console.WriteLine("=====================================================================================================================");
                Console.WriteLine("Ödenen     | {0}              ",odeyenlerAidat);
                Console.WriteLine("=====================================================================================================================");
                Console.WriteLine("Borc       | {0}              ",odeyenlerBorc);
                Console.WriteLine("=====================================================================================================================");

                Console.WriteLine();


            ALTMENU:
                Console.Write("Seçiminizi Yapınız [1-Ana Menüye Dön 2-Programı Kapat]:");
                altmenusecim = Convert.ToChar(Console.ReadLine());
                if (altmenusecim == '1')
                {
                    Console.Clear();
                    goto MENU;
                }

                else if (altmenusecim == '2')
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("1,2 dışında seçenekleri dışında seçim yaptınız.");
                    goto ALTMENU;

                }

            }


            else if (anamenusecim == '5') //programdan çıkış yapar.
            {
                Environment.Exit(0);
            }
                Console.ReadKey();
        }
    }
}

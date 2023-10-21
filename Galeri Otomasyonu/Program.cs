using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri_Otomasyonu
{
    public class Program

    {
        static void Main(string[] args)

        {

            // Araba Ekle - Araba Görüntüle - Araba Sil - Araba Güncelle - Araba Ara - Çıkış
            Console.Title = "Galeri Otomasyonu";
            Console.ReadKey();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            int id = 0;
            List<Araba> arabalar = new List<Araba>();

            bool donsunMu = true;

            while (donsunMu)

            {

                Console.WriteLine("1-Araba Ekle");
                Console.WriteLine("2-Araba Görüntüle");
                Console.WriteLine("3-Araba Sil");
                Console.WriteLine("4-Araba Güncelle");
                Console.WriteLine("5-Cikis");

                string secim = Console.ReadLine();

                switch (secim)

                {

                    case "1":

                        Console.WriteLine("Marka Giriniz");
                        Console.WriteLine("Model Giriniz");
                        Console.WriteLine("Model Yılı Giriniz");
                        Console.WriteLine("Alış Fiyatı Giriniz");

                        string okunan = Console.ReadLine();

                        id++;

                        // her araba girildiğinde id bir artıcak

                        Araba a1 = new Araba();

                        {

                            a1.Id = id;
                            a1.Marka = okunan.Split(' ')[0];
                            a1.Model = okunan.Split(' ')[1];
                            a1.ModelYili = Convert.ToDouble(okunan.Split(' ')[2]);
                            a1.AlisFiyati = Convert.ToDouble(okunan.Split(' ')[3]);


                        }

                        arabalar.Add(a1);

                        break;


                        case "2":

                        Console.WriteLine();
                        Console.WriteLine("-----Arabalar-----");
                        Console.WriteLine();

                        foreach (var item in arabalar)

                        {

                            Console.WriteLine(item);

                        }

                        break;

                        case "3":

                        Console.WriteLine();
                        Console.WriteLine("Modeli 2005'ten buyuk araclar");

                        var liste1 = arabalar.Where(x => x.ModelYili > 2005);

                        foreach (var item in liste1)

                        {

                            Console.WriteLine(item);

                        }

                        Console.WriteLine();
                        Console.WriteLine("Guncel Fiyata gore sıralanmıs araclar");
                        
                        var liste2 = arabalar.OrderBy(x => x.FiyatHesapla());

                        // order by geriye bir liste döndürür (geriye)

                        foreach (var item in liste2)

                        {

                            Console.WriteLine(item);

                        }

                        Console.WriteLine();
                        Console.WriteLine("Markasında a harfi olan araclar");
                        
                        var liste3 = arabalar.Where(x => x.Marka.ToLower().Contains("a"));

                        // Büyük harf bile girerse küçük harfe çevirmek için ToLower() kullandık


                        foreach (var item in liste3)

                        {

                            Console.WriteLine(item);

                        }

                        Console.WriteLine();
                        Console.WriteLine("en eski arac");
                        Console.WriteLine();

                        var enKucuk = arabalar.Min(x => x.ModelYili);

                        // Min() geriye bir tane değer döndürür

                        foreach (var item in arabalar)

                        {

                            if (item.ModelYili == enKucuk)

                            {

                                Console.WriteLine(item);

                            }

                        }

                        Console.WriteLine();

                        Console.WriteLine("Galerideki arac sayisi");
                        Console.WriteLine();

                        Console.WriteLine("Galeride suan {0} adet arac bulıunmaktadır",arabalar.Count);

                        Console.WriteLine();

                        Console.WriteLine("Galerideki araçların toplam değeri: {0}",arabalar.Sum(x=> x.FiyatHesapla()));

                        // Toplamı bulabilmek için sum değişkeni kullandık

                        break;

                        case "4":

                        foreach (var item in arabalar)

                        {

                            Console.WriteLine(item);

                        }

                        Console.WriteLine("Lutfen silmek istediğiniz aracın ıd sini giriniz"); Console.WriteLine();
                        
                        arabalar.Remove(arabalar.FirstOrDefault(x => x.Id == Convert.ToInt32(Console.ReadLine())));

                        break;

                        case "5":

                        Console.Write("Programdan cıkılıyor");

                        int i;

                        for (i = 0; i < 3; i++ )
                        
                        {

                            Console.WriteLine(".");
                             System.Threading.Thread.Sleep(1000);
                        }
                       
                        // 1 saniye bekletmek için kullandık

                        donsunMu = false;

                        break;

                        default:

                        Console.WriteLine("Lutfen listeden seciniz");

                        break;



                }
            }
        }


    }

        public class Araba

        {
            // ID MARKA MODEL MODELYILI ALİSFİYATI VS BUNLAR PROPERTY OLARAK TANIMLANACAK
            public int Id { get; set; }
            public string Marka { get; set; }

            public string Model { get; set; }

            public double ModelYili { get; set; }

            public double AlisFiyati { get; set; }

            public virtual double FiyatHesapla()

            {

                // bu propertylerin hepsini dahil etmek için virtual kullandık

                return AlisFiyati - (DateTime.Today.Year - ModelYili) * 1000;

                // Arabanın değerinin her yıl bin lira düştüğünü varsaydık


            }

            public override string ToString()

            {

                return Id + " " + Marka + " " + Model + " " + ModelYili + " " + AlisFiyati + " " +
                FiyatHesapla();

            }


        }

    }

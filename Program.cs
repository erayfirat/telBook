using System;
using System.Collections.Generic;

namespace telBook
{
    static class Program
    {
        private static List<Guide> GuideList= new List<Guide>();
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :");
                Console.WriteLine(" *******************************************\n");
                Console.WriteLine("1. Telefon Numarası Kaydet");
                Console.WriteLine("2. Telefon Numarası Sil");
                Console.WriteLine("3. Telefon Numarası Güncelle");
                Console.WriteLine("4. Rehber Listeleme (A-Z, Z-A seçimli)");
                Console.WriteLine("5. Rehberde Arama");
                Console.WriteLine("6. Çıkış");

                int selection = int.Parse(Console.ReadLine());
                if (selection==6)
                {
                    foreach (char item in "Çıkış yapılıyor...")
                    {
                        Console.Write(item);
                        System.Threading.Thread.Sleep(100);
                    }
                    break;
                }

                switch (selection)
                {
                    case 1:
                        Guide guide=Record();
                        GuideList.Add(guide);
                        break;
                    case 2:
                        Find();
                        Delete();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        ListBook();
                        break;
                    case 5:
                        Find();
                        continue;
                }
            }
        }

        private static void Find()
        {
            Console.WriteLine("Find");
        }

        private static void ListBook()
        {
            Console.WriteLine("List");
        }

        private static void Update()
        {
            Console.WriteLine("Update");
        }

        private static void Delete()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string val=Console.ReadLine();
            Guide guide=FindWithVal(val);
            Display(guide);
        }

        private static void Display(Guide guide)
        {
            bool choice=false;
            while(string.IsNullOrEmpty(guide.Name))
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                string num=Console.ReadLine();
                if (num == "1")
                {
                    choice = true;
                    break;
                }
                else if (num == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("{0} hatalı giriş yaptınız!");
                    Console.WriteLine("Lütfen yeniden deneyiniz!\n");
                    continue;
                }
            }

            if(choice)
                Start();
            else
                Delete();
        }

        private static Guide FindWithVal(string val)
        {
            Guide guide= new();
            foreach (var item in GuideList)
            {
                if(item.Name==val || item.Surname==val)
                    guide = item;
            }
            return guide;
        }

        private static Guide Record()
        {
             Console.WriteLine("Lütfen isim giriniz             : ");
            string name = Console.ReadLine();
             Console.WriteLine("Lütfen soyisim giriniz          : ");
            string surname = Console.ReadLine();
            Console.WriteLine("Lütfen telefon numarası giriniz : ");
            string phone = Console.ReadLine();
            Guide guide= new(name,surname,phone);
            return guide;
        }
    }

    public class Guide
    {
        private string name;
        private string surname;
        private string phone;
        public Guide(){}

        public Guide(string name, string surname, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Phone { get => phone; set => phone = value; }

    }
}

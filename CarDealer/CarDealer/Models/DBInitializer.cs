using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public static class DBInitializer
    {
        public static void Seed(AppDBContext context)
        {
            if (!context.Cars.Any())
            {
                context.AddRange(
                    new Car { Title = "Ford Mustang", Description = "Mam do sprzedania Mustanga 5.0 GT V8 421KM. Kupiony w Polskim SALONIE FORDA w Opolu jako NOWY w kwietniu 2016. cena jaka mnie interesuje to   ", PhotoUrl = "/images/fordMustang.jpg", MiniaturePhotoUrl = "/images/fordMustang.jpg" },
                    new Car { Title = "Audi S5", Description = "Do sprzedania Audi S5 z 2013 roku. Jestem właścicielem tego samochodu od ponad dwóch lat.", PhotoUrl = "/images/audiS5.jpg", MiniaturePhotoUrl = "/images/audiS5.jpg" },
                    new Car { Title = "BMV X4", Description = "BMV X4 20d xDrive. Samochód krajowy. Samochód serwisowany. Wystawiamy fakturę VAT 23%. Samochód bezwypadkowy. I właściciel.", PhotoUrl = "/images/bmvx4.jpg", MiniaturePhotoUrl = "/images/bmvx4.jpg" },
                    new Car { Title = "Chevrolet Corvette", Description = "Corvetta jest w świetnym stanie wizualnym i mechanicznym. Oczywiście jest ZAREJESTROWANA i ubezpieczona w PL.", PhotoUrl = "/images/chevroletCorvete.jpg", MiniaturePhotoUrl = "/images/chevroletCorvete.jpg" },
                    new Car { Title = "Nissan Skyline", Description = "Na sprzedaż trafia moja perełka Nissan Skyline R33.Auto z Japonii sprowadzone do Szwecji, gdzie było przez wiele lat modyfikowane, uczestniczyło w zlotach, zdobywało nagrody, samochód sponsorowany latami przez Sonax Sweden.", PhotoUrl = "/images/nissan.jpg", MiniaturePhotoUrl = "/images/nissan.jpg", },
                    new Car { Title = "Jaguar ZX", Description = "Przedstawiam Państwu wyjątkowe auto jakim jest Jaguar XKR, a zwłaszcza ten egzemplarz. Jaguar XKR to ikona światowej i brytyjskiem motoryzacji, a przede wszystkim kontynuator legendarnego już Jaguara E-typa, przez wielu uważany za najpiękniejsze auto w historii motoryzacji.", PhotoUrl = "/images/jaguar.jpg", MiniaturePhotoUrl = "/images/jaguar.jpg" }
                );
            }
            context.SaveChanges();
        }
    }
}

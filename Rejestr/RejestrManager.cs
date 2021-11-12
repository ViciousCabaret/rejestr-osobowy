using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejestr
{
    public class RejestrManager : IManager
    {

        public void Add()
        {
            User user = new User();
            try
            {
                setCommonFields(user);
                using (DataContext db = new DataContext())
                {
                    db.Add(user);
                    db.SaveChanges();
                }
            } catch (Exception ex)
            {
                return;
            }
        }

        public void List()
        {
            using (DataContext db = new DataContext())
            {
                var users = db.Users;
                foreach (User user in users)
                {
                    Console.WriteLine("Id: " + user.Id);
                    Console.WriteLine("Imie: " + user.Name);
                    Console.WriteLine("Nazwisko: " + user.Surname);
                    Console.WriteLine("Wiek: " + user.Age);
                    if (user.Gender != null)
                    {
                        Console.WriteLine("Płeć" + User.genderMap[(int)user.Gender]);
                    }
                    Console.WriteLine("Kod pocztowy: " + user.PostalCode);
                    Console.WriteLine("Miasto: " + user.City);
                    Console.WriteLine("Ulica: " + user.Street);
                    Console.WriteLine("Numer domu: " + user.HouseNumber);
                    Console.WriteLine("Numer mieszkania: " + user.ApartmentNumber);
                    Console.WriteLine("------------------");

                }
            }
        }

        public void Edit(int userId)
        {
            using (DataContext db = new DataContext())
            {
                User? user = db.Users.Find(userId);
                if (user == null)
                {
                    Console.WriteLine("Nie znaleziono użytkownika");
                    return;
                }
                try
                {
                    setCommonFields(user);
                    db.Update(user);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        public void Delete(int userId)
        {
            using (DataContext db = new DataContext())
            {
                User? user = db.Users.Find(userId);
                if (user == null)
                {
                    Console.WriteLine("Nie znaleziono użytkownika");
                    return;
                }
                db.Remove(user);
                db.SaveChanges();
            }
        }

        private static void setCommonFields(User user)
        {
            Console.WriteLine("Podaj imie");
            user.Name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko");
            user.Surname = Console.ReadLine();
            Console.WriteLine("Podaj wiek");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Wiek musi być liczbą");
                throw new Exception();
            }
            user.Age = age;
            Console.WriteLine("Podaj płeć:");
            Console.WriteLine("1 - mężczyzna");
            Console.WriteLine("2 - kobieta");
            Console.WriteLine("3 - inne");

            if (!int.TryParse(Console.ReadLine(), out int gender)
                || (gender != 1 && gender != 2 && gender != 3))
            {
                Console.WriteLine("Nieprawidłowa płeć");
                throw new Exception();
            }
            user.Gender = gender;
            Console.WriteLine("Podaj kod pocztowy");
            user.PostalCode = Console.ReadLine();
            Console.WriteLine("Podaj miasto");
            user.City = Console.ReadLine();
            Console.WriteLine("Podaj Ulice");
            user.Street = Console.ReadLine();
            Console.WriteLine("Podaj numer domu");
            user.HouseNumber = Console.ReadLine();
            Console.WriteLine("Podaj numer mieszkania");
            user.ApartmentNumber = Console.ReadLine();
        }

    }
}

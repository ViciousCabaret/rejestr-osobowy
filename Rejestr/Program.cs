using System;

namespace Rejestr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aplikacja Rejestr osobowy");
            var exit = false;
            RejestrManager manager = new RejestrManager();
            do
            {
                Console.WriteLine("Wybierz opcje:");
                Console.WriteLine("1. Wyświetl rejestr osobowy");
                Console.WriteLine("2. Dodaj wpis do rejestru");
                Console.WriteLine("3. Edytuj wpis w rejestrze");
                Console.WriteLine("4. Usuń wpis z rejestru");
                Console.WriteLine("0. Opuść program");
                var option = Console.ReadLine();
                Console.Clear();
                switch (option)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        manager.List();
                        break;
                    case "2":
                        manager.Add();
                        break;
                    case "3":
                        Console.WriteLine("Podaj id użytkownika");
                        if (!int.TryParse(Console.ReadLine(), out int i))
                        {
                            Console.WriteLine("UserId musi byc wartoscia liczbowa");
                            break;
                        }
                        manager.Edit(i);
                        break;
                    case "4":
                        Console.WriteLine("Podaj id użytkownika");
                        if (!int.TryParse(Console.ReadLine(), out int j))
                        {
                            Console.WriteLine("UserId musi byc wartoscia liczbowa");
                            break;
                        }
                        manager.Delete(j);
                        break;
                    default:
                        Console.WriteLine("Nie ma takiej opcji");
                        break;
                }

            } while (exit == false);
        }
    }
}
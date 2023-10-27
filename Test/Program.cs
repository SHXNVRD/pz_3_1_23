﻿namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    // создаем два объекта User
                    User user1 = new User { Name = "Tom", Age = 33 };
                    User user2 = new User { Name = "Alice", Age = 26 };

                    // добавляем их в бд
                    db.Users.AddRange(user1, user2);
                    db.SaveChanges();
                    // получаем объекты из бд и выводим на консоль
                    var users = db.Users.ToList();
                    Console.WriteLine("Users list:");
                    foreach (User u in users)
                    {
                        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                    }
                }
            }
            catch (Exception)
            { 
                Console.WriteLine("Ошибка!");
                throw;
            }
        }
    }
}
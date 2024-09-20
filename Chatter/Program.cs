using System;
using System.Collections.Generic;

namespace Chatter 
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MessagesDbContext())
            {
                while (true)
                {
                    Console.WriteLine("\nEnter the number of the action you wish to perform:");
                    Console.WriteLine("1: Send a message");
                    Console.WriteLine("2: View messages");
                    Console.WriteLine("3: Quit program");
                    string? action = Console.ReadLine();

                    if (action == "1")
                    {
                        Console.WriteLine("\nEnter your name");
                        string? sender = Console.ReadLine();

                        Console.WriteLine("\nEnter the recipient's name");
                        string? recipient = Console.ReadLine();

                        Console.WriteLine("\nEnter the message you want to send");
                        string? content = Console.ReadLine();

                        var message = new Message
                        {
                            Sender = sender,
                            Recipient = recipient,
                            Content = content,
                        };

                        db.Messages.Add(message);
                        db.SaveChanges();

                        Console.WriteLine("Message sent!");
                    }
                    else if (action == "2")
                    {
                        Console.WriteLine("\nEnter your name to view messages.");
                        string? user = Console.ReadLine();

                        var messages = db.Messages.Where(m => m.Recipient == user).ToList();

                        Console.WriteLine("\nBelow are your messages:");
                        foreach (var message in messages)
                        {
                            Console.WriteLine($"{message.Content} from {message.Sender}");
                        }

                    }
                    else if (action == "3")
                    {
                        Console.WriteLine("Quitting program...");
                        break;
                    } 
                    else 
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }
        }
    }
}

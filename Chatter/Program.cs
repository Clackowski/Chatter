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
                bool again = true;
                while (again)
                {
                    Console.WriteLine("\nEnter the number of the action you wish to perform:");
                    Console.WriteLine("1: Send a message");
                    Console.WriteLine("2: View messages");
                    Console.WriteLine("3: Quit program");
                    string? action = Console.ReadLine();

                    switch (action)
                    {
                        case "1":
                            Console.WriteLine("\nEnter your name");
                            string? sender = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(sender))
                            {
                                Console.WriteLine("Sender cannot be empty.");
                                break;
                            }

                            Console.WriteLine("\nEnter the recipient's name");
                            string? recipient = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(recipient))
                            {
                                Console.WriteLine("Recipient cannot be empty.");
                                break;
                            }

                            Console.WriteLine("\nEnter the message you want to send");
                            string? content = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(content))
                            {
                                Console.WriteLine("Message cannot be empty.");
                                break;
                            }

                            var message = new Message
                            {
                                Sender = sender,
                                Recipient = recipient,
                                Content = content,
                            };

                            db.Messages.Add(message);
                            db.SaveChanges();

                            Console.WriteLine("Message sent!");
                            break;

                        case "2":
                            Console.WriteLine("\nEnter your name to view messages.");
                            string? user = Console.ReadLine();

                            var messages = db.Messages.Where(m => m.Recipient == user).ToList();

                            Console.WriteLine("\nBelow are your messages:");
                            foreach (var msg in messages)
                            {
                                Console.WriteLine($"{msg.Content} from {msg.Sender}");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Quitting program...");
                            again = false;
                            break;
                        
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Chatter 
{
    class Program
    {
        static void Main(string[] args)
        {
            // <username, list of messages>
            var users = new Dictionary<string, List<string>>();
            string? currentUser = null;

            while (true)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("\nEnter a username to log in or type 'exit' to quit");
                    string username = Console.ReadLine();

                    if (username.ToLower() == "exit")
                    {
                        break;
                    }
                
                    if (!users.ContainsKey(username))
                    {
                        users[username] = new List<string>();
                    }

                    currentUser = username;
                    Console.WriteLine($"Welcome {username}!");
                }
                else {
                    Console.WriteLine("\nEnter the number of the action you wish to perform:");
                    Console.WriteLine("1: Send a message");
                    Console.WriteLine("2: View messages");
                    Console.WriteLine("3: Logout");
                    Console.WriteLine("4: Quit program");
                    string action = Console.ReadLine();

                    if (action == "1")
                    {
                        Console.WriteLine("\nEnter a message to send.");
                        string? message = Console.ReadLine();

                        Console.WriteLine("\nWho do you want to send the message to?");
                        string? recipient = Console.ReadLine();

                        if (!users.ContainsKey(recipient))
                        {
                            Console.WriteLine("This user does not exist");
                            continue;
                        }

                        message += $" ~ from {currentUser}";

                        var messages = users[recipient];
                        messages.Add(message);

                        Console.WriteLine($"Message sent to {recipient}.");
                    }
                    else if (action == "2")
                    {
                        Console.WriteLine("\nDisplaying messages...");
                        foreach (var message in users[currentUser])
                        {
                            Console.WriteLine(message);
                        }
                    }
                    else if (action == "3")
                    {
                        currentUser = null;
                        Console.WriteLine("Logged out.");
                        continue;
                    }
                    else if (action == "4")
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

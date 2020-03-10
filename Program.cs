using System;

namespace scoreboard_service
{
    class Program
    {
        static void Main(string[] args)
        {
            Scoreboard scoreboard = new Scoreboard();
            bool running = true;

            Console.WriteLine("Welcome to the Scoreboard program. Following commands are available:\nadd $name $score\nprint\nquit");

            while (running)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                int value;
                switch (parts[0]) 
                {
                    case "add":
                        if (parts.Length < 3 || !int.TryParse(parts[2], out value))
                        {
                            Console.WriteLine("Invalid input, try {add $name $score}, {print} or {quit}.");
                            break;
                        }
                        scoreboard.Add(parts[1], int.Parse(parts[2]));
                        Console.WriteLine("Score successfully added!");
                        break;
                    case "print":
                        scoreboard.Print();
                        break;
                    case "quit":
                        running = false;
                        Console.WriteLine("Quitting ...");
                        break;
                    default:
                        Console.WriteLine("Invalid input, try {add $name $score}, {print} or {quit}.");
                        break;

                }
            }
        }
    }
}

using System;

namespace SF.Module19
{
    class Program
    {
        static void Main()
        {
            var botWorker = new BotWorker().Initialize().Start();

            Console.WriteLine("Напишите stop для прекращения работы");

            string command;
            do
            {
                command = Console.ReadLine();

            } while (command != "/stop");

            botWorker.Stop();
            // pdnSkillFactoryBot
        }
    }

    public static class BotCredentials
    {
        public static readonly string BotToken = "1613925815:AAE6RUKmYRTO2fO8AYbHVDBxQXPjVruEAnY";
    }
}

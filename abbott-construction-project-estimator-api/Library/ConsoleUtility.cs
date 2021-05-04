using System;
using System.Text;

namespace ProjectEstimator.Api.Library
{
    public static class ConsoleUtility
    {
        public static string GetHiddenConsoleInput()
        {
            var input = new StringBuilder();
            
            while (true)
            {
                var key = Console.ReadKey(true);
                
                if (key.Key == ConsoleKey.Enter)
                    break;
                
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace)
                    input.Append(key.KeyChar);
            }

            return input.ToString();
        }
    }
}
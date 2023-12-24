using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp.Utils
{
    public class RandomID
    {
        public static string Generate()
        {
            const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            System.Text.StringBuilder randomIdBuilder = new System.Text.StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                char randomChar = characters[random.Next(characters.Length)];

                randomIdBuilder.Append(randomChar);
            }

            return randomIdBuilder.ToString();
        }
    }
}


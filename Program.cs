using System;

namespace Шифр_Виженера
{
    class Program
    {
        static string GetKey(string key, int length)
        {
            int i = 0;
            while (key.Length < length)
            {
                int keyLength = key.Length;
                key += key[i];
                i++;
                if (i == keyLength)
                {
                    i = 0;
                }
            }
            return key;
        }

        static string Shiffering(string key, string message)
        { 
            string newMessage = string.Empty;
            int newChar;
            int a = 0;

            message = message.ToLower();
            key = key.ToLower();
            key = GetKey(key, message.Length);
            for (int k = 0; k < message.Length; k++)
            {
                if (message[k] > 'z' || message[k] < 'a')
                {
                    newMessage += message[k];
                    a++;
                }
                else
                {
                    newChar = Convert.ToInt32(key[k-a]) + Convert.ToInt32(message[k]) - 96*2 - 1;
                    if (newChar > 26)
                    {
                        newChar -= 26;
                    }
                    newChar += +96;
                    newMessage += Convert.ToChar(newChar);
                }
            }
            return newMessage;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст который хотите зашифровать шифром Виженера");
            string message = Console.ReadLine();
            Console.WriteLine("Введите ключ");
            string key = Console.ReadLine();
            Console.WriteLine(Shiffering(key, message));
        }
    }
}

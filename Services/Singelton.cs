using System;

namespace IntroToAspNetCore_Cooked.Services
{
    public class Singelton
    {
        public int Count { get; set; }

        public void IncreaseCount()
        {
            Count += 1;
            Console.WriteLine($"{nameof(Singelton)} ---------- {Count}");
        }
    }
}
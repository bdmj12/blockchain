using System;

namespace Blockchain
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Hash.GetHashSha256("Hello!"));
        }
    }
}

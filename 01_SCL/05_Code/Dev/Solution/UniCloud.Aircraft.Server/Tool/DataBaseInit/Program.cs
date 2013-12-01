using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseInit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Guid());
            Console.Write(Guid.NewGuid());
            Console.Read();
        }
    }
}

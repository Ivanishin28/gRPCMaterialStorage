using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    public class Application : IDisposable
    {
        public void Start()
        {
            Console.WriteLine("Hello World!");
        }

        public void Dispose()
        {
            Console.WriteLine("Goodbye World!");
        }
    }
}

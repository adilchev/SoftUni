using System;
using SIS.MvcFramework;

namespace TorshiaExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}

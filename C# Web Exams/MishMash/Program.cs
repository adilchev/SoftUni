using System;
using SIS.MvcFramework;

namespace MishMashExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}

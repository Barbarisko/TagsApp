using System;
using TagsApp.Fabric_Method;

namespace TagsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Core core = Core.GetInstance();
            core.Init();
            core.MainLoop();
        }
    }
}

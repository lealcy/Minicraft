using System;

namespace Minicraft
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Minicraft mc = new Minicraft (100, 100);
            for (int i = 20; i < 50; i++) {
                mc.Blocks [i] [20] = new DirtBlock ();
            }
            mc.Blocks [30] [5] = new SandBlock ();

            mc.Run ();
        }
    }
}

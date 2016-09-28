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
            mc.Blocks [30] [6] = new SandBlock ();
            mc.Blocks [30] [5] = new SandBlock ();
            mc.Blocks [31] [6] = new SandBlock ();
            mc.Blocks [31] [5] = new SandBlock ();
            mc.Blocks [32] [6] = new SandBlock ();
            mc.Blocks [32] [5] = new SandBlock ();
            mc.Blocks [30] [8] = new SandBlock ();
            mc.Blocks [30] [9] = new SandBlock ();
            mc.Blocks [31] [8] = new SandBlock ();
            mc.Blocks [31] [9] = new SandBlock ();
            mc.Blocks [32] [8] = new SandBlock ();
            mc.Blocks [32] [9] = new SandBlock ();

            mc.Run ();
        }
    }
}

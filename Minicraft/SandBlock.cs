using System;

namespace Minicraft
{
    public class SandBlock : Block
    {
        public SandBlock ()
        {
            Solid = true;
            GravityEnabled = true;
            Color = ConsoleColor.DarkYellow;
        }

    }
}


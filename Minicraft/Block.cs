using System;

namespace Minicraft
{
    public class Block
    {
        public ConsoleColor Color;
        public bool Solid = false;
        public bool GravityEnabled = false;
        public int LastUpdate = 0;

        public Block ()
        {
            Color = ConsoleColor.DarkCyan;
        }

        public virtual void Update(Minicraft mc, int x, int y) {
            if (LastUpdate < mc.UpdateCount) {
                if (GravityEnabled) {
                    mc.MoveDown (x, y);
                }
                LastUpdate = mc.UpdateCount;
            }
        }

        public virtual void Draw(int x, int y) {
            Console.SetCursorPosition (x, y);
            Console.BackgroundColor = Color;
            Console.WriteLine (' ');
        }
    }
}


using System;

namespace Minicraft
{
    public class Block
    {
        public ConsoleColor Color;
        public bool Solid = false;
        public bool GravityEnabled = false;
        public int count = 0;

        public Block ()
        {
            Color = ConsoleColor.DarkCyan;
        }

        public virtual void Update(Minicraft mc, int x, int y) {
            if (GravityEnabled) {
                mc.StatusMessage (string.Format ("count: {0}, dt: {1}", count, mc.DeltaTimeMS));
                count++;
                mc.MoveDown (x, y);
            }
        }

        public virtual void Draw(Minicraft mc, int x, int y) {
            Console.SetCursorPosition (x, y);
            Console.BackgroundColor = Color;
            Console.WriteLine (' ');
        }
    }
}


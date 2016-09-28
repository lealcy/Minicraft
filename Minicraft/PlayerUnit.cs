using System;

namespace Minicraft
{
    public class PlayerUnit : UnitBlock
    {
        public PlayerUnit ()
        {
        }

        override public void Update(Minicraft mc, int x, int y) {
            if (LastUpdate < mc.UpdateCount) {
                if (Console.KeyAvailable) {
                    switch (Console.ReadKey (true).Key) {
                    case ConsoleKey.UpArrow:
                        if (mc.GetBlock (x, y + 1).Solid == true) {
                            mc.MoveUp (x, y);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        mc.MoveRight (x, y);
                        break;
                    case ConsoleKey.LeftArrow:
                        mc.MoveLeft (x, y);
                        break;
                    }
                }
                if (GravityEnabled) {
                    mc.MoveDown (x, y);
                }
                LastUpdate = mc.UpdateCount;
            }
        }

        override public void Draw(int x, int y) {
            Console.SetCursorPosition (x, y);
            Console.Write ("\uD800\uDDD4");
        }
    }
}


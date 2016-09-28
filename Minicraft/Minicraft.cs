using System;
using System.Threading;
using System.Diagnostics;

namespace Minicraft
{
    public class Minicraft
    {
        public int Width;
        public int Height;
        public Block[][] Blocks;
        public int CameraX;
        public int CameraY;
        public Stopwatch Stopwatch;
        public int DeltaTimeMS = 0;
        public int UpdateSpeed = 100; // Millisconds
        private int elapsedTimeBetweenUpdates = 0;
        public int UpdateCount = 0;
        private int drawCount = 0;


        public Minicraft (int width, int height)
        {
            Width = width;
            Height = height;
            Blocks = new Block[Width][];
            for (int x = 0; x < Width; x++) {
                Blocks [x] = new Block[Height];
                for (int y = 0; y < Height; y++) {
                    Blocks [x] [y] = new Block ();
                }
            }
            CameraX = 0;
            CameraY = 0;
            Console.CursorVisible = false;
            Stopwatch = new Stopwatch ();
        }

        public void Update ()
        {
            elapsedTimeBetweenUpdates += DeltaTimeMS;
            if (elapsedTimeBetweenUpdates < UpdateSpeed) {
                return;
            }
            elapsedTimeBetweenUpdates -= UpdateSpeed;
            UpdateCount++;
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    Blocks [x] [y].Update (this, x, y);
                }
            }
        }

        public void Draw ()
        {
            drawCount++;
            Console.ResetColor ();
            for (int x = CameraX; x - CameraX < Console.WindowWidth; x++) {
                for (int y = CameraY; y - CameraY < Console.WindowHeight - 1; y++) {
                    Blocks [x] [y].Draw (x - CameraX, y - CameraY);
                }
            }

        }

        public void Run ()
        {
            Stopwatch.Start ();
            long timeAtPreviousFrame = Stopwatch.ElapsedMilliseconds;
            while (true) {
                DeltaTimeMS = (int)(Stopwatch.ElapsedMilliseconds - timeAtPreviousFrame);
                timeAtPreviousFrame = Stopwatch.ElapsedMilliseconds;
                Update ();
                Draw ();
                Thread.Sleep (5);
            }
        }

        public Block GetBlock(int x, int y) {
            if (x >= 0 && x < Width && y >= 0 && y < Height) {
                return Blocks [x] [y];
            }
            return new BedRockBlock ();
        }

        public void MoveUp(int x, int y) {
            if (y > 0 && Blocks[x][y - 1].Solid == false) {
                Blocks [x] [y - 1] = Blocks [x] [y];
                Blocks [x] [y] = new Block ();
            }
        }

        public void MoveRight(int x, int y) {
            if (x < Height - 1 && Blocks[x + 1][y].Solid == false) {
                Blocks [x + 1] [y] = Blocks [x] [y];
                Blocks [x] [y] = new Block ();
            }
        }

        public void MoveDown(int x, int y) {
            if (y < Width - 1 && Blocks[x][y + 1].Solid == false) {
                Blocks [x] [y + 1] = Blocks [x] [y];
                Blocks [x] [y] = new Block ();
            }
        
        }

        public void MoveLeft(int x, int y) {
            if (x > 0 && Blocks[x - 1][y].Solid == false) {
                Blocks [x - 1] [y] = Blocks [x] [y];
                Blocks [x] [y] = new Block ();
            }
        }

        public void StatusMessage(string msg) {
            Console.SetCursorPosition (0, Console.WindowHeight - 1);
            Console.Write (msg);
        }

    }
}


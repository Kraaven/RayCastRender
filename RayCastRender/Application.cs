using System.Numerics;
using Raylib_cs; // Import the Raylib library

class Program
{
    static void Main()
    {
        Raylib.InitWindow(800, 600, "Raylib C# - Simple Window");
        
        Raylib.SetTargetFPS(60);

        var Img = Raylib.LoadImage(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Images" + Path.DirectorySeparatorChar +
                         "Default.png");
        //Console.WriteLine($"Height: {Img.Height} Width: {Img.Width}");
        Vector2 Specs = new Vector2(Img.Width, Img.Height);
        Console.WriteLine($"Specs: {Specs}");

        Color[] Pixels = new Color[(int)(Specs.X * Specs.Y)];

        for (int i = 0; i < Specs.X; i++)
        {
            for (int j = 0; j < Specs.Y; j++)
            {
                Pixels[j * (int)Specs.X + i] = Raylib.GetImageColor(Img, i, j);
                if (Pixels[j * (int)Specs.X + i].Equals(Color.Black))
                {
                    Pixels[j * (int)Specs.X + i] = Color.Red;
                }
                else
                {
                    Pixels[j * (int)Specs.X + i] = Color.White;
                }
            }
        }

        Vector2 InitPosition;
        Random rand = new Random();
        do
        {
            InitPosition = new Vector2(rand.Next((int)Specs.X), rand.Next((int)Specs.Y));
        } while (Pixels[(int)(InitPosition.Y * Specs.X + InitPosition.X)].Equals(Color.Black));

        Console.WriteLine($"Init Position is {InitPosition}");

        Vector2 Center = new Vector2(400, 300);
        Console.WriteLine($"Center: {Center}");
        
        File.WriteAllText(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "ImagArray",string.Join(',',Pixels));
        
        int CX = 10;
        int CY = 10;
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            // Raylib.DrawText("Hello, Raylib!", 350, 280, 20, Color.DarkGray);
            
            // for (int i = 0; i < Specs.X-1; i++)
            // {
            //     for (int j = 0; j < Specs.Y-1; j++)
            //     {
            //        //Raylib.DrawPixel(i,j,Pixels[(int)(Specs.X * i) + j]);
            //        Raylib.DrawPixel(i+25,j+25,Pixels[j * (int)Specs.X + i]);
            //     }
            // }

            

            for (int i = CX*-1; i < CX; i++)
            {
                for (int j = CY*-1; j < CY; j++)
                {
                    if(i==0 && j==0 ) continue;
                    Vector2 Direction = new Vector2(i,j);
                    Vector2 Ray = new Vector2(i, j);
                    do
                    {
                        //Console.WriteLine(Ray.Length());
                        Raylib.DrawPixel((int)(Ray.X + Center.X),(int)(Ray.Y + Center.Y), Color.Black);
                        Ray += Direction;
                    
                    } while (Ray.Length() < 400);
                    // Console.WriteLine("Drew Ray");
                }
            }

            if (Raylib.IsKeyDown(KeyboardKey.Left)) CX--;
            if (Raylib.IsKeyDown(KeyboardKey.Right)) CX++;
            if (Raylib.IsKeyDown(KeyboardKey.Down)) CY--;
            if (Raylib.IsKeyDown(KeyboardKey.Up)) CY++;
            
            // Console.WriteLine("Drew all rays");
            
            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
    }
}
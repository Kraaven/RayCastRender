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

        Color[] Pixels = new Color[(int)(Specs.X*Specs.Y)];

        for (int i = 0; i < Specs.X-1; i++)
        {
            for (int j = 0; j < Specs.Y-1; j++)
            {
                Pixels[j * (int)Specs.X + i] = Raylib.GetImageColor(Img, i, j);
                if (Pixels[j * (int)Specs.X + i].GetHashCode() == Color.Black.GetHashCode())
                {
                    Pixels[j * (int)Specs.X + i] = Color.Red;
                }
                else
                {
                    Pixels[j * (int)Specs.X + i] = Color.White;
                }
            }
        }   
        
        File.WriteAllText(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "ImagArray",string.Join(',',Pixels));
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            // Raylib.DrawText("Hello, Raylib!", 350, 280, 20, Color.DarkGray);
            
            for (int i = 0; i < Specs.X-1; i++)
            {
                for (int j = 0; j < Specs.Y-1; j++)
                {
                   //Raylib.DrawPixel(i,j,Pixels[(int)(Specs.X * i) + j]);
                   Raylib.DrawPixel(i+25,j+25,Pixels[j * (int)Specs.X + i]);
                }
            }
            
            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
    }
}
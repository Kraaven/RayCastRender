using Raylib_cs; // Import the Raylib library

class Program
{
    static void Main()
    {
        Raylib.InitWindow(800, 600, "Raylib C# - Simple Window");
        
        Raylib.SetTargetFPS(60);
        while (!Raylib.WindowShouldClose()) // Check if the window should close
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Hello, Raylib!", 350, 280, 20, Color.DarkGray);
            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
    }
}
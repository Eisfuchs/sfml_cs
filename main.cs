using System;
using System.Diagnostics;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace sfml_cs
{
    public class main
    {
        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public static void Main() 
        {
            /*
            RenderWindow window = new RenderWindow(new VideoMode(200, 200), "SFML works!");
            
            Console.WriteLine("test");
            Console.ReadKey();
            */

            // Create the main window
	        RenderWindow window = new RenderWindow(new VideoMode(800, 600), "SFML window");
            window.Closed += new EventHandler(OnClose);
            
	        // Load a sprite to display
	        Texture texture = new Texture("media/image/mario.png");
	        Sprite sprite = new Sprite(texture);

	        // Create a graphical text to display
	        Font font = new Font("media/font/arial.ttf");
	        Text text = new Text("Hello SFML", font, 50);
	        
            // Load & play music
            Music music = new Music("media/sound/mario.ogg");
	        music.Play();
	
	        // starts the Stopwatch
	        Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

	        // last mouse position
	        Vector2i last_mouse_position = new Vector2i(0, 0);
            
	        // Start the game loop
	        while (window.IsOpen())
	        {
		        // Process events
	            window.DispatchEvents();

                float speed = 0.1f * Convert.ToSingle(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();
                stopwatch.Start();
		        
		        if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
		        {
			        sprite.Position = new Vector2f(sprite.Position.X, sprite.Position.Y - speed);
		        }
		        if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
		        {
			        sprite.Position = new Vector2f(sprite.Position.X, sprite.Position.Y + speed);
		        }
		        if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
		        {
			        sprite.Position = new Vector2f(sprite.Position.X - speed, sprite.Position.Y);
		        }
		        if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
		        {
			        sprite.Position = new Vector2f(sprite.Position.X + speed, sprite.Position.Y);
		        }
		        
		        // only if its a new mouse position
		        if (!last_mouse_position.Equals(Mouse.GetPosition()))
		        {
			        if (Mouse.IsButtonPressed(Mouse.Button.Left))
			        {
				        Console.WriteLine("Klick Maustaste: Links; X: " + Mouse.GetPosition().X 
					        + "; Y: " + Mouse.GetPosition().X);
				        last_mouse_position = Mouse.GetPosition();
			        }
			        if (Mouse.IsButtonPressed(Mouse.Button.Middle))
			        {
                        Console.WriteLine("Klick Maustaste: Mitte; X: " + Mouse.GetPosition().X 
					        + "; Y: " + Mouse.GetPosition().X);
				        last_mouse_position = Mouse.GetPosition();
			        }
			        if (Mouse.IsButtonPressed(Mouse.Button.Right))
			        {
                        Console.WriteLine("Klick Maustaste: Rechts; X: " + Mouse.GetPosition().X 
					        + "; Y: " + Mouse.GetPosition().X);
				        last_mouse_position = Mouse.GetPosition();
			        }
		        }
		        
                // Clear screen
                window.Clear();

                // Draw the sprite
                window.Draw(sprite);

                // Draw the string
                window.Draw(text);

                // Update the window
                window.Display();
	        }
        }
    }
}

using System.Drawing;

namespace BadApple
{
    internal class Program
    {
        static bool VideoPlaying = true;
        static double frameRate = 30.0;  // 30 frames per second
        static double frameDuration = 1.0 / frameRate;  // Duration of each frame in seconds
        static void Main(string[] args)
        {
            int frameCount = 1;
            double previousTime = DateTime.Now.TimeOfDay.TotalSeconds;

            string ImagePath = "C:/path/to/your/frames/folder/frame_" + frameCount.ToString("D4") + ".jpg";

            while (VideoPlaying)
            {
                // Gets time needed to display frame in terminal
                double currentTime = DateTime.Now.TimeOfDay.TotalSeconds;
                double elapsedTime = currentTime - previousTime;

                ImagePath = "C:/path/to/your/frames/folder/frame_" + frameCount.ToString("D4") + ".jpg";

                // If enough time has passed, display the next frame
                if (elapsedTime >= frameDuration)
                {
                    if (!File.Exists(ImagePath))
                    {
                        // Stops video once next frame does not exist
                        VideoPlaying = false;
                        break;
                    }
                    else
                    {
                        // Display frame
                        string AsciiArt = AsciiConverter.ConvertImageToAscii(ImagePath, 90);
                        Console.WriteLine(AsciiArt);

                        // Update the time for the next frame
                        previousTime = currentTime;
                        frameCount++;
                    }   
                }
            }
        }
    }
}

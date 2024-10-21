using System.Drawing;
using System.Text;

namespace BadApple
{
    class AsciiConverter
    {
        // Define the ASCII characters set to represent grayscale levels
        static readonly char[] asciiChars = { '@', '#', 'S', '%', '?', '*', '+', ';', ':', ',', '.' }; // ! From "Most filled" to "Least filled" !

        // Method to map grayscale values to ASCII characters
        static char MapPixelToAscii(int grayValue)
        {
            int scale = 255 / (asciiChars.Length - 1);  // Divide 255 grayscale based on lenght of ASCII chars
            int index = grayValue / scale;
            return asciiChars[index];
        }

        // Convert image to ASCII art
        public static string ConvertImageToAscii(string imagePath, int outputWidth)
        {
            // Create bitmap to get dimensions
            Bitmap image = new Bitmap(imagePath);

            // Calculate aspect ratio 
            double aspectRatio = (double)image.Height / image.Width;
            int outputHeight = (int)(outputWidth * aspectRatio);

            StringBuilder asciiArt = new StringBuilder();

            // Loop through pixels, resize the image based on output dimensions
            for (int y = 0; y < outputHeight; y++)
            {
                for (int x = 0; x < outputWidth; x++)
                {
                    // Map pixel position in resized output to original image dimensions
                    int originalX = x * image.Width / outputWidth;
                    int originalY = y * image.Height / outputHeight;

                    // Get pixel color and convert it to grayscale
                    Color pixelColor = image.GetPixel(originalX, originalY);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    // Map grayscale value to an ASCII character via MapPixelToAscii and append it
                    asciiArt.Append(MapPixelToAscii(grayValue));
                }

                // After each row, append a newline character
                asciiArt.AppendLine();
            }
            return asciiArt.ToString();
        }
    }
}

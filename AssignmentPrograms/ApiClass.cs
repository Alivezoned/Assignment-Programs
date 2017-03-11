using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Drawing;

namespace AssignmentPrograms
{
    class ApiClass
    {

        public int GetCurrency()
        {
            /* Currency API for USD -> INR
             * http://query.yahooapis.com/v1/public/yql?q=select%20%2a%20from%20yahoo.finance.xchange%20where%20pair%20in%20%28%22USDEUR%22,%20%22USDINR%22,%20%22USDISK%22%29&env=store://datatables.org/alltableswithkeys
             * */
            try
            {
                String url = @"http://query.yahooapis.com/v1/public/yql?q=select%20%2a%20from%20yahoo.finance.xchange%20where%20pair%20in%20%28%22USDEUR%22,%20%22USDINR%22,%20%22USDISK%22%29&env=store://datatables.org/alltableswithkeys";

                Console.WriteLine("Loading ... ");

                XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
                xmlDoc.Load(url); // Load the XML document from the specified file

                // Get elements
                XmlNodeList Name = xmlDoc.GetElementsByTagName("Name");
                XmlNodeList Rate = xmlDoc.GetElementsByTagName("Rate");

                // Result
                Console.WriteLine("Current Rate:- 1$ = " + Rate[1].InnerText + " Rupees");
                Console.WriteLine("___________________");

                float ExactRate = float.Parse(Rate[1].InnerText.ToString());
                int rate = Convert.ToInt32(ExactRate);

                return rate;
            }
            catch (Exception ex)
            {
                String line = "________________________________";
                Console.WriteLine(ex.Message);
                Console.WriteLine(line);
                Console.WriteLine(line);
                Console.WriteLine(ex.StackTrace.ToString());
                Console.WriteLine(line);
                Console.WriteLine(line);
                Console.WriteLine(ex.TargetSite.ToString());
                Console.WriteLine(line);
                Console.WriteLine(line);
                Console.WriteLine(ex.Source.ToString());

                return 0;
            }
        }


        private const string BLACK = "@";
        private const string CHARCOAL = "#";
        private const string DARKGRAY = "8";
        private const string MEDIUMGRAY = "&";
        private const string MEDIUM = "o";
        private const string GRAY = ":";
        private const string SLATEGRAY = "*";
        private const string LIGHTGRAY = ".";
        private const string WHITE = " ";

        private static string getGrayShade(int redValue)
        {
            string asciival = " ";

            if (redValue >= 230)
            {
                asciival = WHITE;
            }
            else if (redValue >= 200)
            {
                asciival = LIGHTGRAY;
            }
            else if (redValue >= 180)
            {
                asciival = SLATEGRAY;
            }
            else if (redValue >= 160)
            {
                asciival = GRAY;
            }
            else if (redValue >= 130)
            {
                asciival = MEDIUM;
            }
            else if (redValue >= 100)
            {
                asciival = MEDIUMGRAY;
            }
            else if (redValue >= 70)
            {
                asciival = DARKGRAY;
            }
            else if (redValue >= 50)
            {
                asciival = CHARCOAL;
            }
            else
            {
                asciival = BLACK;
            }

            return asciival;
        }

        public static string GrayscaleImageToASCII(System.Drawing.Image img)
        {
            StringBuilder html = new StringBuilder();
            Bitmap bmp = null;

            try
            {
                // Create a bitmap from the image

                bmp = new Bitmap(img);

                // The text will be enclosed in a paragraph tag with the class

                // ascii_art so that we can apply CSS styles to it.

                html.Append("&lt;br/&rt;");

                // Loop through each pixel in the bitmap

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        // Get the color of the current pixel

                        Color col = bmp.GetPixel(x, y);

                        // To convert to grayscale, the easiest method is to add

                        // the R+G+B colors and divide by three to get the gray

                        // scaled color.

                        col = Color.FromArgb((col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3);

                        // Get the R(ed) value from the grayscale color,

                        // parse to an int. Will be between 0-255.

                        int rValue = int.Parse(col.R.ToString());

                        // Append the "color" using various darknesses of ASCII

                        // character.

                        html.Append(getGrayShade(rValue));

                        // If we're at the width, insert a line break

                        if (x == bmp.Width - 1)
                            html.Append("&lt;br/&rt");
                    }
                }

                // Close the paragraph tag, and return the html string.

                html.Append("&lt;/p&rt;");

                return html.ToString();
            }
            catch (Exception exc)
            {
                return exc.ToString();
            }
            finally
            {
                bmp.Dispose();
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public void AsciiArt()
        {
            try
            {
                Image img = Base64ToImage("Dhru");
                String lawl = GrayscaleImageToASCII(img);
                Console.WriteLine(lawl + "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.WriteLine("________");
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
    }
}

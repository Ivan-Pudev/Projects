using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string text = Console.ReadLine();
                string barcodePattern = @"\@\#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])\@\#+";

                Match match = Regex.Match(text, barcodePattern);

                if(!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string barcode = match.Groups["barcode"].Value;
                StringBuilder productGroup = new();

                foreach (char character in barcode)
                {
                    if (char.IsDigit(character))
                    {
                        productGroup.Append(character);
                    }
                }

                if (productGroup.Length == 0)
                {
                    Console.WriteLine($"Product group: 00");
                }
                else
                {
                    Console.WriteLine($"Product group: {productGroup}");
                }
            }
        }
    }
}

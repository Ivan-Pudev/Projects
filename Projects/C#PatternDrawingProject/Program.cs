using System;
using System.Drawing;

class PatternDrawing
{
    static void Main(string[] args)
    {
        while (true) // Loop for restarting the program
        {
            // Step 1: Display a menu to the user
            Console.WriteLine("!!Welcome to the C# Pattern Drawing Program!!");
            Console.WriteLine("Choose a pattern type:");
            Console.WriteLine("1. Right-angled Triangle");
            Console.WriteLine("2. Square with Hollow Center");
            Console.WriteLine("3. Diamond");
            Console.WriteLine("4. Left-angled Triangle");
            Console.WriteLine("5. Hollow Square");
            Console.WriteLine("6. Pyramid");
            Console.WriteLine("7. Reverse Pyramid");
            Console.WriteLine("8. Rectangle with Hollow Center");

            // Step 2: Get the user's choice
            Console.Write("Enter the number corresponding to your choice: ");
            int choice = int.Parse(Console.ReadLine());

            // Step 3: Get dimensions based on choice
            int rows = 0, width = 0, height = 0;

            if (choice >= 1 && choice <= 7)
            {
                // TODO: Prompt the user to enter the number of rows
                Console.Write("Enter the number of rows: ");
                rows = int.Parse(Console.ReadLine());

            }
            else if (choice == 8)
            {

                // TODO: Prompt the user to enter the width and height of the rectangle
                Console.Write("Enter the width: ");
                width = int.Parse(Console.ReadLine());
                Console.Write("Enter the height: ");
                height = int.Parse(Console.ReadLine());

            }
            else
            {
                Console.WriteLine("❌ Invalid choice! Please restart the program.");
                continue;
            }

            // Step 4: Generate the selected pattern
            switch (choice)
            {
                case 1: // Right-angled Triangle
                    
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j <= i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 2: // Square with Hollow Center
                        for (int i = 1; i <= rows; i++)
                        {
                            // Inner loop for columns
                            for (int j = 1; j <= rows; j++)
                            {
                                // Print '*' for the boundary, otherwise print ' '
                                if (i == 1 || i == rows || j == 1 || j == rows)
                                {
                                    Console.Write("*");
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }
                            Console.WriteLine(); // Move to the next row
                        }
                    
                    break;

                case 3: // Diamond
                    int mid = (rows / 2) + 1; // Middle of the diamond

                    // Upper part of the diamond
                    for (int i = 1; i <= mid; i++)
                    {
                        // Print spaces
                        for (int j = i; j < mid; j++)
                        {
                            Console.Write(" ");
                        }

                        // Print asterisks
                        for (int j = 1; j <= (2 * i - 1); j++)
                        {
                            Console.Write("*");
                        }

                        Console.WriteLine();
                    }

                    // Lower part of the diamond
                    for (int i = mid - 1; i >= 1; i--)
                    {
                        // Print spaces
                        for (int j = mid; j > i; j--)
                        {
                            Console.Write(" ");
                        }

                        // Print asterisks
                        for (int j = 1; j <= (2 * i - 1); j++)
                        {
                            Console.Write("*");
                        }

                        Console.WriteLine();
                    }
                        break;

                case 4: // Left-angled Triangle
                      for (int i = 0; i < rows; i++)
                    {
                        for (int j = i; j < rows; j++)
                        {
                            Console.Write("*");
                        }
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 5: // Hollow Square
                    for (int i = 1; i <= rows + 1; i++)
                    {
                        // Inner loop for columns
                        for (int j = 1; j <= rows + 1; j++)
                        {
                            // Print '*' for the boundary, otherwise print ' '
                            if (i == 1 || i == rows + 1 || j == 1 || j == rows + 1)
                            {
                                Console.Write("*");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine(); // Move to the next row
                    }
                    break;

                case 6: // Pyramid

                    int middle = (rows / 2) + 1;

                    for (int i = 0; i <= rows; i++)
                    {
                        for (int j = i; j <= middle; j++)
                        {
                            Console.Write(" ");
                        }

                        for (int j = 1; j <= (2 * i - 1); j++)
                        {
                            Console.Write("*");
                        }

                       for (int j = middle; j <= rows; j++)
                        {
                          Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 7: // Reverse Pyramid !
                    int middleA = (rows / 2) + 1;

                    for (int i = rows; i >= 1; i--)
                    {
                        // Print leading spaces
                        for (int j = middleA; j > i; j--)
                        {
                            Console.Write(" ");
                        }

                        // Print asterisks
                        for (int j = 1; j <= (2 * i - 1); j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 8: // Rectangle with Hollow Center
                    for (int i = 1; i <=height; i++)
                    {
                        // Inner loop for columns
                        for (int j = 1; j <= width; j++)
                        {
                            // Print '*' for the boundary, otherwise print ' '
                            if (i == 1 || i == height || j == 1 || j == width)
                            {
                                Console.Write("*");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine(); // Move to the next row
                    }
                    break;

                default:
                    Console.WriteLine("❌ Invalid choice! Please restart the program.");
                    break;
            }

            // Step 5: Optional - Allow the user to restart or exit
            Console.WriteLine("Do you want to restart the program? (y/n)");
            string restartChoice = Console.ReadLine();
            if (restartChoice.ToLower() != "y")
                break;
        }
    }
}
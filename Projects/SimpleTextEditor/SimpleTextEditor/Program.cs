using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Welcome to the text editor!----");
            /*
             *Open text files: Users can open existing text files and view their contents in the editor.
               Edit text: Users can edit the text in the editor.
               Save text files: Users can save the edited text as a new file or overwrite an existing file.
               Copy, cut, and paste: Users can copy, cut, and paste text within the editor.
               Undo and redo: Users can undo and redo their editing actions.
             */
            List<string> textFiles = new();
            string operation = ChooseOperation();

            while (true)
            {
                Console.Write("Write your text: ");
                string text = Console.ReadLine();

                switch (operation)
                {
                    case "1":
                        OpenTextFiles(textFiles);
                        break;
                    case "2":
                        text = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Save or overwrite a new file!");
                        string decision = Console.ReadLine().ToLower();
                        if (decision == "save")
                        {
                            textFiles.Add("");
                        }
                        else if (decision == "overwrite")
                        {

                        }
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                }
            }
        }

        static void OpenTextFiles(List<string> textFiles)
        {
            if (textFiles.Count > 0)
            {
                int count = 1;
                foreach (string textFile in textFiles)
                {

                    Console.WriteLine($"{count++} - {textFile}");
                }
            }
            else
            {
                Console.WriteLine("There are no text files!");
            }
        }

        static string ChooseOperation()
        {
            Console.WriteLine("1 - Open text files!");
            Console.WriteLine("2 - Edit text!");
            Console.WriteLine("3 - Save text files!");
            Console.WriteLine("4 - Copy, cut and paste!");
            Console.WriteLine("5 - Undo and redo!");
            Console.Write("Choose your operation: ");
            return Console.ReadLine();
        }
    }
}

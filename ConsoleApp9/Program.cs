using System;
using System.IO;

class Program
{
    static void Main()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        int selectedDriveIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите дисковод:");
            for (int i = 0; i < drives.Length; i++)
            {
                if (i == selectedDriveIndex)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write("  ");
                }
                DisplayDriveInfo(drives[i]);
            }

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow && selectedDriveIndex > 0)
            {
                selectedDriveIndex--;
            }
            else if (key.Key == ConsoleKey.DownArrow && selectedDriveIndex < drives.Length - 1)
            {
                selectedDriveIndex++;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                DisplayDriveContents(drives[selectedDriveIndex]);
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }
    static void DisplayDriveInfo(DriveInfo drive)
    {
        Console.WriteLine($"Имя: {drive.Name}");
        Console.WriteLine($"Тип: {drive.DriveType}");
        Console.WriteLine($"Объем доступного свободного места: {drive.AvailableFreeSpace}");
        Console.WriteLine($"Всего свободного места: {drive.TotalFreeSpace}");
        Console.WriteLine($"Общий объем диска: {drive.TotalSize}");
    }


    static void DisplayDriveContents(DriveInfo drive)
    {
        string[] directories = Directory.GetDirectories(drive.Name);
        string[] files = Directory.GetFiles(drive.Name);

        int selectedDirectoryIndex = 0;
        int selectedFileIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Содержимое {drive.Name}:");

            for (int i = 0; i < directories.Length; i++)
            {
                if (i == selectedDirectoryIndex)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(Path.GetFileName(directories[i]));
            }

            Console.WriteLine();

            for (int i = 0; i < files.Length; i++)
            {
                if (i == selectedFileIndex)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(Path.GetFileName(files[i]));
            }

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (selectedDirectoryIndex > 0 && selectedFileIndex == 0)
                {
                    selectedDirectoryIndex--;
                }
                else if (selectedFileIndex > 0)
                {
                    selectedFileIndex--;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (selectedDirectoryIndex < directories.Length - 1 && selectedFileIndex == files.Length - 1)
                {
                    selectedDirectoryIndex++;
                }
                else if (selectedFileIndex < files.Length - 1)
                {
                    selectedFileIndex++;
                }
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (selectedFileIndex > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Выбран файл: " + files[selectedFileIndex]);
                    Console.ReadKey();
                }
                else if (selectedDirectoryIndex > 0)
                {
                    DisplayDirectoryContents(directories[selectedDirectoryIndex]);
                }
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    static void DisplayDirectoryContents(string directoryPath)
    {
        string[] directories = Directory.GetDirectories(directoryPath);
        string[] files = Directory.GetFiles(directoryPath);

        int selectedDirectoryIndex = 0;
        int selectedFileIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Содержимое {directoryPath}:");

            for (int i = 0; i < directories.Length; i++)
            {
                if (i == selectedDirectoryIndex)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(Path.GetFileName(directories[i]));
            }

            Console.WriteLine();

            for (int i = 0; i < files.Length; i++)
            {
                if (i == selectedFileIndex)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(Path.GetFileName(files[i]));
            }

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (selectedDirectoryIndex > 0 && selectedFileIndex == 0)
                {
                    selectedDirectoryIndex--;
                }
                else if (selectedFileIndex > 0)
                {
                    selectedFileIndex--;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (selectedDirectoryIndex < directories.Length - 1 && selectedFileIndex == files.Length - 1)
                {
                    selectedDirectoryIndex++;
                }
                else if (selectedFileIndex < files.Length - 1)
                {
                    selectedFileIndex++;
                }
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (selectedFileIndex > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Выбран файл: " + files[selectedFileIndex]);
                    Console.ReadKey();
                }
                else if (selectedDirectoryIndex > 0)
                {
                    DisplayDirectoryContents(directories[selectedDirectoryIndex]);
                }
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }
}
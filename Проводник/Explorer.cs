using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Проводник

{
    public static class Explorer
    {
        static public void ChooseFolder(string path)
        {

        }
        static public void ShowFiles(string path)
        {

        }
        static public void ShowFolders(string path)
        {
            string thisFolder = $"\t\t\t{path.Substring(path.LastIndexOf('\\'))}";
            string line =   "--------------------------------------------------------";
            string header = "  Название                  Дата создания         Тип   ";

            string objectName;

            Console.Clear();
            Console.WriteLine(thisFolder);
            Console.WriteLine(line);
            Console.WriteLine(header);

            string[] allDirectories = Directory.GetDirectories(path);

            string[] allFiles = Directory.GetFiles(path);

            var allDirectoriesAndFiles = allDirectories.Concat(allFiles).ToArray();

            for (int i = 0; i < allDirectoriesAndFiles.Length; i++)
            {

                if (i >= allDirectories.Length)
                {
                    //FILE
                   



                    int indexOfLastDot = allDirectoriesAndFiles[i].LastIndexOf('.');

                    if(indexOfLastDot != -1)
                    {
                        objectName = allDirectoriesAndFiles[i].Substring(path.Length);
                        objectName = objectName.Substring(0, objectName.LastIndexOf('.'));

                        Console.WriteLine("  " + objectName);
                        Console.SetCursorPosition(left: 28, top: i + 3);
                        Console.WriteLine(Directory.GetCreationTime(allDirectoriesAndFiles[i]));

                        string fileType = allDirectoriesAndFiles[i].Substring(indexOfLastDot);

                        Console.SetCursorPosition(left: 50, top: i + 3);

                        Console.WriteLine("{0}", fileType);
                    } else
                    {
                        objectName = allDirectoriesAndFiles[i].Substring(path.Length);
                        //objectName = objectName.Substring(0, objectName.LastIndexOf('.'));
                        Console.WriteLine("  " + objectName);
                        Console.SetCursorPosition(left: 28, top: i + 3);
                        Console.WriteLine(Directory.GetCreationTime(allDirectoriesAndFiles[i]));
                    }
                }   else
                {
                    objectName = allDirectoriesAndFiles[i].Substring(path.Length);

                    Console.WriteLine("  " + objectName);
                    Console.SetCursorPosition(left: 28, top: i + 3);
                    Console.WriteLine(Directory.GetCreationTime(allDirectoriesAndFiles[i]));

                }

            }

            Console.SetCursorPosition(top: 0, left: 0);

            ArrowMenu folderMenu = new ArrowMenu(3, 3 + allDirectoriesAndFiles.Length - 1);

            int userChoice = folderMenu.UserChoice() - 3;


            if (File.Exists(allDirectoriesAndFiles[userChoice]))
            {
                Process.Start(new ProcessStartInfo { FileName = allDirectoriesAndFiles[userChoice], UseShellExecute = true });
                ShowFolders(path);
            }
            else
            {
                ShowFolders(allDirectoriesAndFiles[userChoice]);
            }

        }
        static public void ChooseDisk(DriveInfo drive)
        {

        }

        static public void ShowDisks()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            string this_PC = "\t\t\tЭтот компьютер";
            string line = "-----------------------------------------------------";

            Console.Clear();
            Console.WriteLine(this_PC);
            Console.WriteLine(line);
            Console.WriteLine();

            foreach (var disk in drives)
            {
                var totalSize = disk.TotalSize / 1024 / 1024 / 1024;
                var freeSize = disk.TotalFreeSpace / 1024 / 1024 / 1024;
                Console.WriteLine($"  {disk.Name} {freeSize} Gb свободно из {totalSize} Gb");
            }

            ArrowMenu diskMenu = new ArrowMenu(3, 3 + drives.Length - 1);

            var diskIndex = diskMenu.UserChoice() - 3;

            DriveInfo choosenDisk = drives[diskIndex];

            ShowFolders(choosenDisk.Name);

        }
    }
}
﻿using System;
using System.IO;

public class ModeleSauvegarde
{
    public int comp;
    public void SauvegardeComplete(string sourceDirName, string destDirName, bool copySubDirs)    
    {

        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo dest = new DirectoryInfo(destDirName);

        if (dest.Exists)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(destDirName, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
        }
        
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();

        // If the destination directory doesn't exist, create it.       
        Directory.CreateDirectory(destDirName);

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string tempPath = Path.Combine(destDirName, file.Name);
            file.CopyTo(tempPath, false);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirName, subdir.Name);
                SauvegardeComplete(subdir.FullName, tempPath, copySubDirs);
            }
        }
    }






    public void SauvegardeDiff(string sourceDirName, string destDirName, bool copySubDirs)
    {

        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo dest = new DirectoryInfo(destDirName);

        if (dest.Exists)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(destDirName, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
        }

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();

        // If the destination directory doesn't exist, create it.       
        Directory.CreateDirectory(destDirName);

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            Console.WriteLine(Sauvegarde.horodatage);
            comp =  DateTime.Compare(file.LastWriteTime, Sauvegarde.horodatage);
            if (comp > 0)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirName, subdir.Name);
                SauvegardeComplete(subdir.FullName, tempPath, copySubDirs);
            }
        }
    }
}

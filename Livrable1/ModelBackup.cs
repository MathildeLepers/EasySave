using System;
using System.IO;
using System.Diagnostics;
using System.Threading;


public class ModelBackup
{
    public int comp;
    public double time;
    public void CompleteBackup(string sourceDirName, string destDirName, bool copySubDirs)    
    {

        Stopwatch sw = Stopwatch.StartNew(); //start a time counter 
        
        
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
                CompleteBackup(subdir.FullName, tempPath, copySubDirs);
            }
        }
        
        sw.Stop(); //stop counter 
        this.time = sw.Elapsed.TotalMilliseconds;//stop counter and return time use to do the backup
        Console.WriteLine(this.time);
    }
}

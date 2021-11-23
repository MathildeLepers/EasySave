using System;
using System.IO;

public class CalculSize
{
    public int nbFile = 0;
    public float calculateFolderSize(string folder) //calculates the size of the directory to be backed up and starts the backup
    {
        float folderSize = 0.0f; //initialize directory size to 0
        try
        {
            //Checks if the path is valid or not
            if (!Directory.Exists(folder))//if the directory doesn't exists 
                return folderSize; //return size O
            else
            {
                try
                {
                    foreach (string file in Directory.GetFiles(folder)) //for each file in the repository
                    {
                        this.nbFile ++;
                        if (File.Exists(file)) //if the file exists 
                        {
                            FileInfo finfo = new FileInfo(file);
                            folderSize += finfo.Length; //add to the total size the size of the file
                        }
                    }

                    foreach (string dir in Directory.GetDirectories(folder))
                        folderSize += calculateFolderSize(dir); //search if the repository contains an other repository with other file to count
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                }
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Unable to calculate folder size: {0}", e.Message); //catch if we don't have the autorization
        }
        return folderSize;
    }
}

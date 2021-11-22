using System;
using System.IO;

public class RecupereDate
{
    public int returnLastDate() 
    {
        string fileName = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Livrable1\Fichierlogs.txt";
        string[] lines = File.ReadAllLines(@fileName);
        int nblines = lines.Length;
        return nblines - 7;
    }
}

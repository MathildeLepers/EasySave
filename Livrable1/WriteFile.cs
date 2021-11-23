using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class WriteFile
{
    public Backup backup;
    public string source;
    public string dest;
    public float sizeSource;
    public float sizeDest;
    CalculSize calculSize = new CalculSize();
    public int nbFiles;
    public WriteFile(Backup backup)//construct a log with a source, a destination, a length and a time
    {
        this.backup = backup;
        this.source = this.backup.source;
        this.dest = this.backup.dest;
        this.sizeSource = this.backup.taille;
        this.sizeDest = calculSize.calculateFolderSize(this.dest);
        this.nbFiles = calculSize.nbFile;
        Console.WriteLine(this.backup.nbFiles);
    }

    public void ecrire()
    {
       
        try
        {
            JSONFile log = new JSONFile();
            log.Time = this.backup.date;
            log.Name = this.backup.name;
            log.Destination = this.dest;
            log.Source = this.source;
            log.State = this.backup.state;
            log.Size = this.sizeSource;
            log.NbFiles = this.backup.nbFiles;
            log.NbFilesLeft = this.backup.nbFiles - this.nbFiles;
            log.SizeFilesLeft = this.sizeSource - this.sizeDest;
                
            string json = JsonConvert.SerializeObject(log);

            string fileName = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Fichier.json";
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = System.Text.Json.JsonSerializer.Serialize(log, options);
                File.WriteAllText(@fileName, jsonString);
            }
        }
        catch (Exception exp)
        {
            Console.Write(exp.Message);
        }
        
    }
}

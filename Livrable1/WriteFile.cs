using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class WriteFile
{
    public Backup sauvegarde;
    public string source;
    public string dest;
    public float tailleSource;
    public float tailleDest;
    CalculSize calculTaille = new CalculSize();
    public int nbFiles;
    public WriteFile(Backup sauvegarde)//construct a log with a source, a destination, a length and a time
    {
        this.sauvegarde = sauvegarde;
        this.source = this.sauvegarde.source;
        this.dest = this.sauvegarde.dest;
        this.tailleSource = this.sauvegarde.taille;
        this.tailleDest = calculTaille.calculateFolderSize(this.dest);
    }

    public void ecrire()
    {
        Console.WriteLine(this.sauvegarde.state);
        while (this.sauvegarde.state == Etat.INPROGRESS)
        {
            this.tailleDest = calculTaille.calculateFolderSize(this.dest);
            this.nbFiles = calculTaille.nbFile;
            try
            {
                JSONFile log = new JSONFile();
                log.Time = this.sauvegarde.time;
                log.Name = this.sauvegarde.name;
                log.Destination = this.dest;
                log.Source = this.source;
                log.State = this.sauvegarde.state;
                log.Size = this.sauvegarde.taille;
                log.NbFiles = this.sauvegarde.nbFiles;
                log.NbFilesLeft = this.sauvegarde.nbFiles - this.nbFiles;
                log.SizeFilesLeft = this.tailleSource - this.tailleDest;
                
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
}

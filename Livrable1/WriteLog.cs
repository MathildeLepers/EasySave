using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;   

public class WriteLog //class which write the logs 
{
    public Backup backup;
    public string source; 
    public string dest;
    public double sizeSource;
    public double time;
    List<JSON> listJSON = new List<JSON>();

    public WriteLog(Backup backup)//construct a log with a source, a destination, a length and a time
    {
        this.backup = backup;
        this.source = this.backup.source;
        this.dest = this.backup.dest;
        this.sizeSource = this.backup.taille;
        this.time = this.backup.time;
    }
    public void ecrire()
    {
        try
        {
            JSON log = new JSON();
            log.Time = this.backup.date;
            log.Name = this.backup.name;
            log.Destination = this.dest;
            log.Source = this.source;
            log.Taille = this.sizeSource;
            log.Temps = this.time;

            string json = JsonConvert.SerializeObject(log);

            

            string fileName = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Log.json";
            {
                if (!File.Exists(fileName))
                {
                    listJSON.Add(log);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(listJSON, options);
                    File.WriteAllText(@fileName, jsonString);
                }
                else
                {
                    StreamReader r = new StreamReader(fileName);
                    string jsonString2 = r.ReadToEnd();
                    r.Close();
                    List<JSON> m = JsonConvert.DeserializeObject<List<JSON>>(jsonString2);
                    m.Add(log);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString3 = System.Text.Json.JsonSerializer.Serialize(m, options);
                    File.WriteAllText(@fileName, jsonString3);
                }
                



            }
        }
        catch (Exception exp)
        {
            Console.Write(exp.Message);
        }
    }
}


using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;   

public class EcritureLog //class which write the logs 
{
    public Sauvegarde sauvegarde;
    public string source; 
    public string dest;
    public double tailleSource;
    public CalculSize calculTaille = new CalculSize();
    public CalculTemps calculTemps;
    public double temps;
    List<JSON> listJSON = new List<JSON>();

    public EcritureLog(Sauvegarde backup)//construct a log with a source, a destination, a length and a time
    {
        this.sauvegarde = backup;
        this.source = this.sauvegarde.source;
        this.dest = this.sauvegarde.dest;
        this.tailleSource = this.sauvegarde.taille;
        calculTemps = new CalculTemps(this.sauvegarde);
        this.temps = calculTemps.temps;
    }
    public void ecrire()
    {
        try
        {
            JSON log = new JSON();
            log.Time = Sauvegarde.horodatage;
            log.Name = this.sauvegarde.appellation;
            log.Destination = this.dest;
            log.Source = this.source;
            log.Taille = this.tailleSource;
            log.Temps = this.temps;

            string json = JsonConvert.SerializeObject(log);

            

            string fileName = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\test.json";
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


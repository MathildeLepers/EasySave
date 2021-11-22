using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class EcritureLog //class which write the logs 
{
	public Sauvegarde sauvegarde = new Sauvegarde("Test", Etat.ACTIF, 10, 15); //CREER LA SAUVEGARDE EN ATTENDANT QUE LUILISATEUR LE FASSE
    public string source; 
    public string dest;
    public double taille;
    public CalculTaille calculTaille = new CalculTaille();
    public CalculTemps calculTemps;
    public double temps;

    public EcritureLog(string fichierSource, string fichierDest)//construct a log with a source, a destination, a length and a time
    {
        this.source = fichierSource;
        this.dest = fichierDest;
        this.taille = calculTaille.calculateFolderSize(this.source);
        calculTemps = new CalculTemps(this.source, this.dest, Type.COMPLET);
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
            log.Taille = this.taille;
            log.Temps = this.temps;
            string json = JsonConvert.SerializeObject(log);

            string fileName = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\test.json";
            {

                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = System.Text.Json.JsonSerializer.Serialize(log, options);
                Console.WriteLine(jsonString);
                File.WriteAllText(@fileName, jsonString);
            }
        }
        catch (Exception exp)
        {
            Console.Write(exp.Message);
        }
    }
}


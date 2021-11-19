using System;
using System.IO;

public class EcritureLog //class which write the logs 
{
	public Sauvegarde sauvegarde = new Sauvegarde("Test", Etat.ACTIF, 10, 15); //CREER LA SAUVEGARDE EN ATTENDANT QUE LUILISATEUR LE FASSE
    public string source; 
    public string dest;
    public int taille;
    public CalculTaille calculTaille = new CalculTaille();
    public CalculTemps calculTemps;

    public EcritureLog(string fichierSource, string fichierDest)//construct a log with a source, a destination, a length and a time
    {
        this.source = fichierSource;
        this.dest = fichierDest;
        this.taille = this.source.Length;
        calculTemps = new CalculTemps(this.source, this.dest, Type.COMPLET);
    }

	public void ecrire()//write everything in the log file 
    {
        try
            {
            string fileName = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Livrable1\Fichierlogs.txt";
            using (StreamWriter writer = new StreamWriter(@fileName, true))
            {
                writer.WriteLine("{");
                writer.WriteLine("time : " + Sauvegarde.horodatage);
                
                writer.WriteLine("name : " + this.sauvegarde.appellation);
                writer.WriteLine("source : " + this.source);
                writer.WriteLine("destination : " + this.dest);
                writer.WriteLine("taille : " + this.calculTaille.calculateFolderSize(this.source) + " octets");
                writer.WriteLine("temps sauvegarde : " + calculTemps.temps + " ms");
                writer.WriteLine("}");
                writer.WriteLine(" ");
            }
        }
        catch (Exception exp)
        {
            Console.Write(exp.Message);
        }

    }
}

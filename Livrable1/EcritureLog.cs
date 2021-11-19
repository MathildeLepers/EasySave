using System;
using System.IO;

public class EcritureLog
{
	public Sauvegarde sauvegarde = new Sauvegarde("Test", Etat.ACTIF, 10, 15);
    public string source;
    public string dest;
    public int taille;
    public CalculTaille calculTaille = new CalculTaille();
    public CalculTemps calculTemps;
    public double temps;

    public EcritureLog(string fichierSource, string fichierDest)
    {
        this.source = fichierSource;
        this.dest = fichierDest;
        this.taille = this.source.Length;
        calculTemps = new CalculTemps(this.source, this.dest, Type.COMPLET);
        this.temps = calculTemps.temps;
    }

	public void ecrire()
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
                writer.WriteLine("temps sauvegarde : " + this.temps + " ms");
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

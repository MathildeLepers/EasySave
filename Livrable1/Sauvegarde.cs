using System;

public class Sauvegarde
{
	public string appellation;
	public static DateTime horodatage;
	public Etat etat = new Etat();
	public int nbFichiersEligibles;
	public float taille;
	public string source;
	public string dest;
	CalculSize calculTaille = new CalculSize();

	public Sauvegarde(string appellationADonner, string source, string dest)
	{
		this.source = source;
		this.dest = dest; 
		this.appellation = appellationADonner;
		horodatage = DateTime.Now;
		this.etat = Etat.NONACTIF;
		this.nbFichiersEligibles = calculTaille.nbFile;
        this.taille = calculTaille.calculateFolderSize(this.source);
    }
}

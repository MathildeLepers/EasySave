using System;

public class Sauvegarde
{
	public string appellation;
	public static DateTime horodatage;
	public Etat etat = new Etat();
	public int nbFichiersEligibles;
	public int tailleFichiers;

	public Sauvegarde(string appellationADonner, Etat etatADonner, int nbFichiersADonner, int tailleADonner)
	{
		this.appellation = appellationADonner;
		horodatage = DateTime.Now;
		this.etat = etatADonner;
		this.nbFichiersEligibles = nbFichiersADonner;
		this.tailleFichiers = tailleADonner;
	}
}

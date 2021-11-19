using System;

public class Logiciel //set the language and the number of backup 
{
	public Langue langue = new Langue();
	public int nbTravaux;
	public Logiciel(Langue langueADefinir, int nbSouhaite)
	{
		this.langue = langueADefinir;
		this.nbTravaux = nbSouhaite;
	}

	public Langue getLangue()
    {
		return this.langue;
    }

	public void setLangue(Langue langueAModifier)
    {
		this.langue = langueAModifier;
    }

	public int getNbTravaux()
	{
		return this.nbTravaux;
	}

	public void setNbTravaux(int nbTravauxAModifier)
	{
		this.nbTravaux = nbTravauxAModifier;
	}
}

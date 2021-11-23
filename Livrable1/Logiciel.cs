using System;

public class Logiciel //set the language and the number of backup 
{
	public Langue language = new Langue();
	public int nbBackup;
	public string fileSource;
	public string fileDest;
	public string name;


	public Logiciel(Langue languageChosen)
	{
		this.language = languageChosen;
	}

	public void launch()
    {
		if (this.language == Langue.FRANCAIS)
        {
			Console.WriteLine("Combien de sauvegardes voulez vous réaliser?");
			this.nbBackup = Int32.Parse(Console.ReadLine());
			this.fileSource = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\";
			this.fileDest = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test";
			for (int i = 0; i < nbBackup; i++)
            {
				Console.WriteLine("Comment voulez vous appeler votre " + (i+1) + "éme sauvegarde");
				this.name = Console.ReadLine();
			}
		}

		if (this.language == Langue.ENGLISH)
		{
			Console.WriteLine("How many backup do you want to realize?");
			this.nbBackup = Int32.Parse(Console.ReadLine());
			this.fileSource = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\";
			this.fileDest = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test";
			for (int i = 0; i < nbBackup; i++)
			{
				Console.WriteLine("How do you wanna name your " + (i + 1) + " backup");
				this.name = Console.ReadLine();
			}
		}

		EcritureLog log = new EcritureLog(new Sauvegarde("test", fileSource, fileDest));
		EcritureFichier fichier = new EcritureFichier(new Sauvegarde("Test", fileSource, fileDest));


		fichier.ecrire();


		log.ecrire();

	}

}

using System;
using System.Collections.Generic;
public class Software //set the language and the number of backup 
{
	public Language language = new Language();
	public int nbBackup;
	public string fileSource;
	public string fileDest;
	public string name;
	public Backup backup;
	public ModelBackup model = new ModelBackup();
	public List<JSONFile> listJSON = new List<JSONFile>();
	public WriteFile fichier;


	public Software(Language languageChosen)
	{
		this.language = languageChosen;
	}

	public void launch()
    {
		if (this.language == Language.ENGLISH)
		{
			Console.WriteLine("How many backup do you want to realize? (max 5)");
			this.nbBackup = Int32.Parse(Console.ReadLine());

			while(this.nbBackup > 5)
            {
				Console.WriteLine("Too much backup!!! Please chose under 6. How many backup do you want to realize?");
				this.nbBackup = Int32.Parse(Console.ReadLine());
			}

			Console.WriteLine("Where is your source folder ?");
			this.fileSource = Console.ReadLine();
			Console.WriteLine("Where is your destination folder ?");
			this.fileDest = Console.ReadLine();


			for (int i = 0; i < nbBackup; i++)
			{
				Console.WriteLine("How do you wanna name your " + (i + 1) + " backup");
				this.name = Console.ReadLine();

				this.backup = new Backup(this.name, @fileSource, @fileDest);

				WriteLog log = new WriteLog(this.backup);
	
				this.backup.state = State.INPROGRESS;
				model.CompleteBackup(@fileSource, @fileDest, true);
				this.backup.state = State.END;
				this.backup.time = model.time;
				log.ecrire();
			}
		}

		if (this.language == Language.FRANCAIS)
        {
			Console.WriteLine("Combien de sauvegardes voulez vous réaliser?");
			this.nbBackup = Int32.Parse(Console.ReadLine());

			while (this.nbBackup > 5)
			{
				Console.WriteLine("Trop de sauvegardes!!! Choisir 5 max. Combien de sauvegardes voulez vous réaliser?");
				this.nbBackup = Int32.Parse(Console.ReadLine());
			}

			Console.WriteLine("Ou se situe votre dossier source ?");
			this.fileSource = Console.ReadLine();
			Console.WriteLine("Ou se situe votre dossier destinataire ?");
			this.fileDest = Console.ReadLine();


			for (int i = 0; i < nbBackup; i++)
            {
				Console.WriteLine("Comment voulez vous appeler votre " + (i+1) + "éme sauvegarde");
				this.name = Console.ReadLine();
				this.backup = new Backup(this.name, @fileSource, @fileDest);

				WriteLog log = new WriteLog(this.backup);
				this.fichier = new WriteFile(this.backup);
				listJSON.Add(fichier.log);

				this.backup.state = State.INPROGRESS; 
				model.CompleteBackup(@fileSource, @fileDest, true);
				this.backup.state = State.END;
				this.backup.time = model.time;
				log.ecrire();
			}
		}
		fichier.ecrire(listJSON);
	}

}

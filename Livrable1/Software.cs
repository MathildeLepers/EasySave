using System;

public class Software //set the language and the number of backup 
{
	public Language language = new Language();
	public int nbBackup;
	public string fileSource;
	public string fileDest;
	public string name;
	public Backup backup;
	public ModelBackup model = new ModelBackup();


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
			this.fileSource = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\";
			this.fileDest = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test";
			for (int i = 0; i < nbBackup; i++)
			{
				Console.WriteLine("How do you wanna name your " + (i + 1) + " backup");
				this.name = Console.ReadLine();

				this.backup = new Backup(this.name, this.fileSource, this.fileDest);

				WriteLog log = new WriteLog(this.backup);
				WriteFile fichier = new WriteFile(this.backup);
	
				this.backup.state = State.INPROGRESS;
				model.CompleteBackup(this.fileSource, this.fileDest, true);
				this.backup.state = State.END;
				this.backup.time = model.time;
				fichier.ecrire();
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
			this.fileSource = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\";
			this.fileDest = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test";
			for (int i = 0; i < nbBackup; i++)
            {
				Console.WriteLine("Comment voulez vous appeler votre " + (i+1) + "éme sauvegarde");
				this.name = Console.ReadLine();
				this.backup = new Backup(this.name, this.fileSource, this.fileDest);

				WriteLog log = new WriteLog(this.backup);
				WriteFile fichier = new WriteFile(this.backup);

				this.backup.state = State.INPROGRESS; 
				model.CompleteBackup(this.fileSource, this.fileDest, true);
				this.backup.state = State.END;
				this.backup.time = model.time;
				fichier.ecrire();
				log.ecrire();
			}
		}

	}

}

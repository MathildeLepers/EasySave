using System;
using System.Collections.Generic;
public class Software //set the language and the number of backup 
{
	public Languages language = new Languages();
	public string nbBackup;
	public string fileSource;
	public string fileDest;
	public string name;
	public Backup backup;
	public ModelBackup model = new ModelBackup();
	public List<JSONFile> listJSON = new List<JSONFile>();
	public WriteFile fichier;


	public Software(Languages languageChosen)
	{
		this.language = languageChosen;
	}

	public void launch()
    {
		if (this.language == Languages.ENGLISH)
		{
			this.nbBackup = "How many backup do you want to realize?";
			this.fileSource = "Where is your source folder ?";
			this.fileDest = "Where is your destination folder ?";
			this.name = "How do you wanna name your backup ?";

				//this.backup = new Backup(this.name, @fileSource, @fileDest);

				//WriteLog log = new WriteLog(this.backup);
	
				//this.backup.state = State.INPROGRESS;
				//model.CompleteBackup(@fileSource, @fileDest, true);
				//this.backup.state = State.END;
				//this.backup.time = model.time;
				//log.ecrire();
			}

		//fichier.ecrire(listJSON);
	}

}

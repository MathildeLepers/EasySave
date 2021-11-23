using System;

public class Backup //the class of the backup
{
	public string name;
	public DateTime date;
	public State state = new State();
	public int nbFiles;
	public float taille;
	public string source;
	public string dest;
	CalculSize calculSize = new CalculSize();
	public double time;

	public Backup(string nameToGive, string source, string dest)
	{
		this.source = source;
		this.dest = dest; 
		this.name = nameToGive;
		this.date = DateTime.Now;
		this.state = State.NONACTIVE;
		this.nbFiles = calculSize.nbFile;
		this.taille = calculSize.calculateFolderSize(this.source);
    }
}

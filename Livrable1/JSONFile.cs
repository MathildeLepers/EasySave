using System;

public class JSONFile
{
	public DateTimeOffset Time { get; set; }
	public string Name { get; set; }
	public string Source { get; set; }
	public string Destination { get; set; }
	public double Size { get; set; }
	public Etat State { get; set; }
	public int NbFiles { get; set; }
	public int NbFilesLeft { get; set; }
	public float SizeFilesLeft { get; set; }

}

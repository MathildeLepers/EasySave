using System;
using System.Diagnostics;
using System.Threading;

public class CalculTemps
{
    public double temps;
    public ModeleSauvegarde modeleSauv;
    public Sauvegarde sauvegarde;

    public CalculTemps(Sauvegarde sauvegarde) //calculate the time and start the backup
    {
        this.sauvegarde = sauvegarde;
        this.sauvegarde.etat = Etat.ENCOURS; //push the state of the backup to in progress
        Stopwatch sw = Stopwatch.StartNew(); //start a time counter 
        this.modeleSauv = new ModeleSauvegarde(); //create a backup 
        this.modeleSauv.SauvegardeComplete(this.sauvegarde.source, this.sauvegarde.dest, true);//launch complete backup
        sw.Stop(); //stop counter 
        this.sauvegarde.etat = Etat.END; //push the state of the backup to end 
        this.temps = sw.Elapsed.TotalMilliseconds;//stop counter and return time use to do the backup
    }
}

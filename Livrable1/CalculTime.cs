using System;
using System.Diagnostics;
using System.Threading;

public class CalculTime
{
    public double temps;
    public ModelBackup modeleSauv;
    public Backup sauvegarde;

    public CalculTime(Backup sauvegarde) //calculate the time and start the backup
    {
        this.sauvegarde = sauvegarde;
        this.sauvegarde.state = Etat.INPROGRESS; //push the state of the backup to in progress
        Stopwatch sw = Stopwatch.StartNew(); //start a time counter 
        this.modeleSauv = new ModelBackup(); //create a backup 
        this.modeleSauv.SauvegardeComplete(this.sauvegarde.source, this.sauvegarde.dest, true);//launch complete backup
        sw.Stop(); //stop counter 
        this.sauvegarde.state = Etat.END; //push the state of the backup to end 
        this.temps = sw.Elapsed.TotalMilliseconds;//stop counter and return time use to do the backup
    }
}

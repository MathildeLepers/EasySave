using System;
using System.Diagnostics;
using System.Threading;

public class CalculTemps
{
    public double temps;
    public ModeleSauvegarde modeleSauv;

    public CalculTemps(string source, string dest, Type typeSauv) //calculate the time and start the backup
    {
        Stopwatch sw = Stopwatch.StartNew(); //start a counter 
        this.modeleSauv = new ModeleSauvegarde(); //create a backup 
        if (typeSauv == Type.COMPLET)
        {
            this.modeleSauv.SauvegardeComplete(source, dest, true);//lauch complete backup
        }
        if (typeSauv == Type.DIFFERENTIEL)
        {
            this.modeleSauv.SauvegardeDiff(source, dest, true);//launch diff backup
        }
        sw.Stop();
        this.temps = sw.Elapsed.TotalMilliseconds;//stop counter and return time use to do the backup
    }
}

using System;
using System.Diagnostics;
using System.Threading;

public class CalculTemps
{
    public double temps;
    public ModeleSauvegarde modeleSauv;

    public CalculTemps(string source, string dest, Type typeSauv)
    {
        Stopwatch sw = Stopwatch.StartNew();
        this.modeleSauv = new ModeleSauvegarde();
        if (typeSauv == Type.COMPLET)
        {
            this.modeleSauv.SauvegardeComplete(source, dest, true);
        }
        if (typeSauv == Type.DIFFERENTIEL)
        {
            this.modeleSauv.SauvegardeDiff(source, dest, true);
        }
        sw.Stop();
        this.temps = sw.Elapsed.TotalMilliseconds;
    }
}

using System;
using System.Diagnostics;
using System.Threading;

public class CalculTemps
{
    public double temps;
    public ModeleSauvegarde modeleSauv;

    public CalculTemps(string source, string dest, Type typeSauv)
    {
        if (typeSauv == Type.COMPLET)
        {
            Stopwatch sw = Stopwatch.StartNew();
            this.modeleSauv = new ModeleSauvegarde();
            this.modeleSauv.SauvegardeComplete(source, dest, true);
            sw.Stop();
            this.temps = sw.Elapsed.TotalMilliseconds;
        }
        if (typeSauv == Type.DIFFERENTIEL)
        {
            Stopwatch sw = Stopwatch.StartNew();
            this.modeleSauv = new ModeleSauvegarde();
            this.modeleSauv.SauvegardeDiff(source, dest, true);
            sw.Stop();
            this.temps = sw.Elapsed.TotalMilliseconds;
        }
    }
}

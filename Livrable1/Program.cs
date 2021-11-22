using System;
using System.IO;

class Programm
{
    static void Main()
    {
        // Copy from the current directory, include subdirectories.
        ModeleSauvegarde modele = new ModeleSauvegarde();

        Console.WriteLine("Fichier source ? : ");
        string fichierSource = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\";
        Console.WriteLine("Fichier destination ? : ");
        string fichierDest = @"\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test";

        EcritureLog log = new EcritureLog(fichierSource, fichierDest);
        RecupereDate recup = new RecupereDate();
        

        log.ecrire();


        Console.WriteLine(recup.returnLastDate());


        // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\"
        // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test"
    }


}

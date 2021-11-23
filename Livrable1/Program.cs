using System;
using System.IO;

class Programm
{
    static void Main()
    {

        Console.WriteLine("Which language do you want to choose? FR or ENG ?");
        string language = Console.ReadLine();


        while (language != "FR" & language != "ENG")
        {
            Console.WriteLine("Which language do you want to choose? FR or ENG ?");
            language = Console.ReadLine();
        }

        if (language == "FR") {
            Logiciel software = new Logiciel(Langue.FRANCAIS);
            software.launch();
        }

        if (language == "EN")
        {
            Logiciel software = new Logiciel(Langue.ENGLISH);
            software.launch();
        }



        // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\"
        // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test"
    }


}

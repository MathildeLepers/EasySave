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

        if (language == "FR") 
        {
            Software software = new Software(Langue.FRANCAIS);
            software.launch();
        }

        if (language == "ENG")
        {
            Software software = new Software(Langue.ENGLISH);
            software.launch();
        }



        // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\"
        // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test"
    }


}

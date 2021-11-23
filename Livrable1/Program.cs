using System;
using System.IO;

class Programm
{
    static void Main()
    {

        Console.WriteLine("Which language do you want to choose? FR or ENG ?"); //choose the language 
        string language = Console.ReadLine();


        while (language != "FR" & language != "ENG") //the language MUST be FR or ENG
        {
            Console.WriteLine("Which language do you want to choose? FR or ENG ?");
            language = Console.ReadLine();
        }

        if (language == "FR") //if the language choosen is FR, launch the french software 
        {
            Software software = new Software(Langue.FRANCAIS);
            software.launch();
        }

        if (language == "ENG") //if the language choosen is ENG, launch the english software 
        {
            Software software = new Software(Langue.ENGLISH);
            software.launch();
        }



        // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\CER\"
        // "\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Test"
    }


}

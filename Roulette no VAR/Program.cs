Random random = new Random();
int saldo = 1000;
bool spelaIgen = true;

{
    Console.Title = "Sami's Roulette";
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("|===================================================================================================|");
    Console.WriteLine("|                                                                                                   |");
    Console.WriteLine("|        :::::::::   ::::::::  :::    ::: :::        :::::::::: ::::::::::: ::::::::::: ::::::::::  |");
    Console.WriteLine("|       :+:    :+: :+:    :+: :+:    :+: :+:        :+:            :+:         :+:     :+:          |");
    Console.WriteLine("|      +:+    +:+ +:+    +:+ +:+    +:+ +:+        +:+            +:+         +:+     +:+           |");
    Console.WriteLine("|     +#++:++#:  +#+    +:+ +#+    +:+ +#+        +#++:++#       +#+         +#+     +#++:++#       |");
    Console.WriteLine("|    +#+    +#+ +#+    +#+ +#+    +#+ +#+        +#+            +#+         +#+     +#+             |");
    Console.WriteLine("|   #+#    #+# #+#    #+# #+#    #+# #+#        #+#            #+#         #+#     #+#              |");
    Console.WriteLine("|  ###    ###  ########   ########  ########## ##########     ###         ###     ##########        |");
    Console.WriteLine("|                                                                                                   |");
    Console.WriteLine("|===================================================================================================|");
    Console.ResetColor();
    Thread.Sleep(1000);
    Console.WriteLine("Välkommen till Samis roulette!");
}
while (spelaIgen && saldo > 0)
{
    Console.WriteLine("Du börjar med " + saldo + "$");
    Console.WriteLine("Hur mycket vill du satsa? ");
    int insats = int.Parse(Console.ReadLine());

    if (insats > saldo)
    {
        Console.WriteLine("Din idiot! Du har inte så mycket pengar dumbass! Satsa ett giltigt värde!");
        continue;
    }
    Console.WriteLine("Vill du satsa på (s)iffra eller (f)ärg? ");
    string val = Console.ReadLine();
    int nummer = random.Next(0, 37);
    string färg = nummer == 0 ? "grön" : (nummer % 2 == 0 ? "svart" : "röd");
    if (val.ToLower() == "s")
    {
        int gissatNummer;
        bool giltigtNummer = false;


        do
        {
            Console.Write("Vilket nummer vill du satsa på (0-36)? ");
            gissatNummer = int.Parse(Console.ReadLine());

            if (gissatNummer >= 0 && gissatNummer <= 36)
            {
                giltigtNummer = true;
            }
            else
            {
                Console.WriteLine("Ogiltigt nummer. Vänligen välj ett nummer mellan 0 och 36.");
            }
        } while (!giltigtNummer);

        if (gissatNummer == nummer)
        {

            saldo += insats * 35;
            Console.WriteLine("Grattis! Du gissade rätt nummer! Nummer var " + nummer + ". Du vann " + (insats * 35) + " kr.");
        }
        else
        {
            saldo -= insats;
            Console.WriteLine("Tyvärr, du gissade fel. Nummer var " + nummer + ". Du förlorade " + insats + " kr.");
        }
    }
    else if (val.ToLower() == "f")
    {
        Console.Write("Vilken färg vill du satsa på (röd/svart)? ");
        string gissadFärg = Console.ReadLine();

        if (gissadFärg.ToLower() == färg)
        {

            saldo += insats;
            Console.WriteLine("Grattis! Du gissade rätt färg! Färgen var " + färg + ". Du vann " + insats + " kr.");
        }
        else
        {

            saldo -= insats;
            Console.WriteLine("Tyvärr, du gissade fel. Färgen var " + färg + ". Du förlorade " + insats + " kr.");
        }
    }
    else
    {
        Console.WriteLine("Ogiltigt val. Försök igen.");
        continue;
    }


}


if (saldo > 0)
{
    Console.Write("Vill du spela igen? (j/n) ");
    string svar = Console.ReadLine();
    spelaIgen = svar.ToLower() == "j";
}
else
{
    Console.WriteLine("HAHAHAHAHAHA. Nu är du broke! Spelet är slut.");
    spelaIgen = false;
}
    

Console.WriteLine("Tack för att du spelade! Ditt slutgiltiga saldo är " + saldo + " kr.");
    


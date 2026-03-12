//using System.Globalization;
//Console.Clear();

/*
# Produktlista

## Intro
Du ska skriva en console-app som frågar efter produkter. Efter att användaren har skrivit *exit* så visas
alla (korrekt) inmatade produkter. Den första nivån av programmet är i nivå med vad du jobbat med
första veckan. Nivå 3 är svår. Försök komma så långt du kan. Alla hjälpmedel är tillåtna och ni får prata
med varandra.
*/


////////////////////////////////////////////////////////////////////////////////////////////////////

/*
## Nivå 1
I första nivån behöver du inte bry dig om formatet på den inmatade produkten. Användare anger en
produkt och trycker *return*. När användaren fått nog så skriver hon *exit*. Då ska alla produkter
visas.

*/
////////////////////////////////////////////////////////////////////////////////////////////////////
// Globala variabler för alla Nivåer 
string mainMessage = "Skriv in produkter. Avsluta med att skriva 'exit'\n";
string endMessage = "\nDu angav följande produkter";
string question = "Ange produkt: ";

////////////////////////////////////////////////////////////////////////////////////////////////////


//Console.WriteLine("------- NIVÅ 1 -------\n\n");

//Console.WriteLine(mainMessage);
//string[] allproducts1 = new string[10];
//int index1 = 0;


//while (true)
//{
//    string input = Console.ReadLine();
//    if (input == "exit")
//    {
//        break;
//    }
//    allproducts1[index1] = input;
//    index1++;
//}

//Array.Resize(ref allproducts1, index1);
//PrintProductsList(allproducts1, ":\n");










////////////////////////////////////////////////////////////////////////////////////////////////////
/*

## Nivå 2
Fortsätt med programmet. Lägg till följande:
- Användaren ska kunna skriva *exit* på olika sätt. Stora eller små bokstäver ska inte spela någon
roll. Inledande eller avslutande mellanslag ska också accepteras.
- När användaren är klar, visa en sorterad lista

*/
////////////////////////////////////////////////////////////////////////////////////////////////////

//Console.WriteLine("\n\n------- NIVÅ 2 -------\n\n");

//Console.WriteLine(mainMessage);
//string[] allproducts2 = new string[10];
//int index2 = 0;


//while (true)
//{
//    Console.Write(question);
//    string input = Console.ReadLine();
//    if (input.ToLower().Trim() == "exit")
//    {
//        break;
//    }

//    allproducts2[index2] = input;
//    index2++;
//}

//Array.Resize(ref allproducts2, index2);

//var sortedProducts2 = new string[allproducts2.Length];
//allproducts2.CopyTo(sortedProducts2, 0);
//sortedProducts2.Sort();
//PrintProductsList(sortedProducts2, " (sorterade):\n");






////////////////////////////////////////////////////////////////////////////////////////////////////
/*

## Nivå 3
Nu ska du validera produktnamnet och bara acceptera ett namn som består av bokstäver -
bindestreck - siffror.
Siffer-delen måste vara ett heltal mellan 200 och 500.

Exempel på giltiga produktnamn:
- CE-400
- XX-480
- LABAN-231

Exempel på ogiltiga produktnamn:
- CE400
- XX3-480
- LABAN-100

Ge olika felmeddelande beroende på vilket fel användaren gör.

*/
////////////////////////////////////////////////////////////////////////////////////////////////////

Console.WriteLine("\n\n------- NIVÅ 3 -------\n\n");

Console.WriteLine(mainMessage);
string[] allproducts3 = new string[10];
int index3 = 0;

while (true)
{
    Console.Write(question);
    string input = Console.ReadLine();
    string[] inputParts = input.Split('-');

    if (input.ToLower().Trim() == "exit")
    {
        ShowMessage("debug", "EXIT!");
        break;
    }

    if (input.Trim().Length == 0)
    {
        ShowMessage("error", "Du får inte ange ett tomt värde");
    }

    if (inputParts.Length >= 2)
    {
        string stringPart = inputParts[0]; // BOKSTÄVER
        string numberPart = inputParts[1]; // SIFFROR

        bool validStringPart = !string.IsNullOrWhiteSpace(stringPart);
        bool validNumberPart = Int32.TryParse(numberPart, out _);

        if (!validStringPart){
            ShowMessage("error", "Felaktigt format på vänstra delen av produktnumret");
        }
        else if (!validNumberPart){
            ShowMessage("error", "Felaktigt format på högra delen av produktnumret");
        }

        else{
            //Console.WriteLine("\nPART 0 : '"+ stringPart + "' (STRING?) : " + validStringPart);
            //Console.WriteLine("PART 1 : '" + numberPart + "' (NUMBERS?) : " + validNumberPart);

            // Valid inputs
            if (validStringPart && validNumberPart)
            {
                ShowMessage("debug", "OK - Added, Continue....");

                int lowNumber = 200;
                int highNumber = 500;

                if (int.Parse(numberPart) >= lowNumber && int.Parse(numberPart) <= highNumber){
                    allproducts3[index3] = input;
                    index3++;
                }

                else{
                    ShowMessage("error", $"Den numeriska delen måste vara mellan {lowNumber} och {highNumber}");
                }
            }
        }
    }
}

Array.Resize(ref allproducts3, index3);

var sortedProducts3 = new string[allproducts3.Length];
allproducts3.CopyTo(sortedProducts3, 0);
sortedProducts3.Sort();
PrintProductsList(sortedProducts3, " (sorterade):\n");







Console.ReadKey();

void PrintProductsList(string[] products, string message)
{
    Console.WriteLine(endMessage + message);
    foreach (string product in products)
    {
        Console.WriteLine($"* {product}");
    }
}

void ShowMessage(string messageType, string text)
{
    if (!string.IsNullOrWhiteSpace(messageType) && !string.IsNullOrWhiteSpace(text))
    {
        switch (messageType)
        {
            case "error" :
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
                Console.ResetColor();
                break;
            
            case "debug":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(text);
                Console.ResetColor();
                break;

            case "success":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                Console.ResetColor();
                break;
        }
    }
}
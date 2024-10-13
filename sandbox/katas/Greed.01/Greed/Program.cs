// See https://aka.ms/new-console-template for more information

// zakladni verze skorovani, hazi se vzdy peti kostkami
Console.WriteLine("Základní verze");

/*
Tento typ deklaracie nie je chyba, ale obecne sa pouziva klucove slovo 'var' pre lokalne premenne. Hovori sa im implicitne-typovane premenne.
V podstate nechavas kompilator, aby si odvodil typ premennej z toho, co das na pravu stranu za =.
V tomto pripade do greed priradzujes novy objekt typu Greed, takze z toho vie, ze greed bude tohto typu a netreba to pisat explicitne.
Viac informacii tu: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/declarations#implicitly-typed-local-variables
Na ostatnych miestach som ti to uz neopravovala, iba na tomto, aby som ukazala pouzitie.
*/
var greed = new Greed();

// numberOfGreeds uz inde nepouzivas, tak by som to nedavala do premennej, ale rovno do inicializacie pola
int[] thrownValues = new int[5];
string thrownValuesString = "Hozeno: ";

for (int i = 0; i < thrownValues.Length; i++)
{
    thrownValues[i] = greed.ThrowGreed();
    thrownValuesString += thrownValues[i] + " ";
}
Console.WriteLine(thrownValuesString);

int score = greed.CountScore(thrownValues);
Console.WriteLine("Skóre: " + score);


// modifikovana verze skorovani, hazi se 1 - 6 kostkami
Console.WriteLine();
Console.WriteLine("Extra verze");

Greed greedExtra = new Greed();

int numberOfGreedsExtra = greedExtra.GetNumberOfGreeds();
int[] thrownValuesExtra = new int[numberOfGreedsExtra];
string thrownValuesExtraString = "Hozeno: ";

for (int i = 0; i < thrownValuesExtra.Length; i++)
{
    thrownValuesExtra[i] = greed.ThrowGreed();
    thrownValuesExtraString += thrownValuesExtra[i] + " ";
}
Console.WriteLine(thrownValuesExtraString);


int scoreExtra = greedExtra.CountScoreExtra(thrownValuesExtra);
Console.WriteLine("Skóre: " + scoreExtra);


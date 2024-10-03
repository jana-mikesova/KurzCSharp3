// See https://aka.ms/new-console-template for more information

// zakladni verze skorovani, hazi se vzdy peti kostkami
Console.WriteLine("Základní verze");

Greed greed = new Greed();

int numberOfGreeds = 5;
int[] thrownValues = new int[numberOfGreeds];
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

// See https://aka.ms/new-console-template for more information

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
Console.WriteLine(score);


public class Greed
{
    public int[] CountNumbers(int[] greeds)
    {
        int[] numbers = [0, 0, 0, 0, 0, 0];

        foreach (var greed in greeds)
        {
            if (greed == 1)
            {
                numbers[0]++;
            }
            else if (greed == 2)
            {
                numbers[1]++;
            }
            else if (greed == 3)
            {
                numbers[2]++;
            }
            else if (greed == 4)
            {
                numbers[3]++;
            }
            else if (greed == 5)
            {
                numbers[4]++;
            }
            else
            {
                numbers[5]++;
            }
        }

        return numbers;
    }

    public int CountScore(int[] greeds)
    {
        int score = 0;
        int[] numbers = CountNumbers(greeds);

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] is 3)
            {
                switch (i)
                {
                    case 0:
                        score += 1000;
                        break;
                    case 1:
                        score += 200;
                        break;
                    case 2:
                        score += 300;
                        break;
                    case 3:
                        score += 400;
                        break;
                    case 4:
                        score += 500;
                        break;
                    case 5:
                        score += 600;
                        break;
                    default:
                        break;
                }
            }
            if (numbers[i] is 1 or 4)
            {
                switch (i)
                {
                    case 0:
                        score += 100;
                        break;
                    case 4:
                        score += 50;
                        break;
                    default:
                        break;
                }
            }
            if (numbers[i] is 2 or 5)
            {
                switch (i)
                {
                    case 0:
                        score += 200;
                        break;
                    case 4:
                        score += 100;
                        break;
                    default:
                        break;
                }
            }

        }

        return score;
    }

    public int ThrowGreed()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }

    public int GetNumberOfGreeds()
    {
        int numOfGreeds;
        Console.WriteLine("Zadej, kolik kostek bude hozeno (1-6):");
        while (true)
        {
            string userInput = Console.ReadLine();
            bool parseResult = int.TryParse(userInput, out numOfGreeds);
            if (parseResult)
            {
                if (numOfGreeds is < 1 or > 6)
                {
                    Console.WriteLine("Zadané číslo je mimo povolený rozsah 1-6, zadej znovu.");
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Chybné zadání, zadejte znovu celé číslo v rozmezí 1-6.");
            }
        }
        return numOfGreeds;
    }

    public int CountScoreExtra(int[] greeds)
    {
        int scoreExtra = 0;
        int[] numbers = CountNumbers(greeds);
        bool straight = false;
        bool threePairs = false;

        if (greeds.Length == 6)
        {

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 1)
                {
                    straight = true;
                }
                else
                {
                    straight = false;
                    break;
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] is 0 or 2)
                {
                    threePairs = true;
                }
                else
                {
                    threePairs = false;
                    break;
                }
            }
        }

        if (straight)
        {
            scoreExtra = 1200;
        }
        else if (threePairs)
        {
            scoreExtra = 800;
        }
        else
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 6)
                {
                    switch (i)
                    {
                        case 0:
                            scoreExtra += 8 * 1000;
                            break;
                        case 1:
                            scoreExtra += 8 * 200;
                            break;
                        case 2:
                            scoreExtra += 8 * 300;
                            break;
                        case 3:
                            scoreExtra += 8 * 400;
                            break;
                        case 4:
                            scoreExtra += 8 * 500;
                            break;
                        case 5:
                            scoreExtra += 8 * 600;
                            break;
                        default:
                            break;
                    }
                }
                else if (numbers[i] == 5)
                {
                    switch (i)
                    {
                        case 0:
                            scoreExtra += 4 * 1000;
                            break;
                        case 1:
                            scoreExtra += 4 * 200;
                            break;
                        case 2:
                            scoreExtra += 4 * 300;
                            break;
                        case 3:
                            scoreExtra += 4 * 400;
                            break;
                        case 4:
                            scoreExtra += 4 * 500;
                            break;
                        case 5:
                            scoreExtra += 4 * 600;
                            break;
                        default:
                            break;
                    }
                }
                else if (numbers[i] == 4)
                {
                    switch (i)
                    {
                        case 0:
                            scoreExtra += 2 * 1000;
                            break;
                        case 1:
                            scoreExtra += 2 * 200;
                            break;
                        case 2:
                            scoreExtra += 2 * 300;
                            break;
                        case 3:
                            scoreExtra += 2 * 400;
                            break;
                        case 4:
                            scoreExtra += 2 * 500;
                            break;
                        case 5:
                            scoreExtra += 2 * 600;
                            break;
                        default:
                            break;
                    }
                }
                else if (numbers[i] == 3)
                {
                    switch (i)
                    {
                        case 0:
                            scoreExtra += 1000;
                            break;
                        case 1:
                            scoreExtra += 200;
                            break;
                        case 2:
                            scoreExtra += 300;
                            break;
                        case 3:
                            scoreExtra += 400;
                            break;
                        case 4:
                            scoreExtra += 500;
                            break;
                        case 5:
                            scoreExtra += 600;
                            break;
                        default:
                            break;
                    }
                }
                else if (numbers[i] is 2)
                {
                    switch (i)
                    {
                        case 0:
                            scoreExtra += 200;
                            break;
                        case 4:
                            scoreExtra += 100;
                            break;
                        default:
                            break;
                    }
                }
                else if (numbers[i] is 1)
                {
                    switch (i)
                    {
                        case 0:
                            scoreExtra += 100;
                            break;
                        case 4:
                            scoreExtra += 50;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        return scoreExtra;
    }
}

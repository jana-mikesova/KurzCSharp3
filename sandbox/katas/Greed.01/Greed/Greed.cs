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
            if (numbers[i] % 3 == 0)
            {
                switch (i)
                {
                    case 0:
                        score += numbers[i] / 3 * 1000;
                        break;
                    case 1:
                        score += numbers[i] / 3 * 200;
                        break;
                    case 2:
                        score += numbers[i] / 3 * 300;
                        break;
                    case 3:
                        score += numbers[i] / 3 * 400;
                        break;
                    case 4:
                        score += numbers[i] / 3 * 500;
                        break;
                    case 5:
                        score += numbers[i] / 3 * 600;
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
}

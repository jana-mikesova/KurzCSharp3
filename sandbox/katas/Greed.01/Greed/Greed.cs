public class Greed
{
    public int[] CountNumbers(int[] greeds)
    {
        // Tato inicializacia robi uz to iste, vytvori 6-miestne pole kde kazda cast pola obsahuje defaultnu hodnotu pre int, co je 0
        int[] numbers = new int[6];

        foreach (var greed in greeds)
        {
            /*
            Tento kod sa da napisat takto kompaktnejsie, kedze mas vzdy hodnotu pre nejaky Hod na Hod-1 mieste v poli.
            Moja podmienka zaroven riesi, keby tam prislo cislo mimo rozsah <1,6>, tzn. nepokusi sa zapisat mimo rozsah pola.
            V nasom pripade sa to nikdy nestane, ale keby som pisala tuto metodu a chcel by ju pouzit niekto iny, mohol by mi tam nahadzat cisla, kvoli ktorym by mi spadol kod.
            */
            if (greed is >= 1 and <= 6)
            {
                numbers[greed - 1]++;
            }
        }

        return numbers;
    }

    public int CountScore(int[] greeds)
    {
        int score = 0;
        int[] numbers = CountNumbers(greeds);
        //int[] numbers = [0, 0, 0, 0, 5, 0]; // 5krat hodena 5, dava mi vysledok 50, ocakavam vsak 600
        //int[] numbers = [4, 0, 1, 0, 0, 0]; // 4krat 1, 1krat 3, dostavam vysledok 100, ocakavam vsak 1100

        for (int i = 0; i < numbers.Length; i++)
        {
            /*
            Tento kod by ti nefungoval pre pripady kedy hodis 4-krat alebo 5-krat 1 alebo 5.
            Tu mas totiz podmienku, ze pocet hodenych 1 alebo 5 musi byt prave 3, aby sa priratalo 1000, resp. 500 bodov.
            Pri 4 az 5 vyskytoch sa ti teda vyhodnotia az tie dalsie podmienky a teda skore pre triple nedostanes - vsimni si moje testovanie vyssie.
            Spravne teda ma byt podmienka if (numbers[i] is > 3).
            Nevadi pri tomto, ak nahodou hodis napr. 4krat 2. Pripocita sa ti len skore pre triple 2, v dalsich podmienkach pridavas aj tak skore iba ak bola hodena 1 alebo 5.
            Zaroven tymto zarucis, ze ak padla 4 alebo 5krat 1 alebo 5, triple skore sa pripocita.
            */
            if (numbers[i] is > 3)
            {
                switch (i)
                {
                    case 0:
                        score += 1000;
                        break;
                    // jednoduchsie napisana podmienka (triple skore pre vsetko okrem 1 je vzdy to cislo * 100)
                    case >= 1 and <= 5:
                        score += (i + 1) * 100;
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
            /*
            Jeden zo sposobov, akym prist na to, ze mame straight, na jednom riadku:
            straight = numbers.All(n => n == 1);
            Inak by sa dal este kod prepisat takto: budeme predpokladat, ze straight je true, ale ak narazime na nieco ine ako 1 vyskyt, tak to zmenime na false a vyskocime z cyklu:

            bool straight = true;
            ....
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 1)
                {
                    straight = false;
                    break;
                }
            }

            Oba sposoby sa daju pouzit aj pre threePairs
            */
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
                        // jednoduchsie napisany switch, rovnaky sposob sa da pouzit aj nizsie kde to nasobis 4 a 2
                        case >= 1 and <= 5:
                            scoreExtra += 8 * (i + 1) * 100;
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

    public int CountScoreForThrow(int count, int thrownNumber) => (2 ^ (count - 3)) * thrownNumber * 100 * (thrownNumber == 1 ? 100 : 1);
}

/*
Aby nebol tento kod taky dlhy, rozdelila by som mozno pocitanie vysledkov na zaklade poctu hodov do viacerych funkcii.
Skusila by som najst nejaku spolocnu logiku pre jednotlive hody a napisala na zaklade toho funkciu, ktora vrati skore pre dany pocet hodov.
Napr. v situaciach, kedy sme hodili dane cislo viac ako 3krat sa da vyuzit poznatok, ze sa triple score nasobi nejakou mocninou 2 (pri triple score je to 2^0 = 1)
3 (triple score) => exponent 0, 2^0 = 1
4 (four-of-a-kind) => exponent 1, 2^1 = 2
5 (five-of-a-kind) => exponent 2, 2^2 = 4
6 (six-of-a-kind) => exponent 3, 2^3 = 8
Exponent teda ziskame vzdy ako pocet hodov - 3
Vo funkcii vyssie mam teda osetrene vsetky casey pre pocetnost 3 a vyssiu, a staci tam vlozit len hodene cislo (thrownNumber) a pocet hodov.
Samozrejme, neocakavame od vas nejake podobne komplikovane matematicke riesenia a tvoje riesenie je dobre tiez a nemam s nim problem :)
Tymto som len chcela ukazat, ako sa da vymysliet jednoducha metoda pri podobnych programovacich ulohach, kde ma clovek vymysliet riesenie vypoctu nejakej hodnoty.
*/

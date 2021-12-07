string input = File.ReadLines("./input").First();
int[] State = input.Split(',').Select(int.Parse).ToArray();

static int[] startNextDay(int[] fishSchool)
{
    int fishToBeBorn = 0;
    for (int i = 0; i < fishSchool.Length; i++)
    {
        if (fishSchool[i] == 0) fishToBeBorn++;
        fishSchool[i] = fishSchool[i] != 0 ? fishSchool[i]-1 : 6;
    }
    fishSchool = addFish(fishSchool, fishToBeBorn);
    return fishSchool;
}

static int[] addFish(int[] fishSchool, int amountofFish)
{
    for (int i = 0; i < amountofFish; i++)
    {
        fishSchool = fishSchool.Append(8).ToArray();
    }
    return fishSchool;
}

for (int i = 0; i < 80; i++)
{
    State = startNextDay(State);
    Console.WriteLine(i);
}

Console.WriteLine(State.Length.ToString());
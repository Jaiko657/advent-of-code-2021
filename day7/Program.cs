string input = File.ReadLines("./input").First();
int[] State = input.Split(',').Select(int.Parse).ToArray();

static int calculateFuel(int positionAlligned, int[] State)
{
    int fuelUsed = 0;
    for (int i = 0; i < State.Length; i++)
    {
        int crabPosition = State[i];
        int distanceMoved = Math.Abs(crabPosition - positionAlligned);
        fuelUsed += (distanceMoved*(distanceMoved+1))/2;
    }
    return fuelUsed;
}

static int bruteForceBestPosition(int[] State)
{
    int fuel = 1000000000;
    //create array with number in array
    int max = State.Max();
    for(int i  = 0; i < max; i++)
    {
        int newfuel = calculateFuel(i, State);
        if (newfuel < fuel)
        {
            fuel = newfuel;
        }
    }
    return fuel;
}


// Console.WriteLine(State.Max());
Console.WriteLine(bruteForceBestPosition(State));
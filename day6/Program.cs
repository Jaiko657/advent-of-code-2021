string input = File.ReadLines("./input").First();
int[] State = input.Split(',').Select(int.Parse).ToArray();

//part2 store in frequency table so inverting the exponential storage issue
ulong[] frequencyTable = new ulong[9];
foreach (int value in State)
{
    frequencyTable[value]++;
}

for (int i = 0; i < 256; i++)
{
    foreach(int i2 in frequencyTable) Console.WriteLine(i2);
    frequencyTable = startNextDay(frequencyTable);
    Console.WriteLine();
}

static ulong[] startNextDay(ulong[] frequencyTable)
{
    frequencyTable = frequencyTable.Skip(1).Concat(frequencyTable.Take(1)).ToArray();
    // foreach(int i in frequencyTable) Console.WriteLine(i);
    frequencyTable[6] += frequencyTable[8];
    return frequencyTable;
}

Console.WriteLine(frequencyTable.Aggregate((a,c) => a + c).ToString());
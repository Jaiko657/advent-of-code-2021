//Reads input into Array of Strings
string[] input = File.ReadAllLines("./input");
//Initiates Global Variables
int width = input[0].Length;
char[] GammaRate = new string('0', width).ToCharArray();

// Walks through strings and outputs to Global Var GammaRate
for (int i = 0; i < width; i++)
{
    int amount = 0;
    for (int i1 = 0; i1 < input.Length; i1++)
    {
        string line = input[i1];
        char bit = line[i];
        if(bit == '1') amount++;
        if(bit == '0') amount--;
        if(amount > 0)
        {
            GammaRate[i] = '1';
        } else GammaRate[i] = '0';
    }
}

//Prints GammaRate
Console.WriteLine(GammaRate);
int GammaRateInt = GetDecimalFromCharArray(GammaRate);
Console.WriteLine("GammaRate: " + GammaRateInt.ToString());

//Inverts GammaRate to Aquire EpsilonRate
char[] EpsilonRate = InvertBinaryCharArray(GammaRate);
int EpsilonRateInt = GetDecimalFromCharArray(EpsilonRate);
Console.WriteLine(EpsilonRate);
Console.WriteLine("EpsilonRate: " + EpsilonRateInt.ToString());
//Calculates Product of EpsilonRate and GammaRate Ints
Console.WriteLine((GammaRateInt * EpsilonRateInt).ToString());

//Turns CharArray into Decimal
static int GetDecimalFromCharArray(char[] BinaryArray)
{
    int returnvalue = 0;
    for (int i = BinaryArray.Length-1; i >= 0; i--)
    {
        int pos = BinaryArray.Length-1-i;
        int placevalue = (2 << pos)/2;
        if (BinaryArray[i] == '1')
        {
            returnvalue += placevalue;
        }
    }
    return returnvalue;
}

//Performs BitFlip on CharArray of '0' and '1'
static char[] InvertBinaryCharArray(char[] BinaryArray)
{
    for (int i = 0; i < BinaryArray.Length; i++)
    {
        BinaryArray[i] = BinaryArray[i] == '0' ? '1' : '0';
    }
    return BinaryArray;
}
Console.WriteLine();
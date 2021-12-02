// int[] depths = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
string[] strdepths = File.ReadAllLines("./input");
int[] depths = Array.ConvertAll<string, int>(strdepths, int.Parse);
int count = 0;
for (int i = 0; i < depths.Length; i++)
{
    Console.Write(depths[i].ToString());
    if(i == 0)
    {
        Console.Write(" (N/A - no previous measurement)");
    } else 
    {
        if(depths[i] > depths[i - 1])
        {
            count++;
            Console.Write(" (increased)");
        } else
        {
            if(depths[i] < depths[i - 1])
            {
                Console.Write(" (decreased)");
            }
        }
    }
    Console.WriteLine();
}
Console.WriteLine();
Console.Write("Amount of Depth Increases: " + count.ToString());
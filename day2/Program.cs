string[] instructions = File.ReadAllLines("./input");
int depth = 0;
int forward = 0;
foreach(string line in instructions)
{
    int amount = Convert.ToInt32(Char.GetNumericValue(line, line.Length - 1));
    switch(line[0])
    {
        case 'f':
            forward = forward + amount;
            break;
        case 'u':
            depth = depth - amount;
            break;
        case 'd':
            depth = depth + amount;
            break;
    }
}
Console.WriteLine("Depth: " + depth.ToString());
Console.WriteLine("Forward: " + forward.ToString());
Console.WriteLine("Product: " + (depth*forward).ToString());
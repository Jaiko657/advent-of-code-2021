string[] input = File.ReadAllLines("./input");

foreach (string line in input)
{
    List<string> List = line.Split(' ').Take(10);
    List<string> segments = Enumerable.Repeat("abcdefg", 7);
    foreach (string value in List)//
    {
        char[] faultySegment = value.ToCharArray();
        switch(faultySegment.Length)
        {
            case 2:
                segments[GetLetterPos("c")].Replace("abcdefg".Replace(value[0], ""), String.Empty);
                
                foreach(char letter in segments[GetLetterPos("c")])
                {
                    if(letter != value[0] || value[1])  
                    {
                        
                    }
                }
            case 3:

            case 4:

            case 5:

            case 6:

            case 7:

        }
    }
}

static int GetLetterPos(string letter)
{
    switch (letter)
    {
        case "a":
            return 0;
        case "b":
            return 1;
        case "c":
            return 2;
        case "d":
            return 3;
        case "e":
            return 4;
        case "f":
            return 5;
        case "g":
    }
}
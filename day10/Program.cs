string[] input = File.ReadAllLines("./input");
List<string> validLines = new List<string>();
foreach (string line in input)
{
    if(checkIfLineValid(line))
    {
        validLines.Add(removePairs(line));
    }
}
List<int> scores = new List<int>();
foreach(string valid in validLines)
{
    int score = 0;
    Console.WriteLine(valid);
    for (int i = valid.Length-1; i > -1 ; i--)
    {
        char letter = valid[i];
        if (letter == '(') score = (score*5)+1;
        if(letter == '[') score = (score*5)+2;
        if(letter == '{') score = (score*5)+3;
        if(letter == '<') score = (score*5)+4;
    }
    scores.Add(score);
    Console.WriteLine(score);
}
Console.WriteLine(GetMedian(scores.ToArray()));
static string removePairs(string input)
{
    while(true)
    {
        input = removeTrailingBrackets(input);
        input = input.Replace("()","");
        input = input.Replace("[]","");
        input = input.Replace("{}","");
        input = input.Replace("<>","");
        if (!input.Contains("()")&&!input.Contains("[]")&&!input.Contains("{}")&&!input.Contains("<>")) return input;
    }
}
static string removeTrailingBrackets(string input)
{
    while(true)
    {
        if (input.Last() == '('||input.Last() == '['||input.Last() == '{'||input.Last() == '<')
        {
            input = input.Substring(0, input.Length-1);
        } else {
            return input;
        }
    }
}
static bool checkIfLineValid(string input)
{
    input = removePairs(input);
    if (input.Contains("[)")||input.Contains("{)")||input.Contains("<)")) return false;
    if (input.Contains("[}")||input.Contains("(}")||input.Contains("<}")) return false;
    if (input.Contains("(]")||input.Contains("{]")||input.Contains("<]")) return false;
    if (input.Contains("[>")||input.Contains("{>")||input.Contains("(>")) return false;
    return true;
}
static int GetMedian(int[] sourceNumbers) {
        //Framework 2.0 version of this method. there is an easier way in F4        
        if (sourceNumbers == null || sourceNumbers.Length == 0)
            throw new System.Exception("Median of empty array not defined.");

        //make sure the list is sorted, but use a new array
        int[] sortedPNumbers = (int[])sourceNumbers.Clone();
        Array.Sort(sortedPNumbers);
        foreach (int i in sortedPNumbers)
        {
            Console.Write(i + ", ");
        }
        //get the median
        int size = sortedPNumbers.Length;
        int mid = size / 2;
        int median = (size % 2 != 0) ? (int)sortedPNumbers[mid] : ((int)sortedPNumbers[mid] + (int)sortedPNumbers[mid - 1]) / 2;
        return median;
    }
// 1701163 to low
// 1483081 to low

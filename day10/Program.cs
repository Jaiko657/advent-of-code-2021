string[] input = File.ReadAllLines("./input");
var answer = 0;
foreach (string line in input)
{
    answer += findFirstIllegalPair(line);
}
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
static int findFirstIllegalPair(string input)
{
    input = removePairs(input);
    if (input.Contains("[)")||input.Contains("{)")||input.Contains("<)")) return 3;
    if (input.Contains("[}")||input.Contains("(}")||input.Contains("<}")) return 1197;
    if (input.Contains("(]")||input.Contains("{]")||input.Contains("<]")) return 57;
    if (input.Contains("[>")||input.Contains("{>")||input.Contains("(>")) return 25137;
    return 0;
}
Console.WriteLine(answer);
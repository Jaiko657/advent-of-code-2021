//TODO  sometimes checkboards horizontal =5 when it shouldnt
//      verticle will have same problem but it doesnt get to it as other keeps returning value 
string inputFile = "./input";

//Gets Array of BingoNumbers
string strBingoNumbers = File.ReadLines(inputFile).First();
int[] BingoNumbers = strBingoNumbers.Split(',').Select(int.Parse).ToArray(); 

//Reads inputFile into String Array
string[] inputLines = File.ReadAllLines(inputFile);
inputLines = inputLines.Skip(1).ToArray();

int[][,] bingoBoards= new int[inputLines.Length/6][,];
int BoardCount = 0;
for (int i = 0; i < inputLines.Length; i++)
{
    string line = inputLines[i];
    if (line == string.Empty)
    {
        Console.WriteLine("Board: " + BoardCount.ToString());
        bingoBoards[BoardCount] = ParseBingoBoard(inputLines, i+1);
        BoardCount++;
    }
}
// Console.WriteLine(bingoBoards[0][1,3]);
int done = 0;
for (int i = 1; i < BingoNumbers.Length; i++)
{
    foreach (int[,] board in bingoBoards)
    {
        if (checkBoard(board, BingoNumbers.Take(i).ToArray()) != 0)
        {
            Console.WriteLine(checkBoard(board, BingoNumbers.Take(i).ToArray()).ToString());
            done = 1;
            break;
        }
    }
    if (done == 1) break;
}

static int[,] ParseBingoBoard(string[] inputLines, int Position)
{
    int[][] bingoBoard = new int[5][];
    // int[][] bingoBoard = new int[5][];
    for (int i = Position; i < (Position + 5); i++)
    {
        string line = inputLines[i];
        int[] row = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        bingoBoard[i-Position] = row;
    }
    return To2D(bingoBoard);
}
//Checking for bingo 2 functions one easy one for horizontal and then another for verticle

//thx https://stackoverflow.com/questions/26291609/converting-jagged-array-to-2d-array-c-sharp
static T[,] To2D<T>(T[][] source)
{
    try
    {
        int FirstDim = source.Length;
        int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

        var result = new T[FirstDim, SecondDim];
        for (int i = 0; i < FirstDim; ++i)
            for (int j = 0; j < SecondDim; ++j)
                result[i, j] = source[i][j];

        return result;
    }
    catch (InvalidOperationException)
    {
        throw new InvalidOperationException("The given jagged array is not rectangular.");
    } 
}

//Testing
// int[,] board = {
//     {1,2,3,4,5},
//     {6,7,8,9,10},
//     {11,12,13,14,15},
//     {16,17,18,19,20},
//     {21,22,23,24,25}
// };
// int[] testvalues = {7,2,12,22,17};

// Console.WriteLine(checkBoard(board, testvalues));

static int checkBoard(int[,] board, int[] values)
{
    values = values.Distinct().ToArray();
    for (int i = 0; i < 5; i++)    
    {
        int horizontalCount = 0;
        for (int i2 = 0; i2 < 5; i2++)    
        {
            foreach (int value in values)
            {
                if (board[i,i2] == value) horizontalCount++;
            }
        }
        if (horizontalCount == 5) return totalUnselectedvalues(board, values);
    }
    // for (int i = 0; i < 5; i++)    
    // {
    //     int verticleCount = 0;
    //     for (int i2 = 0; i2 < 5; i2++)    
    //     {
    //         foreach (int value in values)
    //         {
    //             if (board[i2,i] == value) verticleCount++;
    //         }
    //     }
    //     if (verticleCount == 5) return totalUnselectedvalues(board, values);
    // }
    return 0;
}
static int totalUnselectedvalues(int[,] board, int[] values)
{
    for (int i = 0; i < 5; i++)    
    {
        for (int i2 = 0; i2 < 5; i2++)    
        {
            foreach (int value in values)
            {
                if (board[i,i2] == value) board[i,i2] = 0;
            }
        }
    }
    int returnvalue = 0;
    foreach (int j in board)
    {
       returnvalue += j;
    }
    returnvalue *= values.Last();
    return returnvalue;
}





// this is currently not gona work as 0 is in some of the boards and not in bingoNums
// static bool CheckBoard(int[,] board, int number)
// {
    // for (int i = 0; i < 5; i++)
    // {
        // int matchingAmount = 0;
        // for (int i2 = 0; i2 < 5; i2++)
        // {
            // if(board[i,i2] == 0) matchingAmount++;
        // }
        // if(matchingAmount == 5) return true;
    // }
// }
        // board.Select(x => x.Replace(number, 0)).ToArray();
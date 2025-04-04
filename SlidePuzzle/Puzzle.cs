public class Puzzle
{
    private List<int> _puzzlePieces = [1, 2, 3, 4, 5, 6, 7, 8, 0];
    public int MoveCount = 0;

    public void ShufflePuzzle()
    {
        Random rand = new Random();
        do
        {
            _puzzlePieces = _puzzlePieces.OrderBy(_ => rand.Next()).ToList();
        } while (!IsSolvable(_puzzlePieces)); 
    }

    public void PrintPuzzle()
    {
        Console.WriteLine("                     +---+---+---+");
        for (var row = 0; row < 3; row++)
        {
            Console.Write("                     |");
            for (var col = 0; col < 3; col++)
            {
                var index = row * 3 + col;
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(_puzzlePieces[index] == 0 ? " " : _puzzlePieces[index]);
                Console.ResetColor();

                Console.Write(" |");
            }
            Console.WriteLine("\n                     +---+---+---+");
        }
    }

    public bool IsPuzzleSolved()
    {
        for (int index = 0; index < 9 - 1; index++)
        {
            if (_puzzlePieces[index] != index + 1)
            {
                return false;
            }
        }
        return _puzzlePieces.Last() == 0;
    }

    public void MakeMove(int number)
    {
        int index = _puzzlePieces.IndexOf(number);
        int emptyIndex = _puzzlePieces.IndexOf(0);

        _puzzlePieces[index] = 0;
        _puzzlePieces[emptyIndex] = number;
    }

    public bool IsValidMove(int number)
    {
        var index = _puzzlePieces.IndexOf(number);
        var emptyIndex = _puzzlePieces.IndexOf(0);

        var rowForNumber = index / 3;
        var colForNumber = index % 3;

        var rowForEmpty = emptyIndex / 3;
        var colForEmpty = emptyIndex % 3;

        if (Math.Abs(rowForNumber - rowForEmpty) == 1 && colForNumber == colForEmpty)
        {
            return true;
        }
        if (Math.Abs(colForNumber - colForEmpty) == 1 && rowForNumber == rowForEmpty)
        {
            return true;
        }
        return false;
    }

    /* some logic to make sure the shuffle doesn't make the game unsolvable… */
    private static bool IsSolvable(List<int> puzzle)
    {
        var inversions = 0;
    
        for (var i = 0; i < puzzle.Count; i++)
        {
            for (var j = i + 1; j < puzzle.Count; j++)
            {
                if (puzzle[i] != 0 && puzzle[j] != 0 && puzzle[i] > puzzle[j])
                {
                    inversions++;
                }
            }
        }
        bool isEvenInversions = inversions % 2 == 0; 
        return isEvenInversions; // puzzle is only solvable if number of inversions are even
    }
}
namespace puzzle;

public class Puzzle
{
    private List<int> _puzzlePieces = [1, 2, 3, 4, 5, 6, 7, 8, 0];
    public int MoveCount = 0;

    public void ShufflePuzzle()
    {
        Random rand = new Random();
        _puzzlePieces = _puzzlePieces.OrderBy(_ => rand.Next()).ToList();
    }

    public void PrintPuzzle()
    {
        for (var row = 0; row < 3; row++)
        {
            Console.WriteLine("+---+---+---+");
            for (var col = 0; col < 3; col++)
            {
                var index = row * 3 + col;  // index/position för varje pusselbit
                Console.Write("| ");

                // om siffran är 0 gör en tom ruta, annars skriv ut siffran
                Console.ForegroundColor = ConsoleColor.Magenta; 
                Console.Write(_puzzlePieces[index] == 0 ? " " : _puzzlePieces[index]);
                Console.ResetColor();
                // Console.Write((row * 3) + col); (för att se hur spelplanen är uppbyggd)

                Console.Write(" ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("+---+---+---+"); 
    }
    
    public bool IsPuzzleSolved()
    {
        for (int index = 0; index < 9 - 1; index++) // 9 rutor i ett 3x3 grid, minus 1 för index börjar på 0
        {
            if (_puzzlePieces[index] != index + 1) 
                // index är rutorna (t.ex. 0 för den första platsen)
                // 0 1 2
                // 3 4 5
                // 6 7 8
                // index + 1 är det förväntade värdet på indexet/platsen
                // t.ex. 1 för den första platsen, 2 för den andra, usw.
                // 1 2 3
                // 4 5 6
                // 7 8 0 (0 = tom)
            // det är typ som att kolla om pusselbitarna ligger i ordning i en array
            // _puzzlePieces = [1, 2, 3, 4, 6, 5, 7, 8, 0]
            {
                return false;
            }
        }
        return _puzzlePieces.Last() == 0;
        // kolla om sista siffran är 0 (= tom)
    }
    
    public void MakeMove(int number)
    {
        int index = _puzzlePieces.IndexOf(number);
        int emptyIndex = _puzzlePieces.IndexOf(0);

        // byt plats på den valda biten och den tomma platsen
        _puzzlePieces[index] = 0; // siffran tar platsen 0 (det tomma)
        _puzzlePieces[emptyIndex] = number; // siffran 0 tar den andra siffrans plats
    }

    public bool IsValidMove(int number)
    {
        // hitta positionen för siffran som ska flyttas respektive 0 (= tom plats)
        var index = _puzzlePieces.IndexOf(number);
        var emptyIndex = _puzzlePieces.IndexOf(0);

        // aktuella koordinater för siffran respektive den tomma platsen
        // hitta rad och kolumn för den aktuella biten
        var rowForNumber = index / 3;
        var colForNumber = index % 3;

        // hitta rad och kolumn för den tomma platsen
        var rowForEmpty = emptyIndex / 3;
        var colForEmpty = emptyIndex % 3;
        
        // kolla om siffran är intill den tomma platsen (och kan flyttas)
        // genom att kolla om biten är en rad bort eller en kolumn bort
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
    
}
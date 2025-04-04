using puzzle;

Console.ForegroundColor = ConsoleColor.Cyan; 
Console.WriteLine("-`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´-");
Console.WriteLine("*                                                   *");
Console.WriteLine("  *         VÄLKOMMEN TILL SLIDEPUZZLE!           *");
Console.WriteLine("*                                                   *");
Console.WriteLine("-`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´-");
Console.ResetColor();
Console.WriteLine("\nI det här spelet ska siffrorna 1-8 flyttas runt" +
                  "\ntills de hamnar i nummerordning, såhär:");
Console.ForegroundColor = ConsoleColor.Magenta; 
Console.WriteLine("\n1 2 3" +
                  "\n4 5 6" +
                  "\n7 8  \n");
Console.ResetColor();
Console.WriteLine("Siffrorna flyttas en åt gången. " +
                  "\nDrag kan göras vågrätt och lodrätt, ej diagonalt." +
                  "\nBara siffror som ligger intill tomrummet kan flyttas.");
Console.ForegroundColor = ConsoleColor.Yellow; 
Console.Write("\n>>   Tryck ENTER för att börja spela!   <<");
Console.ReadLine();
Console.ResetColor();

Puzzle puzzle = new();
puzzle.ShufflePuzzle();

while (!puzzle.IsPuzzleSolved()) // keep the loop running 'til the puzzle is solved
{
    Console.Clear();
    
    Console.ForegroundColor = ConsoleColor.Green; 
    Console.WriteLine($"Antal drag: {puzzle.MoveCount}");
    Console.ResetColor();
        
    puzzle.PrintPuzzle();
    
    Console.Write("\nAnge en siffra (1-8) för att flytta siffran till den tomma platsen: ");
    var input = Console.ReadLine();

    if (int.TryParse(input, out int move) && move is >= 1 and <= 8)
    {
        if (puzzle.IsValidMove(move))
        {
            puzzle.MakeMove(move);
            puzzle.MoveCount++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; 
            Console.WriteLine("Ogiltigt drag – bara siffror intill tomrummet kan flyttas dit.");
            Console.ResetColor();
            Console.WriteLine("Tryck ENTER och försök igen!");
            Console.ReadLine();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.WriteLine("Ogiltig inmatning – ange ett heltal mellan 1 och 8 och skriv med siffror.");
        Console.ResetColor();
        Console.WriteLine("Tryck ENTER och försök igen!");
        Console.ReadLine();
    }
}

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("-`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´-");
Console.WriteLine("*                                                   *");
Console.WriteLine($"  *     GRATTIS! Du löste pusslet på {puzzle.MoveCount} drag!     *");
Console.WriteLine("*                                                   *");
Console.WriteLine("-`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´-");
Console.ResetColor();


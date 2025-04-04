const string h1 = "--------------------{ SlidePuzzle }--------------------\n\n";
const string logo = " \u2597\u2584\u2584\u2596\u2588 \u2584    \u2590\u258c\u2597\u259e\u2580\u259a\u2596\u2597\u2584\u2584\u2596 \u2588  \u2590\u258c\u2584\u2584\u2584\u2584\u2584 \u2584\u2584\u2584\u2584\u2584 \u2588 \u2597\u259e\u2580\u259a\u2596\n\u2590\u258c   \u2588 \u2584    \u2590\u258c\u2590\u259b\u2580\u2580\u2598\u2590\u258c \u2590\u258c\u2580\u2584\u2584\u259e\u2598 \u2584\u2584\u2584\u2580  \u2584\u2584\u2584\u2580 \u2588 \u2590\u259b\u2580\u2580\u2598\n \u259d\u2580\u259a\u2596\u2588 \u2588 \u2597\u259e\u2580\u259c\u258c\u259d\u259a\u2584\u2584\u2596\u2590\u259b\u2580\u2598      \u2588\u2584\u2584\u2584\u2584 \u2588\u2584\u2584\u2584\u2584 \u2588 \u259d\u259a\u2584\u2584\u2596\n\u2597\u2584\u2584\u259e\u2598\u2588 \u2588 \u259d\u259a\u2584\u259f\u258c     \u2590\u258c                    \u2588      \n                                                \n                                                ";
var random = new Random();

/* -------------------------------- Welcome Screen ---------------------------------------*/

Console.ForegroundColor = ConsoleColor.Green; 
Console.WriteLine(h1);
foreach (var letter in logo)
{
    SetRandomColor();
    Console.Write(letter);
}
Console.ForegroundColor = ConsoleColor.Cyan; 
Console.WriteLine("\nI det här spelet ska siffrorna 1-8 flyttas runt" +
                  "\ntills de hamnar i nummerordning, såhär:");
Console.ForegroundColor = ConsoleColor.Magenta; 
Console.WriteLine("\n                                    1 2 3" +
                  "\n                                    4 5 6" +
                  "\n                                    7 8  \n");
Console.ForegroundColor = ConsoleColor.Cyan; 
Console.WriteLine("• Siffrorna flyttas en åt gången. " +
                  "\n• Drag kan göras vågrätt och lodrätt, ej diagonalt." +
                  "\n• Bara siffror som ligger intill tomrummet kan flyttas.");
Console.ForegroundColor = ConsoleColor.Yellow; 
Console.Write("\n\n         >>  Tryck ENTER för att börja spela!  <<\n");
Console.Read();
Console.ResetColor();

/* ---------------------------------- New Puzzle -----------------------------------------*/

Puzzle puzzle = new();
puzzle.ShufflePuzzle();

while (!puzzle.IsPuzzleSolved()) // keep the loop running 'til the puzzle is solved
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green; 
    Console.WriteLine(h1);
    Console.ResetColor();
    Console.WriteLine("Antal drag: " + puzzle.MoveCount + "\n");
    
    puzzle.PrintPuzzle();
    
    Console.ForegroundColor = ConsoleColor.Cyan; 
    Console.Write("\n\n\nAnge en siffra (1-8) för att flytta den till tomrummet: ");
    var input = Console.ReadLine();
    Console.ResetColor();

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

/* ---------------------------------- Winner Screen ---------------------------------------*/
    
Console.Clear();

Console.ForegroundColor = ConsoleColor.Green; 
Console.WriteLine(h1);
foreach (var letter in logo)
{
    SetRandomColor();
    Console.Write(letter);
}
Console.WriteLine();
var winText =
    "-`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´-\n" +
    "*                                      *            *\n" +
    " *       *          BRA JOBBAT!            *       *\n" +
    "*    *                                              *\n" +
    $" *          Du löste pusslet på {puzzle.MoveCount} drag!           *\n" +
    "*      *                                       *    *\n" +
    "-`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´- . -`*´-\n";
foreach (var letter in winText)
{
    SetRandomColor();
    Console.Write(letter);
}
Console.ResetColor();
return;

void SetRandomColor()
{
    var color = (ConsoleColor)random.Next(1, 16); 
    Console.ForegroundColor = color;
}
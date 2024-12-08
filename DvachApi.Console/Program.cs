using DvachApi.Common.Models;

List<Board>? boards = Board.GetBoards();

if (boards != null)
    foreach (var board in boards)
    {
        Console.WriteLine($"{board.Id} - {board.Name}. {board.Category}");
        Console.WriteLine("--------------------------------------------------------------------");
    }

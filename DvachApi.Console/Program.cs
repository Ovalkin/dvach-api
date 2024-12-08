using DvachApi.Common.Models;

List<Board>? boards = Board.GetBoards();


Board bred = boards![0].LoadThreads();
foreach (var thread in bred.Threads)
{
    Console.WriteLine(thread.Comment);
}

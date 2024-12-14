using DvachApi.Common.Models;

List<Board> boards = Board.GetBoards();
boards[0].LoadThreads();
boards[0].Threads[1].LoadPosts();
Console.WriteLine();
using System.Runtime.InteropServices;

public class Game
{
    private Stack<ICommand> _executedCommands = new Stack<ICommand>();
    private Stack<ICommand> _revertedCommands = new Stack<ICommand>();
    private Board _board = new Board();
    private bool _running = false;
    public void Run()
    {
        _board.CreateRandomTiles(2);
        _board.Draw();
        _running = true;
        while (_running)
        {
            var key = Console.ReadKey();
            if (key.Key.Equals(ConsoleKey.Z) && key.Modifiers.Equals(ConsoleModifiers.Control))
                revertLastCommand();
            else
            {
                if (key.Key.Equals(ConsoleKey.LeftArrow))
                    executeCommand(new MoveLeftCommand(_board));
                else if (key.Key.Equals(ConsoleKey.RightArrow))
                    executeCommand(new MoveRightCommand(_board));
                else if (key.Key.Equals(ConsoleKey.UpArrow))
                    executeCommand(new MoveUpCommand(_board));
                else if (key.Key.Equals(ConsoleKey.DownArrow))
                    executeCommand(new MoveDownCommand(_board));
                else if (key.Key.Equals(ConsoleKey.Escape))
                    gameOver();
                _board.Draw();
            }
        }
    }
    private void gameOver()
    {
        Console.Clear();
        Console.WriteLine("Você perdeu!");
        Console.WriteLine("Pressione qualquer tecla...");
        Console.ReadKey();
        _running = false;
    }
    private void executeCommand(ICommand command)
    {
        command.Execute();
        _executedCommands.Push(command);
        if (!_board.CreateRandomTiles(1))
            gameOver();
    }
    private void revertLastCommand()
    {
        if (_executedCommands.Count > 0)
        {
            var commandToRevert = _executedCommands.Pop();
            commandToRevert.Revert();
            _revertedCommands.Push(commandToRevert);
        }
    }
}
public abstract class MoveCommand : ICommand
{
    protected Board _board;
    protected int[,] _oldState;
    public MoveCommand(Board board)
    {
        _board = board;
        _oldState = _board.GetState();
    }
    public abstract void Execute();
    public void Revert() => _board.SetState(_oldState);
}

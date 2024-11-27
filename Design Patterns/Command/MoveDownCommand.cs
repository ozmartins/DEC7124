public class MoveDownCommand : MoveCommand
{
    public MoveDownCommand(Board board) : base(board) { }
    public override void Execute() => _board.MoveDown();
}

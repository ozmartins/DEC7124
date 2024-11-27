public class MoveUpCommand : MoveCommand
{
    public MoveUpCommand(Board board) : base(board) { }
    public override void Execute() => _board.MoveUp();
}

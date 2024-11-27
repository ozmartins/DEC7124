public class MoveRightCommand : MoveCommand
{
    public MoveRightCommand(Board board) : base(board) { }
    public override void Execute() => _board.MoveRight();
}

public class MoveLeftCommand : MoveCommand
{
    public MoveLeftCommand(Board board) : base(board) { }
    public override void Execute() => _board.MoveLeft();
}

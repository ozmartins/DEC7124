public class Board
{
    private int[,] _state = new int[4, 4];
    public int[,] GetState()
    {
        int[,] stateCopy = new int[4, 4];
        copy(_state, stateCopy);
        return stateCopy;
    }
    public void SetState(int[,] state) => copy(state, _state);
    public void MoveLeft()
    {
        for (var y = 0; y < 4; y++)
            for (var x = 1; x < 4; x++)
                if (moveTo(x, y, x - 1, y)) MoveLeft();
    }
    public void MoveRight()
    {
        for (var y = 0; y < 4; y++)
            for (var x = 0; x < 3; x++)
                if (moveTo(x, y, x + 1, y)) MoveRight();
    }
    public void MoveUp()
    {
        for (var x = 0; x < 4; x++)
            for (var y = 1; y < 4; y++)
                if (moveTo(x, y, x, y - 1)) MoveUp();
    }
    public void MoveDown()
    {
        for (var x = 0; x < 4; x++)
            for (var y = 0; y < 3; y++)
                if (moveTo(x, y, x, y + 1)) MoveDown();
    }
    public bool CreateRandomTiles(int quantity)
    {
        if (!hasEmptySpaces()) return false;
        var randon = new Random();
        for (int i = 0; i < quantity; i++)
        {
            var x = randon.Next(0, 4);
            var y = randon.Next(0, 4);
            while (_state[x, y] > 0)
            {
                x = randon.Next(0, 4);
                y = randon.Next(0, 4);
            }
            _state[x, y] = 2;
        }
        return true;
    }
    public void Draw()
    {
        Console.Clear();
        for (var y = 0; y < 4; y++)
        {
            Console.WriteLine("+------+------+------+------+");
            for (var x = 0; x < 4; x++)
                Console.Write($"| {_state[x, y],4} ");
            Console.WriteLine("|");
        }
        Console.WriteLine("+------+------+------+------+");
    }
    private bool moveTo(int xOrigin, int yOrigin, int xDestination, int yDestination)
    {
        if (canMove(xOrigin, yOrigin, xDestination, yDestination))
        {
            _state[xDestination, yDestination] += _state[xOrigin, yOrigin];
            _state[xOrigin, yOrigin] = 0;
            return true;
        }
        return false;
    }
    private bool canMove(int xOrigin, int yOrigin, int xDestination, int yDestination)
        => _state[xOrigin, yOrigin] > 0 && (_state[xDestination, yDestination] == 0 || _state[xDestination, yDestination] == _state[xOrigin, yOrigin]);
    private bool hasEmptySpaces()
    {
        for (var x = 0; x < 4; x++)
            for (var y = 0; y < 3; y++)
                if (_state[x, y] == 0)
                    return true;
        return false;
    }
    private void copy(int[,] from, int[,] to)
    {
        for (var y = 0; y < 4; y++)
            for (var x = 0; x < 4; x++)
                to[x, y] = from[x, y];
    }
}
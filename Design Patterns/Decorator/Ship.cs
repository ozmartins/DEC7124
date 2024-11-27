public class Ship : IShip
{
    public int Health { get; private set; } = 100;
    public void ApplyDamage(int damage) => Health -= damage <= Health ? damage : Health;
}
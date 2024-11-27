public class ShipDecorator : IShip
{
    private IShip _ship;
    public ShipDecorator(IShip ship) => _ship = ship;
    public void ApplyDamage(int damage) => _ship.ApplyDamage(damage);
}
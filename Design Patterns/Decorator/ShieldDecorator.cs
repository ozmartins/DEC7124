public class ShieldDecorator : IShip
{
    private IShip _ship;
    public ShieldDecorator(IShip ship) => _ship = ship;
    public void ApplyDamage(int damage) => _ship.ApplyDamage((int)(damage * 0.6));
}
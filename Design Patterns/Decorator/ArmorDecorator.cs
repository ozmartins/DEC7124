public class ArmorDecorator : IShip
{
    private IShip _ship;
    public ArmorDecorator(IShip ship) => _ship = ship;
    public void ApplyDamage(int damage) => _ship.ApplyDamage((int)(damage * 0.8));
}
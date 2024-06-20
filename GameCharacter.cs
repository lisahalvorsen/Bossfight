namespace Bossfight;

public class GameCharacter
{
    private string _name;
    private int _health;
    private int _stamina;
    private int _originalStamina;
    private int _strength;

    public GameCharacter(string name, int health, int stamina, int originalStamina, int strength)
    {
        _name = name;
        _health = health;
        _stamina = stamina;
        _originalStamina = originalStamina;
        _strength = strength;
    }

    public string Name => _name;
    public int Health
    {
        get => _health;
        set => _health = value;
    }

    public int Strength => _strength;
    public int Stamina
    {
        get => _stamina;
        set => _stamina = value;
    }

    public int OriginalStamina => _originalStamina;

    public void Fight(GameCharacter opponent)
    {
        if (_stamina >= 10)
        {
            opponent.Health -= _strength;
            Stamina -= 10;
            Console.WriteLine(
                $"\n{_name} hits {opponent.Name} with {_strength} damage, {opponent.Name} has {opponent.Health} health left.");
        }
        else
        {
            Recharge();
        }
    }

    private void Recharge()
    {
        _stamina = _originalStamina;
        Console.WriteLine($"\n{Name} took a break to recharge.");
    }

    public void GenerateRandomStrength(int min, int max)
    {
        Random randomStrength = new Random();
        _strength = randomStrength.Next(min, max);
    }
}
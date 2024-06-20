namespace Bossfight;

public class BossfightManager
{
    private bool _gameActive;
    private GameCharacter _mario;
    private GameCharacter _bowser;

    public void PrepareForGame()
    {
        _gameActive = true;
        CreatePlayers();
        GameOn();
    }

    private void CreatePlayers()
    {
        _mario = new GameCharacter("Mario", 100, 40, 40, 20);
        _bowser = new GameCharacter("Bowser", 400, 10, 10, 0);
    }

    private void GameOn()
    {
        Console.WriteLine("Let's see a fight between everyone's favorite super Mario and the almighty Bowser!");
        Console.WriteLine("Press any key to start the fight.");
        var input = Console.ReadKey(true).KeyChar - '0';

        while (_gameActive)
        {
            _bowser.GenerateRandomStrength(0, 31);
            _mario.Fight(_bowser);
            _bowser.Fight(_mario);
            CheckWinner();
        }
    }

    private void CheckWinner()
    {
        if (_mario.Health <= 0)
        {
            Console.WriteLine($"\nThe almighty {_bowser.Name} was too strong, and therefore he wins!");
            _gameActive = false;
        }
        else if (_bowser.Health <= 0)
        {
            Console.WriteLine($"\nOnce again we can count on super {_mario.Name}, and he wins!");
            _gameActive = false;
        }
    }
}
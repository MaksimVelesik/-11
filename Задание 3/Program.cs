public interface ICommand
{
    void Execute();
}

public class PlayCommand : ICommand
{
    private MusicPlayer _musicPlayer;

    public PlayCommand(MusicPlayer musicPlayer)
    {
        _musicPlayer = musicPlayer;
    }

    public void Execute()
    {
        _musicPlayer.Play();
    }
}

public class PauseCommand : ICommand
{
    private MusicPlayer _musicPlayer;

    public PauseCommand(MusicPlayer musicPlayer)
    {
        _musicPlayer = musicPlayer;
    }

    public void Execute()
    {
        _musicPlayer.Pause();
    }
}

public class StopCommand : ICommand
{
    private MusicPlayer _musicPlayer;

    public StopCommand(MusicPlayer musicPlayer)
    {
        _musicPlayer = musicPlayer;
    }

    public void Execute()
    {
        _musicPlayer.Stop();
    }
}

public class MusicPlayer
{
    public void Play()
    {
        Console.WriteLine("Playing music.");
    }

    public void Pause()
    {
        Console.WriteLine("Music paused.");
    }

    public void Stop()
    {
        Console.WriteLine("Music stopped.");
    }
}

public class PlayerRemote
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main(string[] args)
    {
        MusicPlayer musicPlayer = new MusicPlayer();

        ICommand playCommand = new PlayCommand(musicPlayer);
        ICommand pauseCommand = new PauseCommand(musicPlayer);
        ICommand stopCommand = new StopCommand(musicPlayer);

        PlayerRemote remote = new PlayerRemote();

        remote.SetCommand(playCommand);
        remote.PressButton();

        remote.SetCommand(pauseCommand);
        remote.PressButton();

        remote.SetCommand(stopCommand);
        remote.PressButton();
    }
}
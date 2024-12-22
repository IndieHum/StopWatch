class StopwatchApp
{
  private static TimeSpan _elapsed;
  private static Thread _threadTime;
  private static bool _running = false;

  static void Main(string[] args)
  {
    while (true)
    {
      Console.WriteLine("*** SimpleStopWatch ***");
      Console.WriteLine("command: start | stop | reset | exit");

      Arrow();
      string? input = Console.ReadLine();

      switch (input)
      {
        case "start":
          Start();
          break;
        case "stop":
          Stop();
          break;
        case "reset":
          Reset();
          break;
        case "exit":
          Console.WriteLine("bye bye!");
          return;
        default:
          Console.WriteLine("command: start | stop | reset | exit");
          break;
      }
    }
  }

  static void Reset()
  {
    _threadTime.Join();
    _elapsed = TimeSpan.Zero;
    _reseted = !_reseted ? true : false;

    Console.WriteLine("StopWatch Reseted!\n");
  }

  static void Arrow() => Console.Write("=> ");

  private static void Stop()
  {
    if (!_running) { Console.WriteLine("Does Not Started Yet!\n"); return; }

    _running = false;
    _threadTime.Join();

    Console.WriteLine("Timer Stoped!");
    Console.WriteLine($"Timer: {_elapsed.ToString(@"hh\:mm\:ss")}\n");
  }

  private static void Start()
  {
    if (_running) { Console.WriteLine("Already Started!\n"); return; }

    _running = true;
    _threadTime = new Thread(StartTimer);
    _threadTime.Start();

    Console.WriteLine("Timer Started!\n");
  }

  private static void StartTimer()
  {
    DateTime firstPoint = DateTime.Now;

    while (_running)
    {
      _elapsed = DateTime.Now - firstPoint;
      Thread.Sleep(1000);
    }
  }
}

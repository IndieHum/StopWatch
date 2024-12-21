class StopwatchApp
{
  private static bool _running = false;
  private static double _timeTemp = 0;

  static void Main()
  {
    Console.WriteLine("Basic Stopwatch (No Gui stuff here!)");
    Console.WriteLine("----------------");
    Console.WriteLine("Commands: start, stop, reset, exit");

    while (true)
    {
      Console.Write("Enter command: ");
      string command = Console.ReadLine().ToLower();

      switch (command)
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
          Stop();
          Console.WriteLine("Exiting the stopwatch. Goodbye!");
          return;
        default:
          Console.WriteLine("Commands: start, stop, reset, exit");
          break;
      }
    }
  }

  private static void Start()
  {
    if (_running)
    {
      Console.WriteLine("The stopwatch is already running.");
      return;
    }

    _running = true;
    // not done!
    Console.WriteLine("Stopwatch started.");
  }

  private static void Stop()
  {
    if (!_running)
    {
      Console.WriteLine("The stopwatch is not running.");
      return;
    }

    _running = false;
    _timerThread.Join();
    Console.WriteLine("Stopwatch stopped.");
    Console.WriteLine($"Elapsed time: {_elapsed}");
  }

  private static void Reset()
  {
    Stop();
    _elapsed = TimeSpan.Zero;
    Console.WriteLine("Stopwatch reset.");
  }

  private static void TimerLoop()
  {
    DateTime startTime = DateTime.Now;

    while (_running)
    {
      _elapsed = DateTime.Now - startTime;
      Thread.Sleep(10); // Adjust for smooth updates while minimizing CPU usage
    }
  }
}

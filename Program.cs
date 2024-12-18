class StopWatch
{
  static int Second = 0;
  static int Minute = 0;
  static void Main(string[] args)
  {
    bool isDone = true;
    while (isDone)
    {
      Console.Clear();
      Console.WriteLine("*** Stop Watch ***");
      Console.WriteLine("1) start \n2) Continue \n3) exit");
      Console.WriteLine($"\nlast activity: {0}s\n");

      Arrow();
      string input = Console.ReadLine();

      if (int.TryParse(input, out int userInput))
      {
        switch (userInput)
        {
          case 1:
            startWatch();
            break;
          case 2:
            break;
          case 3:
            Console.WriteLine("Goodbye...");
            isDone = false;
            break;
          default:
            Console.WriteLine("Wrong number!");
            break;
        }
      }
      else Console.WriteLine("Wrong!");
    }
  }

  static void startWatch()
  {
    bool isRunning = true;
    while (isRunning)
    {
      if (Second == 10) { Minute++; Second = 0; }
      Console.Clear();
      Console.WriteLine(Minute >= 10 || Second > 10 ? $"{Minute}:{Second}" : $"0{Minute}:0{Second}");
      Second++;
      System.Threading.Thread.Sleep(1000);
    }
  }

  static void Arrow() => Console.Write("=> ");
}

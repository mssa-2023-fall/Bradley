using System.Timers;
using System.IO;
using EventExcercise;

NoisyListSample();

void NoisyListSample()
{
    NoisyList<string> list = new NoisyList<string>(new string[] { "Apple", "Banana", "Cherry" }) { Name = "StringList" };
    NoisyList<int> list2 = new NoisyList<int>(new int[] { 1, 2, 3 }) { Name = "IntList" };
    list.OnItemAdded += 
        (l, arg) => Console.WriteLine($"{l.Name} added a new item: {arg.ItemAdded} in position {arg.ItemPositionInList} on {arg.InsertionTimestamp}");
    list2.OnItemRemoved += List2_OnItemRemoved<int>;
    list.OnItemRemoved += List2_OnItemRemoved<string>;

}

void List2_OnItemRemoved<T>(NoisyList<T> arg1, (int CountBeforeRemove, int CountAfterRemove) arg2), T? ItemRemoved,  RemoveTimeStamp), arg2)
    {
    Console.WriteLine($"{arg2.ItemRemoved} was remove from {arg1.Name} from {arg.ItemPositionInList} on {arg.InsertionTimestamp}");

}

void FileSystemWatcherSample()
{
    //create instance of FSW, supply directory to watch
    using var watcher = new FileSystemWatcher(@"C:\test");
    //Configure watch to notify on changes of the following attributes
    // | is a bitwise or to combine the properties to monitor for changes
    watcher.NotifyFilter = NotifyFilters.Attributes
                         | NotifyFilters.CreationTime
                         | NotifyFilters.DirectoryName
                         | NotifyFilters.FileName
                         | NotifyFilters.Size;
    // connect event handler to the event raised by the FSW
    watcher.Changed += (s, arg) => Console.WriteLine($"{arg.Name} modified");
    watcher.Created += (s, arg) => Console.WriteLine($"{arg.Name} created");
    watcher.Deleted += (s, arg) => Console.WriteLine($"{arg.Name} deleted");
    watcher.Renamed += (s, arg) => Console.WriteLine($"{arg.Name} renamed");
    watcher.EnableRaisingEvents = true;
    Console.WriteLine("Press enter to stop the program");
    Console.ReadLine();
}




void Handler(object s, ElapsedEventArgs arg)
{
    Console.WriteLine($"Timer with following interval:{(s as System.Timers.Timer).Interval}-{arg.SignalTime}");
}

void TimerSample()
{
    System.Timers.Timer aTimer = new System.Timers.Timer();
    aTimer.Interval = 2000;

    // Hook up the Elapsed event for the timer. 
    aTimer.Elapsed += (s, arg) => Console.WriteLine($"Timer is enabled:{(s as System.Timers.Timer).Enabled} last fired at:{arg.SignalTime} ");
    aTimer.Elapsed += Handler;
    //this is also referred to as callback in javascript
    // Have the timer fire repeated events (true is the default)
    aTimer.AutoReset = true;

    // Start the timer
    aTimer.Enabled = true;

    Console.WriteLine("Press the Enter key to remove Handler from Elaped Delegate");
    Console.ReadLine();
    aTimer.Elapsed -= Handler;

    Console.WriteLine("Press the Enter key to end the program");
    Console.ReadLine();
}

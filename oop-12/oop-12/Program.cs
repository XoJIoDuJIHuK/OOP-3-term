using System.IO.Compression;
class UserException : Exception
{
    public string _message;
    public UserException(string message)
    {
        _message = message;
    }
}
static class TOVLog
{
    static public void Write(string str)
    {
        File.AppendAllText("TOVlogfile.txt", $"{DateTime.Now}, {str}, " +
            $"{new FileInfo("TOVlogfile.txt").FullName}\n");
    }
}
static class TOVDiskInfo
{
    static DriveInfo[] allDrives = DriveInfo.GetDrives();
    static public void Write()
    {
        TOVLog.Write("Written disk info");
        foreach (var d in allDrives)
        {
            Console.WriteLine("Drive name: {0}", d.Name);
            Console.WriteLine("Drive type: {0}", d.DriveType);
            if (!d.IsReady) continue;
            Console.WriteLine("Volume Label: {0}", d.VolumeLabel);
            Console.WriteLine("File system: {0}", d.DriveFormat);
            Console.WriteLine("Root: {0}", d.RootDirectory);
            Console.WriteLine("Total size: {0}", d.TotalSize);
            Console.WriteLine("Free size: {0}", d.TotalFreeSpace);
            Console.WriteLine("Available: {0}", d.AvailableFreeSpace);
        }
    }
}
static class TOVDirInfo
{
    static public void Write(string path)
    {
        if (!Directory.Exists(path)) throw new UserException($"Directory {path} does not exist");
        TOVLog.Write("Written directory info");
        if (Directory.Exists(path))
        {
            Console.WriteLine("SubDir:");
            string[] dirs = Directory.GetDirectories(path);
            Console.WriteLine($"Directories amount: {dirs.Length}");
            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            string[] files = Directory.GetFiles(path);
            Console.WriteLine($"Amount of files: {files.Length}");
            Console.WriteLine($"Created: {Directory.GetCreationTime(path)}");
            Console.WriteLine("Files:");
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }
    }
}
static class TOVFileInfo
{
    static public void Write(string path)
    {
        if (!File.Exists(path)) throw new UserException($"File {path} does not exist");
        TOVLog.Write("Written file info");
        FileInfo f = new FileInfo(path);
        if (!f.Exists) throw new UserException($"File {path} doesn't exist");
        Console.WriteLine($"File name: {f.FullName}");
        Console.WriteLine($"Size: {f.Length}");
        Console.WriteLine($"Extension: {f.Extension}");
        Console.WriteLine($"Path: {f.DirectoryName}");
        Console.WriteLine($"Created: {f.CreationTime}");
        Console.WriteLine($"Edited: {f.LastWriteTime}");
    }
}
//static class TOVFileManager
//{
//    static public void TaskAFirstHalf(string driveName)//имя диска задавать как С:\
//    {
//        TOVLog.Write($"Written disk {driveName} info");
//        var allDrives = DriveInfo.GetDrives();
//        bool driveFound = false;
//        foreach (var d in allDrives)
//        {
//            if (d.Name == driveName)
//            {
//                Console.WriteLine("папки");
//                foreach (var p in Directory.GetDirectories(driveName))
//                {
//                    Console.WriteLine(p);
//                }
//                Console.WriteLine("файлы");
//                foreach (var p in Directory.GetFiles(driveName))
//                {
//                    Console.WriteLine(p);
//                }
//                driveFound = true;
//                break;
//            }
//        }
//        if (!driveFound) throw new UserException($"Drive {driveName} does not exist");
//    }
//    static public void TaskASecondHalf()//работает
//    {
//        TOVLog.Write($"Created folder and file, copied, moved and deleted file");
//        if (Directory.Exists("TOVInspect")) throw new UserException($"Folder TOVInspect already exists");
//        Directory.CreateDirectory("TOVInspect");
//        File.WriteAllText("TOVdirinfo.txt", Directory.GetLastAccessTime("TOVInspect").ToString());
//        if (File.Exists("TOVdirinfoCOPY")) throw new UserException($"File TOVdirinfoCOPY.txt already exists");
//        File.Copy("TOVdirinfo.txt", "TOVdirinfoCOPY.txt");
//        File.Move("TOVdirinfoCOPY.txt", "TOVdirinfoRENAMED.txt");
//        File.Delete("TOVdirinfo.txt");
//    }
//    static public void TaskB(string path, string ext)//точно работает, но расширение должно быть с точкой
//    {
//        TOVLog.Write($"Copied files with extension {ext} to {path}");
//        if (Directory.Exists("TOVFiles")) throw new UserException($"Folder TOVFiles already exists");
//        Directory.CreateDirectory("TOVFiles");
//        IEnumerable<string> files = from f in Directory.GetFiles(path) where new FileInfo(f).Extension ==
//                                        ext select f; ;
//        foreach (var f in files)
//        {
//            FileInfo fi = new FileInfo(f);
//            if (File.Exists(@$"TOVFiles\{fi.Name}")) throw new UserException($"File TOVFiles\\{fi.Name} " +
//                $"already exists");
//            File.Copy($"{f}", Path.Combine("TOVFiles", fi.Name));
//        }
//        Directory.Move("TOVFiles", @"TOVInspect\TOVFiles");
//    }
//    static public void TaskC()//работает
//    {
//        TOVLog.Write($"Created zip-archive");
//        if (File.Exists("zip.zip")) throw new UserException("zip.zip already exists");
//        ZipFile.CreateFromDirectory(@"TOVInspect\TOVFiles", "zip.zip");
//        ZipFile.ExtractToDirectory("zip.zip", "new unzipped");
//    }
//    static bool Predicate(DateTime dt, string method = "year", bool interval = false, int start = 0, int end = 0)
//    {
//        int dtValue = 0;
//        switch (method)
//        {
//            case "year":
//                {
//                    dtValue = dt.Year;
//                    break;
//                }
//            case "month":
//                {
//                    dtValue = dt.Month;
//                    break;
//                }
//            case "day":
//                {
//                    dtValue = dt.Day;
//                    break;
//                }
//            case "hour":
//                {
//                    dtValue = dt.Hour;
//                    break;
//                }
//            case "minute":
//                {
//                    dtValue = dt.Minute;
//                    break;
//                }
//            case "second":
//                {
//                    dtValue = dt.Second;
//                    break;
//                }
//            default: break;//вставить новое исключение
//        }
//        if (interval) return (dtValue <= end && dtValue >= start);
//        else return (dtValue == start);
//    }
//    static public void Task07(string method = "year", bool interval = false, int start = 0, int end = 0)
//    {
//        TOVLog.Write($"Written lines based on {method} {start}");
//        if (!File.Exists("TOVlogfile.txt")) throw new UserException("Task07: TOVlogfile does not exist");
//        IEnumerable<string> lines = from l in File.ReadAllLines("TOVlogfile.txt")
//                                    where Predicate(DateTime.Parse(l.Substring(0, 19)), method, interval, 
//                                        start, end)
//                                    select l;
//        IEnumerable<string> linesOfThisHour = from l in File.ReadAllLines("TOVlogfile.txt")
//                                    where Predicate(DateTime.Parse(l.Substring(0, 19)), "hour", false, 
//                                        DateTime.Now.Hour)
//                                    select l;
//        Console.WriteLine("Task07 lines:");
//        foreach(string line in lines) { Console.WriteLine(line); }
//        Console.WriteLine("Lines of this hour:");
//        foreach (string line in linesOfThisHour) { Console.WriteLine(line); }
//    }
//}
//class Program
//{
//    const string FIO = "TOV";
//    static void ClassNameStartsWithFIOCheck(Type type)
//    {
//        if (type.Name.Substring(0, 3) == FIO) throw new UserException("Class name doesn't start with FIO");
//    }
//    static void Main()//вроде пашет
//    {
//        try
//        {
//            TOVDirInfo.Write("new folder");
//            TOVDiskInfo.Write();
//            TOVFileInfo.Write("TOVlogfile.txt");
//            TOVFileManager.TaskAFirstHalf("D:\\");
//            TOVFileManager.TaskASecondHalf();
//            TOVFileManager.TaskB("new folder", ".txt");
//            TOVFileManager.TaskC();
//            Console.WriteLine("\nTask07");
//            TOVFileManager.Task07("day", false, 26);
//        }
//        catch (UserException e)
//        {
//            Console.WriteLine("ERROR: "+ e._message);
//        }
//    }
//}
////Обработка ошибок есть, проверка того, начинается ли класс с ФИО, есть, но не используется, потому что зачем
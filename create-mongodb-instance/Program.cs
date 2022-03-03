namespace create.mongodb.instance
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using TextCopy;
    using Console = Colorful.Console;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 3) Usage();
            if (args[0] == "-h" || args[0] == "--help") Usage();
            if (args[2] != "y" && args[2] != "n") Usage();

            var dbPath = args[0];
            var port = args[1];

            try { Directory.CreateDirectory(dbPath); }
            catch(Exception e) { Console.Error.WriteLine($"Exception = {e.Message}"); }

            const string cmd = "mongod";
            var p = new Process { StartInfo = new ProcessStartInfo(cmd) };
            p.StartInfo.Arguments = $"--dbpath {dbPath} --port {port}";
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(cmd)!;
            p.StartInfo.CreateNoWindow = true; // so it can run in the background
            p.StartInfo.UseShellExecute = false;
            p.Start();

            Console.WriteLine("\nMongoDB instance created successfully:");
            Console.Write("  connection string = ");
            Console.Write($"mongodb://localhost:{port}\n", Color.Lime);
            Console.Write("  dbPath = ");
            Console.Write($"{Path.GetFullPath(dbPath)}\n", Color.Lime);
            Console.Write("  port = ");
            Console.Write($"{port}\n", Color.Lime);

            var pid = p.Id;
            Console.Write("  pid = ");
            Console.Write($"{pid}\n", Color.Lime);

            var killCmd = $"taskkill /F /PID {pid}";
            if (args[2] == "y") ClipboardService.SetText(killCmd);
            
            Console.WriteLine("\nTo kill this instance run: ");
            Console.Write($"  '{killCmd}'", Color.Red);
            Console.Write(" (copied to clipboard = ");
            Console.Write($"{args[2] == "y"}", Color.Lime);
            Console.Write(")\n\n");
        }

        private static void Usage()
        {
            Console.Write("  Usage: ");
            Console.Write("create-mongodb-instance [file-path-to-db] [local-port-to-use] [copy-taskkill-cmd-to-clipboard: y | n]\n", Color.Red);
            Console.Write("  Example: ");
            Console.Write("create-mongodb-instance C:\\data 27017 y\n", Color.Lime);
            Environment.Exit(0);
        }
    }
}
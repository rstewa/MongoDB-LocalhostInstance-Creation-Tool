namespace create.mongodb.instance
{
    using System.Diagnostics;
    using System.IO;
    using System.Drawing;
    using Console = Colorful.Console;

    internal static class Program
    {
        private static void usage()
        { 
            Console.WriteLine("Usage: create-mongodb-instance [file-path-to-db] [local-port-to-use]\n" +
                              "Example: create-mongodb-instance C:\\data 27017");
        }
        private static void Main(string[] args)
        {
            if (args.Length != 2 ||
                string.CompareOrdinal(args[0], "-h") == 0 || 
                string.CompareOrdinal(args[0], "--help") == 0)
            {
                usage();
                return;
            }

            // todo: check these lol
            var dbPath = args[0];
            var port = args[1];

            if (!Directory.Exists(dbPath)) { Directory.CreateDirectory(dbPath); }

            const string cmd = "mongod";
            var p = new Process { StartInfo = new ProcessStartInfo(cmd) };
            p.StartInfo.Arguments = $"--dbpath {dbPath} --port {port}";
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(cmd)!;
            p.StartInfo.CreateNoWindow = true; // so it can run in the background
            p.StartInfo.UseShellExecute = false;
            p.Start();
            
            Console.WriteLine("\nMongoDB instance created successfully...");
            Console.Write("  connection string = ");
            Console.Write($"mongodb://localhost:{port}\n", Color.Lime);
            Console.Write("  dbPath = ");
            Console.Write($"{Path.GetFullPath(dbPath)}\n", Color.Lime);
            Console.Write("  port = ");
            Console.Write($"{port}\n", Color.Lime);

            var pid = p.Id;
            Console.Write("  pid = ");
            Console.Write($"{pid}\n", Color.Lime);
            
            Console.WriteLine("\nRun the following command in Command Prompt or Powershell to kill this instance:");
            Console.Write("  cmd: ");
            Console.Write($"taskkill /F /PID {pid}\n", Color.Red);
        }
    }
}
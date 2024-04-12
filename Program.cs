namespace fileSystem1_dz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Test";

            Console.WriteLine("1. Create Directory");
            Console.WriteLine("2. Delete Directory");
            Console.WriteLine("3. Create File");
            Console.WriteLine("4. Delete File");
            Console.WriteLine("5. Get Directory Size");
            Console.WriteLine("6. Get File Meta Information");
            Console.WriteLine("Enter your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter directory name:");
                    string newDirectory = Path.Combine(directoryPath, Console.ReadLine());
                    Directory.CreateDirectory(newDirectory);
                    Console.WriteLine($"Directory '{newDirectory}' created successfully.");
                    break;
                case 2:
                    Console.WriteLine("Enter directory name to delete:");
                    string deleteDirectory = Path.Combine(directoryPath, Console.ReadLine());
                    Directory.Delete(deleteDirectory, true);
                    Console.WriteLine($"Directory '{deleteDirectory}' deleted successfully.");
                    break;
                case 3:
                    Console.WriteLine("Enter file name:");
                    string newFile = Path.Combine(directoryPath, Console.ReadLine());
                    File.Create(newFile).Close();
                    Console.WriteLine($"File '{newFile}' created successfully.");
                    break;
                case 4:
                    Console.WriteLine("Enter file name to delete:");
                    string deleteFile = Path.Combine(directoryPath, Console.ReadLine());
                    File.Delete(deleteFile);
                    Console.WriteLine($"File '{deleteFile}' deleted successfully.");
                    break;
                case 5:
                    Console.WriteLine("Enter directory name to get size:");
                    string getDirSize = Path.Combine(directoryPath, Console.ReadLine());
                    long size = GetDirectorySize(getDirSize);
                    Console.WriteLine($"Size of directory '{getDirSize}' is {size} bytes.");
                    break;
                case 6:
                    Console.WriteLine("Enter file name to get meta information:");
                    string getFileMeta = Path.Combine(directoryPath, Console.ReadLine());
                    FileInfo fileInfo = new FileInfo(getFileMeta);
                    Console.WriteLine($"File Name: {fileInfo.Name}");
                    Console.WriteLine($"File Size: {fileInfo.Length} bytes");
                    Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");
                    Console.WriteLine($"Last Access Time: {fileInfo.LastAccessTime}");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        public static long GetDirectorySize(string path)
        {
            long size = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }
            return size;
        }
    }
}

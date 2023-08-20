namespace FileWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Otus";
            string subpath = @"TestDir1";
            string secondSubpath = @"TestDir2";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            dirInfo.CreateSubdirectory(secondSubpath);
            for (int i = 1; i < 11; i++)
            {
                using (FileStream file1 = new FileStream($"C:\\Otus\\TestDir1\\File{i}.txt", FileMode.Append))
                using (StreamWriter fileWriter1 = new StreamWriter(file1, System.Text.Encoding.UTF8))
                    fileWriter1.WriteLine($"File{i}");

                using (FileStream file2 = new FileStream($"C:\\Otus\\TestDir2\\File{i}.txt", FileMode.Append))
                using (StreamWriter fileWriter2 = new StreamWriter(file2, System.Text.Encoding.UTF8))
                    fileWriter2.WriteLine($"File{i}");
            }
            for (int i = 1; i < 3; i++)
            {
                string rootFolder = $"C:\\Otus\\TestDir{i}";
                foreach (var file in Directory.EnumerateFiles(rootFolder, "*", SearchOption.AllDirectories))
                {
                    File.AppendAllText(file, $"Время обновления {DateTime.Now}");
                }
            }
            for (int i = 1; i < 11; i++)
            {
                var patch1 = $"C:\\Otus\\TestDir1\\File{i}.txt";
                var patch2 = $"C:\\Otus\\TestDir2\\File{i}.txt";
                using (StreamReader reader = File.OpenText(patch1))
                {
                    FileInfo infoPatch = new FileInfo(patch1);
                    string text = reader.ReadToEnd();
                    Console.WriteLine($"Имя файла {infoPatch.Name} \n Текст в файле \n {text}");
                }
                using (StreamReader reader = File.OpenText(patch2))
                {
                    FileInfo infoPatch = new FileInfo(patch2);
                    string text = reader.ReadToEnd();
                    Console.WriteLine($"Имя файла {infoPatch.Name} \n Текст в файле \n {text}");
                }
            }
        }
    }
}
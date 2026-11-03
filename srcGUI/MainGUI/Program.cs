using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string pythonExecutable = "py";
        
        // Получаем абсолютный путь, чтобы Python точно не заблудился в папках
        string scriptPath = Path.GetFullPath(Path.Combine("..", "..", "srcAgent", "testMain.py"));
        string testMessage = "Привет от C#-интерфейса!";

        ProcessStartInfo startInfo = new ProcessStartInfo()
        {
            FileName = pythonExecutable,
            Arguments = $"\"{scriptPath}\" \"{testMessage}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true, // Перехватываем ошибки тоже!
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = Process.Start(startInfo))
        {
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine("Код выхода (ExitCode): " + process.ExitCode);
            Console.WriteLine("Вывод (Output): " + output);
            Console.WriteLine("Ошибка (Error): " + error);
        }
    }
}
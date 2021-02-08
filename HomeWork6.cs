using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Taskmngr
{
	class Program
	{
		static void Main(string[] args)
		{
			Process process = new Process();
			string str;
			int tskmng_cmd = 5;

			process.StartInfo.FileName = @"Wmic.exe";
			process.StartInfo.Arguments = "process list brief /format:table";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			string output = process.StandardOutput.ReadToEnd();
			Console.WriteLine(output);
			process.WaitForExit();
			

			Console.WriteLine("Task Manager");
			Console.WriteLine("выбирете способ закрытия процесса:");
			Console.WriteLine("1 - по название процесса");
			Console.WriteLine("2 - по ID процесса");
			Console.WriteLine("0 - выход");


			if (process.ExitCode == 0)
			{
				while(tskmng_cmd != 0)
                {
					Console.WriteLine("Выбирети способ завершения процесса");
					tskmng_cmd = Convert.ToInt32(Console.ReadLine());
					switch (tskmng_cmd)
					{
						case 0:

							break;

						case 1:
							Console.WriteLine("Введите  название процесса:");
							str = Console.ReadLine();
							Process.Start("wmic.exe", "process  where \"Name=\'" + str + "\'\" call terminate");
							process.WaitForExit();
							break;

						case 2:
							Console.WriteLine("Введите ID процесса :");
							str = Console.ReadLine();
							Process.Start("wmic.exe", "process  where \"ProcessID=\'" + str + "\'\" call terminate");
							process.WaitForExit();
							break;
					}
				}
				
			}
			else Console.WriteLine("Произошла ошибка выполнения программы. Завершение работы программы");
		}
	}
}
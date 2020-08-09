using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace MonitoriaPastasContinua
{
    class Program
    {
        private static string[] diretorios = Directory.GetDirectories(@"\\server\caminho");

        static void Main(string[] args)
        {

            while (true)
            {

                try
                {

                    Console.WriteLine("\n\n===============================================================================================");
                    Console.WriteLine($"=================== INICIANDO VALIDACAO LOGS - {DateTime.Now} ============================");
                    Console.WriteLine("===============================================================================================\n\n");

                    foreach (string dir in diretorios)
                    {

                        if (File.Exists($@"{dir}\{DateTime.Now.ToString("yyyyMMdd")}.log"))
                        {

                            FileInfo infoArquivo = new FileInfo($@"{dir}\{DateTime.Now.ToString("yyyyMMdd")}.log");
                            Console.WriteLine("\nDiretorio: " + infoArquivo + " ----- Modificação: " + infoArquivo.LastWriteTime);

                        }

                    }

                    Console.WriteLine("\n\n================================================================================================");
                    Console.WriteLine($"==================== ENCERRANDO VALIDACAO LOGS - {DateTime.Now} ===========================");
                    Console.WriteLine("================================================================================================\n\n");

                }
                catch (Exception e)
                {

                    Console.WriteLine(DateTime.Now + " - Error: " + e);
                    Console.ReadKey();

                }

                Thread.Sleep(900000); //Pausa a execução por 15min

            }

        }
    }
}

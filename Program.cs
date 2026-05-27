using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CsPerformanceMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            
            Console.WriteLine("==================================================");
            Console.WriteLine("   C# System Performance Monitor - Real-Time Dashboard");
            Console.WriteLine("==================================================");
            Console.WriteLine("Presiona [Ctrl+C] para salir de la simulación.\n");

            // Para sistemas Windows, se pueden usar Performance Counters reales
            // Para multiplataforma (Linux/macOS/Windows) usamos APIs de System
            while (true)
            {
                Console.SetCursorPosition(0, 4);
                
                // 1. RAM Usage
                GC.Collect();
                long totalMemoryBytes = GC.GetTotalMemory(false);
                double usedMemoryMB = totalMemoryBytes / 1024.0 / 1024.0;

                // 2. Almacenamiento local (Disco Principal)
                DriveInfo drive = new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory) ?? "C:\\");
                double freeSpaceGB = drive.AvailableFreeSpace / 1024.0 / 1024.0 / 1024.0;
                double totalSpaceGB = drive.TotalSize / 1024.0 / 1024.0 / 1024.0;
                double usedSpacePercent = ((drive.TotalSize - drive.AvailableFreeSpace) / (double)drive.TotalSize) * 100.0;

                // 3. Entorno de Ejecución
                string osDesc = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
                string processArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();
                int coreCount = Environment.ProcessorCount;

                // Renderizado en Pantalla
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("💻 ESPECIFICACIONES DE COMPUTADORA");
                Console.ResetColor();
                Console.WriteLine($"• Sistema Operativo : {osDesc}");
                Console.WriteLine($"• Arquitectura      : {processArchitecture}");
                Console.WriteLine($"• Núcleos de CPU    : {coreCount} lógicos");

                Console.WriteLine("\n--------------------------------------------------");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("📊 ESTADÍSTICAS EN TIEMPO REAL");
                Console.ResetColor();
                Console.WriteLine($"• RAM Usada (Proceso) : {usedMemoryMB:F2} MB");
                Console.WriteLine($"• SSD Principal Libre  : {freeSpaceGB:F2} GB / {totalSpaceGB:F2} GB");
                
                // Barra de Carga de Almacenamiento
                Console.Write("• Uso de Almacenamiento: ");
                RenderProgressBar(usedSpacePercent);
                Console.WriteLine($" {usedSpacePercent:F1}%");

                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine($"Actualizado en: {DateTime.Now:HH:mm:ss}");

                Thread.Sleep(2000);
            }
        }

        static void RenderProgressBar(double percent)
        {
            int width = 20;
            int filled = (int)(percent / 100 * width);
            
            Console.Write("[");
            Console.ForegroundColor = percent > 85 ? ConsoleColor.Red : (percent > 60 ? ConsoleColor.Yellow : ConsoleColor.Green);
            Console.Write(new string('█', filled));
            Console.ResetColor();
            Console.Write(new string('░', width - filled));
            Console.Write("]");
        }
    }
}

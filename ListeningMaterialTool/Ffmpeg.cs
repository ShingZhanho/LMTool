using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ListeningMaterialTool {
    public class Ffmpeg {
        /// <summary>
        ///     Initialize the Ffmpeg instance
        /// </summary>
        /// <param name="exePath">The executable path of ffmpeg.exe</param>
        public Ffmpeg(string exePath) {
            ExePath = exePath;
        }

        // Properties
        private string ExePath { get; set; }

        // Methods
        
        // Rebuilt method:

        public async Task<bool> StartFfmpeg(string args, int timeout = 0) {
            var task = InternalFfmpeg(args, timeout);
            var isSuccess = await task;
            return isSuccess;
        }

        private async Task<bool> InternalFfmpeg(string args, int timeout) {
            var proc = new Process {
                StartInfo = {
                    FileName = ExePath,
                    Arguments = args,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            
            // Wait for time
            if (timeout > 0) {
                Thread.Sleep(timeout);
                return File.Exists(args.Split(' ')[args.Split(' ').Length - 1]
                    .Replace("\"", ""));
            }
            
            // Wait indefinitely
            while (!File.Exists(args.Split(' ')[args.Split(' ').Length - 1]
                .Replace("\"", ""))) { }
            return true;
        }
    }
}
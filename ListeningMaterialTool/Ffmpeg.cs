using System;
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

        /// <summary>
        ///     Start ffmpeg.
        /// </summary>
        /// <param name="args">Arguments to be passed into ffmpeg.</param>
        /// <param name="timeout">
        ///     Time to wait.
        ///     timeout > 0 : Wait for [timeout] seconds until considering failed.
        ///     timeout = 0 : Wait indefinitely. Will not be considered failed.
        /// </param>
        public async Task<bool> StartFfmpeg(string args, int timeout = 0) {
            if (timeout < 0)
                throw new ArgumentException(
                    "Parameter \"timeout\" must greater than or equal to 0.", nameof(timeout));

            // Run ffmpeg in a new thread
            var ffmpegThread = new Thread(
                () => {
                    var proc = new Process() {
                        StartInfo = {
                            FileName = ExePath,
                            Arguments = args,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };
                    proc.Start();
                    proc.WaitForExit();
                });
            ffmpegThread.Start();

            return await waitForResult(timeout,
                args.Split(' ')[args.Split(' ').Length - 1],
                ffmpegThread);
        }

        // Async method for getting results
        private Task<bool> waitForResult(int waitSeconds, string filename, Thread ffmpegThread) {
            var t = Task.Run(() => {
                if (waitSeconds == 0) {
                    // timeout = 0: Keep waiting until file exported
                    while (!File.Exists(filename.Replace("\"",""))) { }
                    return true;
                }
                
                // timeout > 1: Wait for specified time
                Task.Delay(waitSeconds).Wait();
                if (File.Exists(filename)) {
                    // Success
                    return true;
                } else {
                    // Fail
                    try {
                        ffmpegThread.Abort();
                    } catch { }
                    return false;
                }
            });
            return t;
        }
    }
}
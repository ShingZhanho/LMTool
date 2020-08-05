using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ListeningMaterialTool {
    /// <summary>
    ///     AudioTaskItem will be used to replace ListViewItem.
    /// </summary>
    public class AudioTaskItem {
        #region Initializers

        /// <summary>
        ///     Initializes the AudioTaskItem instance, use this if NOT adding a built-in audio.
        /// </summary>
        /// <param name="filePath">The full path of the audio file.</param>
        /// <param name="msIn">The position where the audio should be started trimming (in ms).</param>
        /// <param name="msOut">The position where the audio should be ended trimming (in ms).</param>
        public AudioTaskItem(string filePath, long msIn, long msOut) {
            Name = Path.GetFileName(filePath);
            FilePath = filePath;
            MsIn = msIn;
            MsOut = msOut;
            Duration = msOut - msIn;
        }

        /// <summary>
        ///     Initializer for adding silence audio.
        /// </summary>
        /// <param name="length">Length of the silence audio (in ms).</param>
        public AudioTaskItem(long length) {
            Name = "無聲片段";
            FilePath = "$SILENCE_AUDIO$";
            MsIn = 0;
            MsOut = length;
            Duration = length;
        }

        /// <summary>
        ///     Initializer for adding Greensleeves audio.
        /// </summary>
        /// <param name="length">Length of Greensleeves audio (in seconds).</param>
        public AudioTaskItem(int length) {
            Name = "綠袖子音樂";
            FilePath = $"$GREENSLEEVES_{length.ToString()}S$";
            MsIn = 0;
            MsOut = length * 1000;
            Duration = length * 1000;
        }

        /// <summary>
        ///     Initializer for Beep sound. No parameter needed.
        /// </summary>
        public AudioTaskItem() {
            Name = "Beep聲效";
            FilePath = "$BEEP_SOUND$";
            MsIn = 0;
            MsOut = 839; // The beep sound lasts for 839 milliseconds
            Duration = 839;
        }

        #endregion

        // Properties
        public int Number { get; private set; }
        public string Name { get; }
        public string FilePath { get; set; }
        public string FilePathInTemp { get; private set; }
        public long MsIn { get; }
        public long MsOut { get; }
        public long Duration { get; }

        // Methods

        /// <summary>
        ///     Converts the current AudioTaskItem object to a ListViewItem.
        /// </summary>
        /// <returns>Returns a ListViewItem.</returns>
        public ListViewItem ToListViewItem() {
            return new ListViewItem {
                Text = Number.ToString(),
                SubItems = {
                    Name, MsToTimeSpan(MsIn), MsToTimeSpan(MsOut), MsToTimeSpan(Duration), FilePath
                }
            };
        }

        #region Methods for converting between milliseconds and string

        /// <summary>
        ///     Converts milliseconds to a string with format hh:mm:ss.fff
        /// </summary>
        /// <param name="ms">Milliseconds</param>
        /// <returns>String with format hh:mm:ss.fff</returns>
        public string MsToTimeSpan(long ms) {
            var ts = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(ms));
            return $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}.{ts.Milliseconds:D3}";
        }

        /// <summary>
        ///     Converts string with format hh:mm:ss.fff to milliseconds
        /// </summary>
        /// <param name="time">Time string</param>
        /// <returns>Milliseconds</returns>
        public long TimeSpanToMs(string time) {
            var ts = new TimeSpan(
                0, int.Parse(time.Split(':')[0]),
                int.Parse(time.Split(':')[1]),
                int.Parse(time.Split(':')[2].Split('.')[0]),
                int.Parse(time.Split('.')[1]));
            return (long) ts.TotalMilliseconds;
        }

        #endregion

        /// <summary>
        ///     The AudioTaskItemsCollection should call this method to assign number when appending to the list.
        /// </summary>
        /// <param name="number">Number to be assigned.</param>
        /// <param name="filePathInTemp">The path of the file in the temp folder.</param>
        public void AssignNumber(int number, string filePathInTemp) {
            Number = number;
            FilePathInTemp = filePathInTemp;
        }

        
        /// <summary>
        ///     Method for assigning a filename to the object. To be used only when not appending a general audio.
        /// </summary>
        /// <param name="filename">Full path of the file.</param>
        public void AssignFileName(string filename) {
            FilePath = filename;
        }

        /// <summary>
        ///     Checks if this AudioTaskItem is valid.
        /// </summary>
        /// <returns>true if valid, false instead.</returns>
        public bool ItemIsValid() {
            // Always return true for built-in sound
            var arraySpecialAudios = new[] {
                "$SILENCE_AUDIO$", "$BEEP_SOUND$", "$GREENSLEEVES_"
            };
            foreach (var specialAudio in arraySpecialAudios)
                if (FilePath.Contains(specialAudio))
                    return true;
            
            return File.Exists(FilePath);
        }
    }


    /// <summary>
    ///     AudioTaskItemsCollection is a container of AudioTaskItems.
    /// </summary>
    public class AudioTaskItemsCollection {
        // Initializers

        /// <summary>
        ///     Default initializer
        /// </summary>
        /// <param name="temp_dir">Path of the temp dir.</param>>
        public AudioTaskItemsCollection(string temp_dir) {
            NumberStack = 0;
            TempDir = temp_dir;
            Items = new List<AudioTaskItem>();
        }

        /// <summary>
        ///     Load all AudioTaskItems from a file
        /// </summary>
        /// <param name="filename">Path of the file which will be loaded.</param>
        /// <param name="temp_dir">Path of the temp dir.</param>
        public AudioTaskItemsCollection(string filename, string temp_dir) { }

        // Properties
        /// <summary>
        ///     Stores all AudioTaskItems. DO NOT add to this property directly, use AudioTaskItemsCollection.Append().
        /// </summary>
        public List<AudioTaskItem> Items { get; private set; }

        public long totalDuration { get; private set; }
        private string TempDir { get; set; }
        private int NumberStack { get; set; }

        // Constants
        // DO NOT modify the ffmpeg arguments on the master branch
        private const string FFMPEG_ARGS_SILENCE = 
            "-f lavfi -i anullsrc=r=44100:cl=mono -t {0} -q:a 9 -acodec libmp3lame \"{1}\"";
        private const string FFMPEG_ARGS_TRIM = "-i \"{0}\" -ss {1} -to {2} -acodec libmp3lame \"{3}\"";
        private const string FFMPEG_ARGS_JOIN = "-safe 0 -f concat -i \"{0}\" -acodec libmp3lame \"{1}\"";

        // Methods

        #region Methods for modifying List<AudioTaskItem>

        /// <summary>
        ///     Append a general AudioTaskItem to the list.
        /// </summary>
        /// <param name="filepath">Path of file.</param>
        /// <param name="msIn">In location in milliseconds.</param>
        /// <param name="msOut">Out location in milliseconds.</param>
        /// <returns>The modified list.</returns>
        public List<AudioTaskItem> Append(string filepath, long msIn, long msOut) {
            var item = new AudioTaskItem(filepath, msIn, msOut);
            NumberStack++;

            File.Copy(filepath,
                $"{TempDir}/{NumberStack}{Path.GetExtension(filepath)}");

            item.AssignNumber(NumberStack,
                $"{TempDir}/{NumberStack}{Path.GetExtension(filepath)}");
            Items.Add(item);
            totalDuration += item.Duration;

            return Items;
        }

        /// <summary>
        ///     Append Greensleeves audio to the list.
        /// </summary>
        /// <param name="length">Length of the Greensleeves audio in seconds.</param>
        /// <returns>The modified list.</returns>
        public List<AudioTaskItem> Append(int length) {
            var item = new AudioTaskItem(length);
            NumberStack++;

            File.Copy($"./built_in_sound/G_{length.ToString()}.mp3",
                $"{TempDir}/{NumberStack}.mp3");

            item.AssignNumber(NumberStack, $"{TempDir}\\{NumberStack}.mp3");
            Items.Add(item);
            totalDuration += item.Duration;

            return Items;
        }

        /// <summary>
        ///     Append silence audio to the list.
        /// </summary>
        /// <param name="length">Length of the silence audio in milliseconds.</param>
        /// <returns>The modified list.</returns>
        public List<AudioTaskItem> Append(long length) {
            var item = new AudioTaskItem(length);
            NumberStack++;

            // Generate silence audio with ffmpeg
            var ffmpeg = new Ffmpeg("./ffmpeg/ffmpeg.exe");
            // var taskBeep = ffmpeg.StartFfmpeg(FFMPEG_ARGS_SILENCE
            //     .Replace("$SECS$", (length * 1000).ToString()
            //         .Replace("$FILE_TEMP$", $"{TempDir}\\{NumberStack}.m4a")), 1000);
            var taskBeep = ffmpeg.StartFfmpeg(string.Format(FFMPEG_ARGS_SILENCE,
                length / 1000,
                $"{TempDir}\\{NumberStack}.mp3"), 1500);
            if (!taskBeep.Result)
                return null;

            item.AssignNumber(NumberStack, $"{TempDir}/{NumberStack}.mp3");
            Items.Add(item);
            totalDuration += item.Duration;

            return Items;
        }

        /// <summary>
        ///     Append a beep sound to the list.
        /// </summary>
        /// <returns>The modified list.</returns>
        public List<AudioTaskItem> Append() {
            var item = new AudioTaskItem();
            NumberStack++;

            File.Copy("./built_in_sound/Beep.mp3",
                $"{TempDir}/{NumberStack}.mp3");

            item.AssignNumber(NumberStack, $"{TempDir}/{NumberStack}.mp3");
            Items.Add(item);
            totalDuration += item.Duration;

            return Items;
        }

        /// <summary>
        ///     Removes the AudioTaskItem from the list. Have no effect if the item is not exist.
        /// </summary>
        /// <param name="itemToRemove">Pass the item to be removed in ListViewItem</param>
        /// <returns>The modified list.</returns>
        public List<AudioTaskItem> Remove(ListViewItem itemToRemove) {
            for (var i = 0; i < Items.Count; i++) {
                if (Items[i].Number.ToString() != itemToRemove.Text) continue;
                totalDuration -= Items[i].Duration;
                File.Delete(Items[i].FilePathInTemp);
                Items.RemoveAt(i);
                return Items;
            }

            return Items;
        }

        /// <summary>
        ///     Moves the passed in item up or down.
        /// </summary>
        /// <param name="itemToMoveUp">The item to be moved.</param>
        /// <param name="upDown">0 to move down, 1 to move up.</param>
        /// <returns>The modified list. No effect if upDown is neither 0 nor 1, or item not found.</returns>
        public List<AudioTaskItem> MoveItem(ListViewItem itemToMoveUp, int upDown) {
            if (upDown != 0 && upDown != 1) return null;
            int? index = null;
            AudioTaskItem newItem = null;
            foreach (var audioTaskItem in Items) {
                if (audioTaskItem.Number.ToString() != itemToMoveUp.Text) continue;
                newItem = audioTaskItem;
                index = Items.IndexOf(audioTaskItem);
                break;
            }

            if (index == null) return null;

            Items.RemoveAt(Convert.ToInt32(index));
            Items.Insert(upDown == 0
                ? Convert.ToInt32(index) + 1
                : Convert.ToInt32(index) - 1, newItem); // Move up if upDown = 1, otherwise move down.

            return Items;
        }

        #endregion

        /// <summary>
        ///     Converts the current AudioTaskItemCollection to ListViewItemCollection.
        /// </summary>
        /// <param name="listView">The owner ListView.</param>
        /// <returns>The converted ListViewItemCollection</returns>
        public ListView.ListViewItemCollection ToListViewItemCollection(ListView listView) {
            listView.Items.Clear();
            var listItems = new ListView.ListViewItemCollection(listView);
            foreach (var audioTaskItem in Items) {
                listItems.Add(audioTaskItem.ToListViewItem());
            }

            return listItems;
        }

        #region Methods for checking validation

        /// <summary>
        ///     Checks if all items in the list is valid.
        /// </summary>
        /// <returns>true if all valid, false instead.</returns>
        public bool ListIsValid() {
            foreach (var audioTaskItem in Items) {
                if (audioTaskItem.ItemIsValid()) continue;
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Gets the items which are invalid.
        /// </summary>
        /// <returns>A list of AudioTaskItems which are invalid.</returns>
        public List<AudioTaskItem> GetInvalidItems() {
            var list = new List<AudioTaskItem>();
            foreach (var audioTaskItem in Items) {
                if (!audioTaskItem.ItemIsValid()) list.Add(audioTaskItem);
            }

            return list;
        }

        #endregion

        // /// <summary>
        // ///     Exports the whole list to an independent file.
        // /// </summary>
        // /// <param name="destination">The destination path of the exported audio file.</param>
        // public async Task<bool> ExportToAudio(string destination) {
        //     // Creates a output dir
        //     var dirNum = 0;
        //     var outputDir = "";
        //     while (!Directory.Exists($"{TempDir}/output{dirNum}")) {
        //         dirNum++;
        //         outputDir = $"{TempDir}/output{dirNum}";
        //         Directory.CreateDirectory(outputDir);
        //     }
        //
        //     // Creates ffmpeg instance
        //     var ffmpeg = new Ffmpeg("./ffmpeg/ffmpeg.exe");
        //
        //     // Trim audio files
        //     foreach (var audioTaskItem in Items) {
        //         if (await ffmpeg.StartFfmpeg(FFMPEG_ARGS_TRIM
        //                 .Replace("$FILE_TEMP$", audioTaskItem.FilePathInTemp.Replace("\\","/"))
        //                 .Replace("$TIME_IN$", audioTaskItem.MsToTimeSpan(audioTaskItem.MsIn))
        //                 .Replace("$TIME_OUT$", audioTaskItem.MsToTimeSpan(audioTaskItem.MsOut))
        //                 .Replace("$FILE_OUTPUT$", $"{outputDir}/{Items.IndexOf(audioTaskItem) + 1}.mp3"),
        //             Properties.Settings.Default.ffmpeg_WaitTimeOut) == false) { // failure signal received
        //             //throw new Exception("Error occured while trimming audio. Export ended.");
        //             return false;
        //         }
        //     }
        //
        //     // Generates join_list.txt
        //     var lines = new List<string>();
        //     for (int i = 0; i < Directory.GetFiles(outputDir).Length; i++) {
        //         lines.Add($"file ./{i}.mp3");
        //     }
        //     File.WriteAllLines($"{outputDir}/join_list.txt", lines);
        //
        //     // Joins audio files
        //     if (await ffmpeg.StartFfmpeg(FFMPEG_ARGS_JOIN
        //         .Replace("$PATH_LIST$", $"{outputDir}/join_list.txt")
        //         .Replace("$PATH_OUTPUT$", $"{outputDir}/combine.mp3")) == false) { // failure signal received
        //         // throw new Exception("Error occured while joining audio. Export ended.");
        //         return false;
        //     }
        //
        //     // Copies to the destination
        //     File.Copy($"{outputDir}/combine.mp3", destination);
        //
        //     return true;
        // }

        public bool ExportFile(Output output, string destination) {
            output.AddLine("開始匯出");
            output.SetTotalSteps(Items.Count + 2);
            
            // Creates temp dir
            output.AddLine("正在建立暫存檔案...");
            var dirNum = 0;
            var outputDir = "";
            while (Directory.Exists($"{TempDir}/output{dirNum}")) dirNum++;
            outputDir = $"{TempDir}/output{dirNum}".Replace("\\","/");
            Directory.CreateDirectory(outputDir);
            output.AddLine($"暫存資料夾位置：{outputDir}");
            
            // Creates ffmpeg
            var ffmpeg = new Ffmpeg("./ffmpeg/ffmpeg.exe");
            
            // Trim
            output.AddLine("準備裁剪音訊");
            foreach (var taskItem in Items) {
                output.AddLine($"開始剪接第{taskItem.Number}段音訊，名稱：{taskItem.Name}");
                output.MoveOneStep();
                var taskTrim = ffmpeg.StartFfmpeg(string.Format(FFMPEG_ARGS_TRIM,
                    taskItem.FilePathInTemp,
                    taskItem.MsIn,
                    taskItem.MsOut,
                    $"{outputDir}/{Items.IndexOf(taskItem) + 1}.mp3"));
                // Check status
                if (taskTrim.Result) {
                    // Success
                    output.AddLine("成功");
                } else {
                    // Fail
                    output.AddLine("出現未知錯誤，已停止作業");
                    return false; // Terminates work
                }
            }
            
            // Generate join_list.txt
            output.AddLine("正在產生合併清單");
            var listLines = new List<string>();
            var index = 1;
            while (File.Exists($"{outputDir.Replace("/","\\")}\\{index}.mp3")) {
                listLines.Add($"file {outputDir.Replace("/","\\\\")}\\\\{index}.mp3");
                output.AddLine(listLines[index - 1]);
                index++;
            }
            File.WriteAllLines($"{outputDir}/join_list.txt", listLines);
            
            // Join audios
            output.AddLine("開始合併");
            output.MoveOneStep();
            var taskCombine = ffmpeg.StartFfmpeg(string.Format(FFMPEG_ARGS_JOIN,
                $"{outputDir.Replace("/","\\")}\\join_list.txt",
                $"{outputDir.Replace("/","\\")}\\Output.mp3"));
            // Check for failure
            if (taskCombine.Result) {
                // Success
                output.AddLine("成功合併");
            }
            else {
                output.AddLine("出現未知錯誤，已停止作業");
                return false;
            }
            
            // Copies the file
            File.Copy($"{outputDir}/Output.mp3", destination);
            output.AddLine("正在儲存檔案");
            output.MoveOneStep();

            return true;
        }

        /// <summary>
        ///     Save the list and configurations to a .lmtproj file.
        /// </summary>
        /// <param name="destination">The destination of the .lmtproj file</param>
        /// <returns>Returns the full file path if succeeded.</returns>
        public string SaveFile(string destination) {
            var lines = new List<string>();
            foreach (var audioTaskItem in Items) {
                lines.Add($"{audioTaskItem.Number};{audioTaskItem.FilePath};" +
                          $"{audioTaskItem.MsIn};{audioTaskItem.MsOut}");
            }

            try {
                File.WriteAllLines(destination, lines);
            } catch {
                // ignored
            }

            return File.Exists(destination) ? Path.GetFullPath(destination) : null;
        }
    }
}
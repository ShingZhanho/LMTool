using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ListeningMaterialTool {
    /// <summary>
    ///     AudioTaskItem will be used to replace ListViewItem.
    /// </summary>
    public class AudioTaskItem {
        // Initializers for AudioTaskItem

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

        // Properties
        public int Number { get; private set; }
        public string Name { get; }
        public string FilePath { get; }
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
        private string MsToTimeSpan(long ms) {
            var ts = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(ms));
            return $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}.{ts.Milliseconds:D3}";
        }

        /// <summary>
        ///     Converts string with format hh:mm:ss.fff to milliseconds
        /// </summary>
        /// <param name="time">Time string</param>
        /// <returns>Milliseconds</returns>
        private long TimeSpanToMs(string time) {
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
        private string TempDir { get; set; }
        private int NumberStack { get; set; }
        
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
                $"{TempDir}/{NumberStack}.{Path.GetExtension(filepath)}");
            
            item.AssignNumber(NumberStack, 
                $"{TempDir}/{NumberStack}.{Path.GetExtension(filepath)}");
            Items.Add(item);

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
            
            File.Copy($"./built_in_soung/G_{length.ToString()}.mp3",
                $"{TempDir}/{NumberStack}.mp3");
            
            item.AssignNumber(NumberStack, $"{TempDir}/{NumberStack}.mp3");
            Items.Add(item);

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
                Items.RemoveAt(i);
                return Items;
            }
            return Items;
        }

        #endregion
    }
}
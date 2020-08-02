namespace ListeningMaterialTool {
    
    /// <summary>
    /// AudioTaskItem will be used to replace ListViewItem.
    /// </summary>
    public class AudioTaskItem {
        
        // Initializers for AudioTaskItem
        
        /// <summary>
        /// Initializes the AudioTaskItem instance, use this if NOT adding a built-in audio.
        /// </summary>
        /// <param name="FilePath">The full path of the audio file.</param>
        /// <param name="MsIn">The position where the audio should be started trimming (in ms).</param>
        /// <param name="MsOut">The position where the audio should be ended trimming (in ms).</param>
        public AudioTaskItem(string FilePath, long MsIn, long MsOut) {
            
        }

        /// <summary>
        /// Initializer for adding silence audio.
        /// </summary>
        /// <param name="Length">Length of the silence audio (in ms).</param>
        public AudioTaskItem(long Length) {
            
        }

        /// <summary>
        /// Initializer for adding Greensleeves audio.
        /// </summary>
        /// <param name="Length">Length of Greensleeves audio (in seconds).</param>
        public AudioTaskItem(int Length) {
            
        }

        /// <summary>
        /// Initializer for Beep sound. No parameter needed.
        /// </summary>
        public AudioTaskItem() {
            
        }
        
        // Properties
        public int Number { get; private set; }
        public string Name { get; private set; }
        public string FilePath { get; private set; }
        public long MsIn { get; private set; }
        public long MsOut { get; private set; }
        public long Duration { get; private set; }

    }

    
    /// <summary>
    /// AudioTaskItemsCollection is a container of AudioTaskItems.
    /// </summary>
    public class AudioTaskItemsCollection {
        
    }
}
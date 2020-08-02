using System.Collections.Generic;

namespace ListeningMaterialTool {
    
    /// <summary>
    /// AudioTaskItem will be used to replace ListViewItem.
    /// </summary>
    public class AudioTaskItem {
        
        // Initializers for AudioTaskItem
        
        /// <summary>
        /// Initializes the AudioTaskItem instance, use this if NOT adding a built-in audio.
        /// </summary>
        /// <param name="filePath">The full path of the audio file.</param>
        /// <param name="msIn">The position where the audio should be started trimming (in ms).</param>
        /// <param name="msOut">The position where the audio should be ended trimming (in ms).</param>
        public AudioTaskItem(string filePath, long msIn, long msOut) {
            
        }

        /// <summary>
        /// Initializer for adding silence audio.
        /// </summary>
        /// <param name="length">Length of the silence audio (in ms).</param>
        public AudioTaskItem(long length) {
            
        }

        /// <summary>
        /// Initializer for adding Greensleeves audio.
        /// </summary>
        /// <param name="length">Length of Greensleeves audio (in seconds).</param>
        public AudioTaskItem(int length) {
            
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
        
        // Initializers

        /// <summary>
        /// Default initializer
        /// </summary>
        public AudioTaskItemsCollection() {
            
        }

        /// <summary>
        /// Load all AudioTaskItems from a file
        /// </summary>
        /// <param name="filename">Path of the file which will be loaded.</param>
        public AudioTaskItemsCollection(string filename) {
            
        }
        
        // Properties
        /// <summary>
        /// Stores all AudioTaskItems. DO NOT add to this property directly, use AudioTaskItemsCollection.Append().
        /// </summary>
        public List<AudioTaskItem> Items { get; private set; }
    }
}
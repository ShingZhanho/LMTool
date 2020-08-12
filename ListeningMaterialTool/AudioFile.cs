using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace ListeningMaterialTool {
    public class AudioFile {
        public AudioFile(string filename) {
            var tagFile = TagLib.File.Create(filename);
            Duration = (long)tagFile.Properties.Duration.TotalMilliseconds;
        }
        
        /// <summary>
        ///     Gets the duration of the audio file.
        /// </summary>
        public long Duration { get; }

    }
}

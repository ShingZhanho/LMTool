using System.Windows.Forms;

namespace ListeningMaterialTool {
    
    /// <summary>
    ///     Class for getting logs from ffmpeg tasks
    /// </summary>
    public class Output {
        public Output(RichTextBox richTextBox, ProgressBar progressBar) {
            _internalTextBox = richTextBox;
            _internalProgressBar = progressBar;
            _internalTextBox.Text = _outputLines;
        }
        
        // Properties & Variables
        public int _totalSteps;
        private readonly RichTextBox _internalTextBox;
        private readonly ProgressBar _internalProgressBar;

        private string _outputLines = "";

        // Methods
        
        public void SetTotalSteps(int steps) {
            // Sets the progress bar
            _totalSteps = steps;
            _internalProgressBar.Maximum = steps;
        }

        public void AddLine(string line) {
            // Sets the text box
            _outputLines += line + "\n";
            _internalTextBox.Text = _outputLines;
        }
        
        
    }
}
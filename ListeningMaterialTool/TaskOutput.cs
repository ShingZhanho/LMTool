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
        private int _totalSteps;
        private int _currentStep;
        private readonly RichTextBox _internalTextBox;
        private readonly ProgressBar _internalProgressBar;

        private string _outputLines = "";

        // Methods
        
        public void SetTotalSteps(int steps) {
            // Sets the progress bar
            _totalSteps = steps;
            _internalProgressBar.Maximum = _totalSteps;
        }

        public void AddLine(string line) {
            // Sets the text box
            _outputLines += line + "\n";
            _internalTextBox.Text = _outputLines;
            
            // Make log visible
            _internalTextBox.SelectionStart = _internalTextBox.Text.Length;
            _internalTextBox.ScrollToCaret();
        }

        public void MoveOneStep() {
            // Add one step
            if (_currentStep + 1 <= _totalSteps) _currentStep++;
            _internalProgressBar.Value = _currentStep;
        }

        public int GetTotalSteps() {
            return _totalSteps;
        }

        public int GetCurrentStep() {
            return _currentStep;
        }
    }
}
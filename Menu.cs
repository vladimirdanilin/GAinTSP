using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAinTSP
{
    public partial class Menu : Form
    {
        public string InputFile { get; private set; }
        public string OutputFile { get; private set; }
        public int NumOfSpecies { get; private set; }
        public double Result { get; private set; }
        public double PercentOfMutations { get; private set; }
        public int NumOfPopulations { get; private set; }
        public int MaxNumOfPopulations { get; private set; }

        public bool Checked { get; set; }

        public Menu()
        {
            InitializeComponent();
        }





        private void NumOfSpeciesBox_TextChanged(object sender, EventArgs e)
        {
            int numOfSpecies;
            if (int.TryParse(NumOfSpeciesBox.Text, out numOfSpecies))
            {
                NumOfSpecies = numOfSpecies;
            }
        }

        private void MutBox_TextChanged(object sender, EventArgs e)
        {
            double percentOfMutations;
            if (double.TryParse(MutBox.Text, out percentOfMutations))
            {
                PercentOfMutations = percentOfMutations;
            }
        }

        private void ResultBox_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(ResultBox.Text, out result))
            {
                Result = result;
            }
        }

        private void NumOfPopsBox_TextChanged(object sender, EventArgs e)
        {
            int numOfPopulations;
            if (int.TryParse(NumOfPopsBox.Text, out numOfPopulations))
            {
                NumOfPopulations = numOfPopulations;
            }
        }

        private void InputUrl_TextChanged(object sender, EventArgs e)
        {
            InputFile = InputUrl.Text;
        }

        private void OutputUrl_TextChanged(object sender, EventArgs e)
        {
            OutputFile = OutputUrl.Text;
        }



        private void ResultButton_CheckedChanged(object sender, EventArgs e)
        {
            Checked = true;
        }

        private void PopulationsButton_CheckedChanged(object sender, EventArgs e)
        {
            Checked = false;
        }

        private void MaxPops_TextChanged(object sender, EventArgs e)
        {
            int maxNumOfPopulations;
            if (int.TryParse(MaxPops.Text, out maxNumOfPopulations))
            {
                MaxNumOfPopulations = maxNumOfPopulations;
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            Start start = new Start(NumOfSpecies, Result, NumOfPopulations, Checked, MaxNumOfPopulations, PercentOfMutations);
            start.Run(InputFile, OutputFile);

            string InputPath = "C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\";
            MatrixBox.Text = File.ReadAllText(@"C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\text.txt");

            if (InputFile != null)
            {
                InputPath = InputPath + InputFile;
                MatrixBox.Text = File.ReadAllText(@InputPath);
            }

            string OutputPath = "C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\";
            ResultTextBox.Text = File.ReadAllText(@"C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\result.txt", System.Text.Encoding.Default);

            if (OutputFile != null)
            {
                OutputPath = OutputPath + OutputFile;
                ResultTextBox.Text = File.ReadAllText(OutputPath, System.Text.Encoding.Default);
            }

            
        }

        
    }
}
    


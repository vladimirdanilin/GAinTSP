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
        public int NumOfPopulations { get; private set; }
        public int MaxNumOfPopulations { get; private set; }

        public override bool AutoSize { get; set; }

        public bool Checked { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }

        public Menu()
        {
            InitializeComponent();
        }

        /*private void Menu_Load(object sender, EventArgs e)
        {

        }*/




        private void NumOfSpeciesBox_TextChanged(object sender, EventArgs e)
        {
            int numOfSpecies;
            if (int.TryParse(NumOfSpeciesBox.Text, out numOfSpecies))
            {
                NumOfSpecies = numOfSpecies;
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
            Start start = new Start(NumOfSpecies, Result, NumOfPopulations, Checked, MaxNumOfPopulations);
            start.Run(InputFile, OutputFile);
            //PrintMatrix();

            string InputPath = "C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\";
            MatrixBox.Text = File.ReadAllText(@"C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\text.txt");

            if (InputFile != null)
            {
                InputPath = InputPath + InputFile;
                MatrixBox.Text = File.ReadAllText(@InputPath);
            }

            string OutputPath = "C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\";
            ResultLabel.Text = File.ReadAllText(@"C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\result.txt", System.Text.Encoding.Default);

            if (OutputFile != null)
            {
                OutputPath = OutputPath + OutputFile;
                ResultLabel.Text = File.ReadAllText(OutputPath, System.Text.Encoding.Default);
            }

            ResultLabel.Visible = true;
            
        }

        private void PrintMatrix()
        {
            DataGridView dataGridView = new DataGridView();
            Chromosome chromosome = new Chromosome();
            double[,] Matrix = chromosome.GetAdjMatrix();


            /*    //указываем контроллу в который пишем количество строк и столбцов
                dataGridView.RowCount = Matrix.Length / 2;
                dataGridView.ColumnCount = Matrix.Length / 2;
                for (int i = 0; i < Matrix.Length / 2; i++)
                {
                    for (int j = 0; j < Matrix.Length / 2; j++)
                    {
                        //пишем значения из массива в ячейки контролла
                        dataGridView.Rows[i].Cells[j].Value = Matrix[i, j];
                    }
                }
            AdjMatrixLabel.Text = dataGridView.CurrentCell.Value.ToString();*/


            /*for (int i = 0; i < chromosome.NumOfCities; i++)
            {
                string str = "";
                Label label = new Label();
                label.Visible = true;
                label.AutoSize = true;
                label.Location;
                for (int j = 0; j < chromosome.NumOfCities; j++)
                {
                    str = str + Matrix[i, j].ToString();
                }

                label.Text = str;
            }*/

            /*//string str = "";
            //Label label = new Label();
            AdjMatrixLabel.Visible = true;
            AdjMatrixLabel.AutoSize = true;

            for (int i = 0; i < chromosome.NumOfCities; i++)
            {
                
                for (int j = 0; j < chromosome.NumOfCities; j++)
                {
                    AdjMatrixLabel.Text = Matrix[i, j].ToString();
                    AdjMatrixLabel.Text = Environment.NewLine;
                }

            }*/


        }

    }
}
    


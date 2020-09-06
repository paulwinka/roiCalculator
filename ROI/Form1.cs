using System;
using System.Windows.Forms;

namespace ROI
{
    public partial class Form1 : Form
    {
        private string a;
        private string f;
        private int currentRecord;
        private string[] stuff = new string[] { };

        public DataClasses2DataContext db = new DataClasses2DataContext();

        public Form1()
        {
            InitializeComponent();
        }

        public void df(string d) { f = d.ToString(); }

        private void btnStart_Click(object sender, EventArgs e)
        {
            a = Convert.ToString(currentRecord);

            //passing
            Form2 formTwo = new Form2();

            // now go on to 1 of 3 input screeens to update the record.
            this.Hide();
            formTwo.FormClosed += (s, args) => this.Close();
            formTwo.Show();
        }
    }
}

//https://d-fens.ch/2017/01/19/howto-create-localdb-file-mdf-manually-in-visual-studio-2015/
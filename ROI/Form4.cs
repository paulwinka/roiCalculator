using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROI
{
    public partial class Form4 : Form

    {
        private string d;
        public DataClasses2DataContext db = new DataClasses2DataContext();

        public Form4()
        {
            InitializeComponent();
        }

        private void btnUpdateNext_Click(object sender, EventArgs e)
        {
            //int currentRecord = Convert.ToInt32(txtTest.Text);
            //var data = db.CASAs.Where(c => c.Id == currentRecord).Select(c => c);
            //List<CASA> houses = data.ToList();
            ////string address = txtAddress.Text;
            ////houses[0].addrss = address;
            //db.SubmitChanges();
            //var display = db.CASAs.Select(p => new { p.Id, p.addrss });
            //foreach (var item in display)
            //{
            //    txtResult.Text += $"{item.Id} {item.addrss}\r\n";
            //}
            ////passing
            //Form1 formOne = new Form1();
            //formOne.df(d.ToString());

            //// now go on to home since 3 of 3 input screeens now updated.
            //this.Hide();
            //formOne.FormClosed += (s, args) => this.Close();
            //formOne.Show();
        }

        public void cd(string c) { d = c.ToString(); }

        //private void OnLoad(object sender, EventArgs e)
        //{
        //    txtTest.Text = d.ToString();
        //}
    }
}
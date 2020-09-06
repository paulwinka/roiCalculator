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
    public partial class Form5 : Form
    {
        private int currentPropertyId;
        private int currentPropertyComboBoxIndex;

        public DataClasses2DataContext db = new DataClasses2DataContext();

        public Form5()
        {
            InitializeComponent();
            MessageBox.Show("Advanced calculations on each property that has an attached mortgage can be viewed here. Properties that do not have an attached mortage do not appeaer. Once a property is chosen from the drop down, more text boxes appear. The user shall fill out the data and then validate it, then the 'do calculations' button appears. From there, the user my see the final performance data for that property record.");
            PopulatePropertyComboBox();
        }

        private void PopulatePropertyComboBox()
        {
            cboAllProperties.Text = "";
            cboAllProperties.Items.Clear();
            // first find all property IDs that are in Mortgages, whether with a 0 or not. Also, get the relevant address from the casa class, but not really necessary.
            var leftOuterJoin = from m in db.Mortgages
                                join c in db.CASAs on m.PropertyID equals c.Id into gj
                                from subHouse in gj.DefaultIfEmpty()
                                select new { MortgageID = m.Id, LoanAmount = m.LoanAmount, RelevantProperty = subHouse.address ?? String.Empty, PropertyID = m.PropertyID };
            List<int> IdsInMortgagesList = new List<int>(); //this is a list of all the propertyIDs that appear in mortgage.
            foreach (var z in leftOuterJoin)
            {
                //textBox1.Text += String.Format("{0}{1}\r\n", z.RelevantProperty, z.PropertyID);
                IdsInMortgagesList.Add(z.PropertyID);
            }
            //get a list of all property IDs from Casa.
            var numberedPropertiesInCasa = from c in db.CASAs select new { IdInCasa = c.Id };
            List<int> IdsInCASAList = new List<int>();
            foreach (var z in numberedPropertiesInCasa) { IdsInCASAList.Add(z.IdInCasa); }

            //now compare the properties and put them to a list.
            List<int> outcomeList = IdsInCASAList.Intersect(IdsInMortgagesList).ToList();
            for (int i = 0; i < outcomeList.Count; i++) { cboAllProperties.Items.Add(outcomeList[i]); }
        }

        private void cboAllProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CASA q = new CASA();
            //q = (CASA)cboAllProperties.SelectedItem;
            grpOperatingInputs.Visible = true;
            grpResults.Visible = false;
            int q = Convert.ToInt32(cboAllProperties.SelectedItem);
            CASA houseLookup = new CASA();
            var display = db.CASAs.Where(c => c.Id == q).Select(c => c);
            List<CASA> houseLookupList = display.ToList();
            currentPropertyId = houseLookupList[0].Id;
            txtCurrentPropertyAnalyzed.Text = String.Format("{0}", currentPropertyId);
            txtAddress.Text = String.Format("{0}", houseLookupList[0].address);
            //var findQ = db.CASAs.Where(c => c.address == q).Select(c => c);
            //List<CASA> foundQList = findQ.ToList();
            //currentPropertyComboBoxIndex = cboAllProperties.SelectedIndex;
            //txtCurrentPropertyAnalyzed.Text = string.Format("{0}", q);
            cboAllProperties.Items.Clear();
            PopulatePropertyComboBox();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            grpResults.Visible = true;
            int i = currentPropertyId;
            int j = currentPropertyComboBoxIndex;

            decimal grossRent = Decimal.Parse(txtGrossRent.Text);
            decimal propertyTax = decimal.Parse(txtPropertyTax.Text);
            decimal insurance = decimal.Parse(txtInsurance.Text);
            decimal advertising = decimal.Parse(txtAdvertising.Text);
            decimal otherExpenses = decimal.Parse(txtOtherExpenses.Text);
            decimal hoaFees = decimal.Parse(txtHOA.Text);
            decimal managementFees = decimal.Parse(txtManagementFees.Text);
            decimal maintenanceFees = decimal.Parse(txtMaintenance.Text);
            decimal vacancy = decimal.Parse(txtVacancy.Text);
            var leftOuterJoin = from x in db.CASAs
                                join y in db.Mortgages on x.Id equals y.PropertyID into loj
                                from mtg
                                in loj.DefaultIfEmpty()
                                where x.Id == currentPropertyId
                                select new
                                {
                                    PropertyID = x.Id,
                                    MortgageID = mtg.Id,
                                    mtg.LtvRatio,
                                    Area = x.area,
                                    mtg.PurchasePrice,
                                    mtg.DownPayment,
                                    mtg.LoanOriginationFees,
                                    mtg.DepreciableClosingCosts,
                                    mtg.OtherClosingCosts,
                                    mtg.MonthlyPayment,
                                    //Months = x.Months,
                                    //Rate = x.InterestRate,
                                    //OriginationFees = x.LoanOriginationFees,
                                    //Depreciable = x.DepreciableClosingCosts,
                                    //Other = x.OtherClosingCosts,
                                    //Area = subHouse.area,

                                    //LoanAmount = x.LoanAmount,
                                    //DownPayment = x.DownPayment,
                                    //MonthlyPayment = x.MonthlyPayment,

                                    //RelevantPropertyId = x.PropertyID,
                                    //RelevantPropertyAddress = subHouse.address ?? String.Empty
                                };
            var xy = (leftOuterJoin).ToList();
            txtCostSqFt.Text = String.Format("{0:C}", xy[0].PurchasePrice / xy[0].Area);
            decimal? initialCashinvested = xy[0].DownPayment + xy[0].LoanOriginationFees + xy[0].DepreciableClosingCosts + xy[0].OtherClosingCosts;
            txtInitialCashInvested.Text = String.Format("{0:C}", initialCashinvested);
            txtMonthRentSqFt.Text = String.Format("{0:C}", grossRent / xy[0].Area);
            decimal operatingIncome = grossRent * (1 - vacancy);
            txtOperatingIncome.Text = String.Format("{0:C}", operatingIncome);
            decimal operatingExpenses = propertyTax + insurance + advertising + otherExpenses + otherExpenses + hoaFees + managementFees + maintenanceFees;
            txtOperatingExpenses.Text = String.Format("{0:C}", operatingExpenses);
            decimal netOperatingIncome = operatingIncome - operatingExpenses;
            txtNoi.Text = String.Format("{0:C}", netOperatingIncome);
            txtDebtCoverage.Text = String.Format("{0}", netOperatingIncome / xy[0].MonthlyPayment);
            txtGrossRentMult.Text = String.Format("{0}", xy[0].PurchasePrice / (grossRent * 12));
            txtCashOnCash.Text = String.Format("{0:P}", (12 * netOperatingIncome) / initialCashinvested);
            txtTotalROI.Text = String.Format("{0:P}", (12 * netOperatingIncome) / xy[0].PurchasePrice);
            PopulatePropertyComboBox();
            btnCalculate.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form3 formThree = new Form3();
            this.Hide();
            formThree.FormClosed += (s, args) => this.Close();
            formThree.Show();
            formThree.BringToFront();
            formThree.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Form2 formTwo = new Form2();
            this.Hide();
            formTwo.FormClosed += (s, args) => this.Close();
            formTwo.Show();
            formTwo.BringToFront();
            formTwo.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            foreach (Control control in grpOperatingInputs.Controls)
            {
                string controlType = control.GetType().ToString();
                if (controlType == "System.Windows.Forms.TextBox")
                {
                    TextBox txtBox = (TextBox)control;
                    if (string.IsNullOrEmpty(txtBox.Text))
                    {
                        MessageBox.Show(txtBox.Name + " Can not be empty");
                        isValid = false;
                    }
                }
            }
            if (isValid)
            {
                btnCalculate.Visible = true;
            }
        }
    }
}

//https://www.tutlane.com/tutorial/linq/linq-left-outer-join    
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ROI
{
    public partial class Form3 : Form
    {
        private string c;
        private int currentMortgageId;
        private int propertyIdToAttach;
        private CASA[] finalArrayForComboBox = new CASA[] { };
        private int selectedPropertyIndex;
        public DataClasses2DataContext db = new DataClasses2DataContext();

        public Form3()
        {
            InitializeComponent();
            MessageBox.Show("Start by using the dropdown menu to read current data for current mortgage records. Each property may have only one mortgage attached. A mortgage can be created but not attached to any property. If a mortgage is deleted, the record will update each property to remove the attached mortgage. If a new property is created, it will be given a unique id and the rest of the text boxes must be filled in. Before updating any record, the user must click on 'validate' and if there are not any null or empty errors for the text boxes, and then 'update' button will appear. A mortgage can be created without attaching a property. Properties eligible to attach are in the dropdown menu of 'properties available to attach mortgage'");
            DisplayAllMortgages();
            PopulateComboBoxMortgageRecords();
            PopulateComboBoxPropertyIDs();
        }

        private void btnCreateMortgage_Click(object sender, EventArgs e)//CREATE MORTGAGE
        {
            //Trying to get the IDs of the property based on the selected index; there can only be only. where index equal this, then return the id.

            Mortgage newMortgage = new Mortgage() { PropertyID = propertyIdToAttach }; //must use comboBox
            db.Mortgages.InsertOnSubmit(newMortgage);
            db.SubmitChanges();
            currentMortgageId = newMortgage.Id;
            txtCurrentMortgage.Text = Convert.ToString(currentMortgageId);

            //now update the properties datbase
            MessageBox.Show("New Mortgage Created, now complete the text boxes.");
            grpMortgagePurchase.Visible = true;
            DisplayCreateMortgageSingleRecord();
            PopulateComboBoxMortgageRecords();
            PopulateComboBoxPropertyIDs();
            DisplayAllMortgages();
        }

        private void cboMortgageRecord_SelectedIndexChanged(object sender, EventArgs e)//READ MORTGAGE
        {
            grpMortgagePurchase.Visible = true;
            int i = cboMortgageRecord.SelectedIndex;
            currentMortgageId = i;
            cboMortgageRecord.Items.Clear();
            var leftOuterJoin = from m in db.Mortgages
                                join c in db.CASAs on m.PropertyID equals c.Id into gj
                                from subHouse in gj.DefaultIfEmpty()
                                select new
                                {
                                    MortgageID = m.Id,
                                    LtvRatio = m.LtvRatio,
                                    PurchasePrice = m.PurchasePrice,
                                    Months = m.Months,
                                    Rate = m.InterestRate,
                                    OriginationFees = m.LoanOriginationFees,
                                    Depreciable = m.DepreciableClosingCosts,
                                    Other = m.OtherClosingCosts,

                                    LoanAmount = m.LoanAmount,
                                    DownPayment = m.DownPayment,
                                    MonthlyPayment = m.MonthlyPayment,

                                    RelevantPropertyId = m.PropertyID,
                                    RelevantPropertyAddress = subHouse.address ?? String.Empty
                                };
            var xy = (leftOuterJoin).ToList();
            txtCurrentMortgage.Text = string.Format("{0}", xy[i].MortgageID);
            txtCurrentPropertyID.Text = String.Format("{0:0}", xy[i].RelevantPropertyId);
            txtCurrentPropertyAddress.Text = string.Format("{0}", xy[i].RelevantPropertyAddress);
            txtLtvRatio.Text = string.Format("{0}", xy[i].LtvRatio);
            txtPurchasePrice.Text = String.Format("{0}", xy[i].PurchasePrice);
            txtPeriods.Text = String.Format("{0:0}", xy[i].Months);
            txtRate.Text = String.Format("{0}", xy[i].Rate);
            txtLoanOriginationFees.Text = String.Format("{0:0}", xy[i].OriginationFees);
            txtDepreciableClosingCosts.Text = String.Format("{0:0}", xy[i].Depreciable);
            txtOtherClosingCosts.Text = String.Format("{0:0}", xy[i].Other);
            //now the derived, might be null
            txtPresVal.Text = String.Format("{0}", xy[i].LoanAmount);
            txtDownPayment.Text = String.Format("{0}", xy[i].DownPayment);
            txtMonthlyPayment.Text = String.Format("{0}", xy[i].MonthlyPayment);

            //now update
            PopulateComboBoxPropertyIDs();
            PopulateComboBoxMortgageRecords();
            DisplayAllMortgages();
        }

        private void btnUpdate_Click(object sender, EventArgs e)//UPDATE MORTGAGE
        {
            //get text boxes in order, including calculations
            int currentRecord = Convert.ToInt32(txtCurrentMortgage.Text);
            int propertyId = Convert.ToInt32(txtCurrentPropertyID.Text);
            string propertyAddress = txtCurrentPropertyAddress.Text;
            double ltvRatio = Double.Parse(txtLtvRatio.Text);
            double purchasePrice = Double.Parse(txtPurchasePrice.Text);
            int months = Int32.Parse(txtPeriods.Text);
            double rate = Convert.ToDouble(txtRate.Text);
            double loanOriginationFees = Double.Parse(txtLoanOriginationFees.Text);
            double depreciableClosingCosts = Double.Parse(txtDepreciableClosingCosts.Text);
            double otherClosingCosts = Double.Parse(txtOtherClosingCosts.Text);
            CalculateDerivedMortgageData(ltvRatio, purchasePrice, rate, months);
            double loanAmount = Double.Parse(txtPresVal.Text);
            double monthlyPayment = Double.Parse(txtMonthlyPayment.Text);
            double downPayment = Double.Parse(txtDownPayment.Text);
            selectedPropertyIndex = cboMortgageRecord.SelectedIndex;
            var data = db.Mortgages.Where(c => c.Id == currentRecord).Select(c => c);
            List<Mortgage> saveMortgageList = data.ToList();
            //#2, updating one by one.
            saveMortgageList[0].PropertyID = Convert.ToInt32(propertyId);
            saveMortgageList[0].PurchasePrice = Convert.ToDecimal(purchasePrice);
            saveMortgageList[0].LtvRatio = Convert.ToDecimal(ltvRatio);
            saveMortgageList[0].Months = Convert.ToInt32(months);
            saveMortgageList[0].InterestRate = Convert.ToDecimal(rate);
            saveMortgageList[0].LoanOriginationFees = Convert.ToDecimal(loanOriginationFees);
            saveMortgageList[0].DepreciableClosingCosts = Convert.ToDecimal(depreciableClosingCosts);
            saveMortgageList[0].OtherClosingCosts = Convert.ToDecimal(otherClosingCosts);
            saveMortgageList[0].LoanAmount = Convert.ToDecimal(loanAmount);
            saveMortgageList[0].MonthlyPayment = Convert.ToDecimal(monthlyPayment);
            saveMortgageList[0].DownPayment = Convert.ToDecimal(downPayment);
            db.SubmitChanges();

            //now update
            PopulateComboBoxPropertyIDs();
            PopulateComboBoxMortgageRecords();
            DisplayAllMortgages();
            btnUpdate.Visible = false;
            btnDerived.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)//DELETE MORTGAGE
        {
            //get the current record's Id from text box.
            currentMortgageId = Convert.ToInt32(txtCurrentMortgage.Text);
            var itemToDelete = db.Mortgages.Where(c => c.Id == currentMortgageId).Select(c => c).Single();

            //now delete from the record
            Mortgage mortgage = (Mortgage)itemToDelete;
            db.Mortgages.DeleteOnSubmit(mortgage); db.SubmitChanges();

            //now update
            PopulateComboBoxPropertyIDs();
            PopulateComboBoxMortgageRecords();
            DisplayAllMortgages();
        }

        private void DisplayCreateMortgageSingleRecord()
        {
            var data = db.Mortgages.Where(m => m.Id == currentMortgageId).Select(m => m);
            List<Mortgage> mortgagesList = data.ToList();
            var getPropertyAddress = db.CASAs.Where(m => m.Id == mortgagesList[0].PropertyID).Select(n => n);
            List<CASA> getPropertyAddressList = getPropertyAddress.ToList();
            txtSingleMortgageRecord.Text = "";
            //txtSingleMortgageRecord.Text = String.Format("ID: {0}\tPropertyID: {1}\tProperty Address: {2}\r\n\r\nPLEASE FILL IN TH REST OF THE DATA TO THE LEFT AND UPDATE THE RECORD.", mortgagesList[0].Id, mortgagesList[0].PropertyID, getPropertyAddressList[0].address);
        }

        private void DisplayAllMortgages()
        {
            txtAllMortgageRecords.Text = "";
            var leftOuterJoin = from m in db.Mortgages
                                join c in db.CASAs on m.PropertyID equals c.Id into gj
                                from subHouse in gj.DefaultIfEmpty()
                                select new { MortgageID = m.Id, LoanAmount = m.LoanAmount, RelevantProperty = subHouse.address ?? String.Empty, PropertyID = m.PropertyID };

            foreach (var z in leftOuterJoin)
            {
                txtAllMortgageRecords.Text += String.Format(
                    "Mortgage ID: {0,-13} Loan Amount: {1,10:C0}\t Property: {2,11}\t\t PropertyID: {3}\r\n",
                    z.MortgageID, Convert.ToString(z.LoanAmount).PadLeft(20), z.RelevantProperty, z.PropertyID);
            }
        }

        private void CalculateDerivedMortgageData(double ltvRatio, double purchasePrice, double interestRate, int months)
        {
            txtPresVal.Text = Convert.ToString(Math.Round(ltvRatio * purchasePrice, 2, MidpointRounding.AwayFromZero));
            txtDownPayment.Text = Convert.ToString(Math.Round(purchasePrice * (1 - ltvRatio), 2, MidpointRounding.AwayFromZero));
            //txtMonthlyPayment.Text = Convert.ToString(((interestRate / 12) / (1 - (Math.Pow(((interestRate / 12) + 1), (months * -1)))) * (ltvRatio * purchasePrice)));
            txtMonthlyPayment.Text = Convert.ToString(Math.Round(((interestRate / 12) / (1 - (Math.Pow(((interestRate / 12) + 1), (months * -1)))) * (ltvRatio * purchasePrice)), 2, MidpointRounding.AwayFromZero));
        }

        private void PopulateComboBoxMortgageRecords()
        {
            cboMortgageRecord.Items.Clear();
            var leftOuterJoin = from m in db.Mortgages
                                join c in db.CASAs on m.PropertyID equals c.Id into gj
                                from subHouse in gj.DefaultIfEmpty()
                                select new { MortgageID = m.Id, LoanAmount = m.LoanAmount, RelevantProperty = subHouse.address ?? String.Empty };

            foreach (var v in leftOuterJoin)
            {
                cboMortgageRecord.Items.Add(String.Format("Mortgage ID: {0} \tLoan Amount: {1:C0} \tProperty: {2}", v.MortgageID, v.LoanAmount, v.RelevantProperty));
            }
        }

        private void PopulateComboBoxPropertyIDs()
        {
            txtAllMortgageRecords.Text = "";
            cboPropertyIDs.Items.Clear();
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
            List<int> outcomeList = IdsInCASAList.Except(IdsInMortgagesList).ToList();
            for (int i = 0; i < outcomeList.Count; i++) { cboPropertyIDs.Items.Add(outcomeList[i]); }
        }

        private void cboPropertyIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int q = Convert.ToInt32(cboPropertyIDs.SelectedItem); //this is the index in the property list, get it and then get its ID.
            CASA houseLookup = new CASA();
            var display = db.CASAs.Where(c => c.Id == q).Select(c => c);
            List<CASA> houseLookupList = display.ToList();
            txtCurrentPropertyID.Text = String.Format("{0}", houseLookupList[0].Id);
            txtCurrentPropertyAddress.Text = String.Format("{0}", houseLookupList[0].address);
        }

        private void btnDerived_Click(object sender, EventArgs e)
        {
            double ltvRatio = Double.Parse(txtLtvRatio.Text);
            double purchasePrice = Double.Parse(txtPurchasePrice.Text);
            int months = Int32.Parse(txtPeriods.Text);
            double rate = Double.Parse(txtRate.Text);
            CalculateDerivedMortgageData(ltvRatio, purchasePrice, rate, months);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Form5 formFive = new Form5();
            this.Hide();
            formFive.FormClosed += (s, args) => this.Close();
            formFive.Show();
            formFive.BringToFront();
            formFive.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 formTwo = new Form2();

            this.Hide();
            formTwo.FormClosed += (s, args) => this.Close();
            formTwo.Show();
            formTwo.BringToFront();
            formTwo.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSeeAll_Click(object sender, EventArgs e)
        {
            DisplayAllMortgages();
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void txtMonthlyPayment_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPresVal_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDownPayment_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnValidateMortgage_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            foreach (Control control in grpMortgagePurchase.Controls)
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
            if (isValid) { btnUpdate.Visible = true; btnDerived.Visible = true; }
        }
    }
}

// 1. To figure your mortgage payment,start by converting your annual interest rate to a monthly interest rate by dividing by 12.
// 2. Next, add 1 to the monthly rate.
// 3. Third, multiply the number of years in the term of the mortgage by 12 to calculate the number of monthly payments you’ll make.
// 4. Fourth, raise the result of 1 plus the monthly rate to the negative power of the number of monthly payments you’ll make.
// 5. Fifth, subtract that result from 1.
// 6. Sixth, divide the monthly rate by the result.
// 7. Last, multiple the result by the amount you borrowed.
//double presentValue = (ltvRatio * purchasePrice);
//double rateDiv12 = (interestRate / 12); // 1
//double rateDiv12ThenAdd1 = ((interestRate / 12) + 1); // 2
//double negativePower = months * -1;
//double multipliedByNegative360Power = Math.Pow(rateDiv12ThenAdd1, negativePower);
//double oneMinusMultipliedByNegative360Power = 1 - multipliedByNegative360Power; // 5

//https://stackoverflow.com/questions/11580208/why-convert-toint32null-returns-0-in-c-sharp
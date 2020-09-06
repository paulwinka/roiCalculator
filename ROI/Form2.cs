using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROI
{
    public partial class Form2 : Form
    {
        private string b;
        private int currentRecord;
        private int currentOwnerRecord;
        private int currentOwnerIndex;
        private int selectedOwnerForPropertyIndex;
        private int selectedPropertyIndex;
        public DataClasses2DataContext db = new DataClasses2DataContext();

        public Form2()
        {
            InitializeComponent();
            MessageBox.Show("Start by using the dropdown menus to read current data for either properties or owners. Each property may have only one owner. But an owner can have many properties. If an owner is deleted, the record will update each property to remove the attached owner. If a new property is created, it will be given a unique id and a address that defaults to 'default'. Before updating any record, the user must click on 'validate' and if there are not any null or empty errors for the text boxes, the 'update' button will appear. A property can be created without attaching an owner.");
            PopulatePropertyComboBox();
            PopulateOwnerComboBox();
            PopulateOwnerIDforProperty();
            cboBedrooms.Items.AddRange(GetCboBoxNumbers1()); cboBedrooms.SelectedIndex = -1;
            cboBathrooms.Items.AddRange(GetCboBoxNumbers2()); cboBathrooms.SelectedIndex = -1;
            cboBasement.Items.AddRange(GetYesorNo()); cboBasement.SelectedIndex = -1;
            cboGarage.Items.AddRange(GetCboBoxNumbers3()); cboGarage.SelectedIndex = -1;
            cboTaxBrackets.Items.AddRange(GetTaxBrackets()); cboTaxBrackets.SelectedIndex = -1;
        }

        public string[] GetCboBoxNumbers1() => new string[] { "1", "2", "3", "4", "5", "6" }; public string[] GetCboBoxNumbers2() => new string[] { "1", "1.5", "2", "2.5", "3", "3.5", "4", "4.5", "5", "5.5", "6" }; public string[] GetCboBoxNumbers3() => new string[] { "0", "1", "2", "3" };

        public string[] GetYesorNo() => new string[] { "No", "Yes" };

        public string[] GetTaxBrackets() => new string[] { "10", "12", "22", "24", "32", "35", "37" };

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.FormClosed += (s, args) => this.Close();
            form1.Show();
        }

        private void btnUpdateNext_Click(object sender, EventArgs e)
        {
            //passing
            //b = currentRecord;
            Form3 formThree = new Form3();
            //formThree.bc(b.ToString());

            // now go on to 2 of 3 input screeens to update the record.
            this.Hide();
            formThree.FormClosed += (s, args) => this.Close();
            formThree.Show();
            formThree.BringToFront();
            formThree.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //passing
            Form1 formOne = new Form1();
            //formOne.bc(b.ToString());
            // now go on to 2 of 3 input screeens to update the record.
            this.Hide();
            formOne.FormClosed += (s, args) => this.Close();
            formOne.Show();
        }

        //***PROPERTY CRUD***
        private void btnCreateProperty_Click(object sender, EventArgs e)//CREATE PROPERTY
        {
            CASA newHouse = new CASA()
            {
                address = "default"
            };
            db.CASAs.InsertOnSubmit(newHouse);
            db.SubmitChanges();
            currentRecord = newHouse.Id;
            txtCurrentPropertyId.Text = Convert.ToString(newHouse.Id);

            //combo boxes to blank.
            cboBedrooms.SelectedIndex = -1;
            cboBathrooms.SelectedIndex = -1;
            cboGarage.SelectedIndex = -1;
            cboBasement.SelectedIndex = -1;

            // list of the owner just created with just the ID
            var data = db.CASAs.Where(c => c.Id == currentRecord).Select(c => c);
            List<CASA> houses = data.ToList();
            txtCurrentPropertyId.Text = String.Format("{0}", houses[0].Id);
            MessageBox.Show("record created with unique ID, now complete the rest of the form and click save to update the record.");

            DisplayAllPropertyRecords();
            PopulatePropertyComboBox();
            MakePropertyTextBoxesVisible();
        }

        private void cboAvailableProperties_SelectedIndexChanged(object sender, EventArgs e)//READ PROPERTIES
        {
            MakePropertyTextBoxesVisible();
            int i = cboAvailableProperties.SelectedIndex;
            currentOwnerRecord = i;
            var data = db.CASAs.Select(c => c);
            List<CASA> houseList = data.ToList();
            PopulateOwnerIDforProperty();
            PopulatePropertyTextBoxesToFillIn(cboAvailableProperties.SelectedIndex, houseList);

            //display data for single record
            DisplayInstancePropertyRecord(houseList, cboAvailableProperties.SelectedIndex);

            //display data for all records
            DisplayAllPropertyRecords();
        }

        private void MakePropertyTextBoxesVisible()
        {
            txtAllPropertyRecords.Visible = true;
            lblAllProperties.Visible = true;
        }

        private void btnSaveProperty_Click(object sender, EventArgs e)//UPDATE PROPERTY
        {
            //get data to update
            bool isValid;
            currentRecord = Convert.ToInt32(txtCurrentPropertyId.Text);
            string address = txtAddress.Text;
            if (!decimal.TryParse(txtSqFt.Text, out decimal sqFt)) { MessageBox.Show("enter numerical value for square feet."); }
            sqFt = Convert.ToDecimal(txtSqFt.Text);
            decimal bathrooms = Convert.ToDecimal(cboBathrooms.SelectedItem);
            decimal bedrooms = Convert.ToDecimal(cboBedrooms.SelectedItem);
            decimal garageSpaces = Convert.ToDecimal(cboGarage.SelectedItem);
            string basement = Convert.ToString(cboBasement.SelectedItem);
            if (!decimal.TryParse(txtAppreciation.Text, out decimal appreciationRate)) { MessageBox.Show("enter numerical value for real estate appreciation %."); }
            //AND//
            selectedPropertyIndex = cboAvailableProperties.SelectedIndex;
            //1. first select the record
            var data = db.CASAs.Where(c => c.Id == currentRecord).Select(c => c);
            List<CASA> savePropertyList = data.ToList();
            //second, updating, one by one
            savePropertyList[0].address = address;
            savePropertyList[0].area = sqFt;
            savePropertyList[0].bedrooms = bedrooms;
            savePropertyList[0].bathrooms = bathrooms;
            savePropertyList[0].garage = garageSpaces;
            savePropertyList[0].basement = basement;
            savePropertyList[0].appreciationRate = appreciationRate / 100;
            //need to make ownerID nullable
            int? ownerID;
            int i = cboOwnerForProperty.SelectedIndex;
            currentOwnerRecord = i;
            var makeList = db.Owners.Select(c => c);
            List<Owner> ownerFieldsList = makeList.ToList();
            try
            {
                ownerID = ownerFieldsList[i].Id;
                savePropertyList[0].OwnerID = ownerID;
            }
            catch (Exception)
            {
                ownerID = null;
                savePropertyList[0].OwnerID = ownerID;
            }
            db.SubmitChanges();

            //int j = cboAvailableProperties.SelectedIndex;
            //currentOwnerRecord = j;
            var updatePropertyTextBoxes = db.CASAs.Select(c => c);
            List<CASA> houseList = updatePropertyTextBoxes.ToList();
            PopulateOwnerIDforProperty();
            try
            {
                PopulatePropertyTextBoxesToFillIn(selectedPropertyIndex, houseList);
            }
            catch (Exception)
            {
                //MessageBox.Show("Looks like it is updated");
            }
            DisplayInstancePropertyRecord(savePropertyList, 0);
            DisplayAllPropertyRecords();
            PopulatePropertyComboBox();
            btnSaveProperty.Visible = false;
        }

        private void btnDeleteProperty_Click(object sender, EventArgs e)//DELETE PROPERTY
        {
            //get the current record's Id, it's in the text box
            int instantCase = Convert.ToInt32(txtCurrentPropertyId.Text);
            var itemToDelete = db.CASAs.Where(c => c.Id == currentRecord).Select(c => c).Single();

            //now delete from the record.
            CASA casa = (CASA)itemToDelete;
            db.CASAs.DeleteOnSubmit(casa); db.SubmitChanges();

            //display all data; there is no single record to display because it is deleted.
            DisplayAllPropertyRecords();
            PopulatePropertyComboBox();
        }

        //***OWNER CRUD***
        private void btnCreateOwner_Click(object sender, EventArgs e)//CREATE OWNER
        {
            MakeOwnerTextBoxesVisible();
            //create the new owner
            Owner newOwner = new Owner() { };
            db.Owners.InsertOnSubmit(newOwner);
            db.SubmitChanges();
            currentOwnerRecord = newOwner.Id;
            txtIdOwnerRecord.Text = Convert.ToString(newOwner.Id);
            MessageBox.Show("New Owner Record Created, now complete the text boxes for owner.");

            // list of the owner just created with just the ID
            var data = db.Owners.Where(c => c.Id == currentOwnerRecord).Select(c => c);
            List<Owner> owners = data.ToList();
            txtOwnerName.Text = owners[0].ownerName;

            //update comboBox
            PopulateOwnerComboBox();
            DisplayAllOwnerRecords();
        }

        private void cboAvailableOwners_SelectedIndexChanged(object sender, EventArgs e) //READ OWNERS
        {
            MakeOwnerTextBoxesVisible();
            btnSaveOwner.Visible = false;
            //GET INDEX OF CHANGE AND STORE IN I;
            int i = cboAvailableOwners.SelectedIndex;
            //currentOwnerRecord = i; //<--DOES THIS REALLY NEED TO BE SET?
            //GET LIST OF THE QUALITIES OF THE OWNERS BASED ON THE INDEX CHANGE.
            var data = db.Owners.Select(c => c);
            List<Owner> ownerFieldsList = data.ToList();
            //NOW SET CURRENT
            currentRecord = ownerFieldsList[i].Id;
            txtIdOwnerRecord.Text = Convert.ToString(currentRecord);
            txtOwnerName.Text = ownerFieldsList[i].ownerName;
            txtBracket.Text = String.Format("{0:0}", ownerFieldsList[i].bracket);
            cboTaxBrackets.Text = String.Format("{0:0}", ownerFieldsList[i].bracket);

            DisplayAllOwnerRecords();

            //populate available owner records
            cboTaxBrackets.Text = "";
            cboTaxBrackets.Items.Clear();
            Owner[] cboBracketArrayForComboBox = db.Owners.Select(p => p).ToArray();
            //cboOwnerForProperty.SelectedItem = String.Format("{0:0}", cboBracketArrayForComboBox[i].Id);
            cboTaxBrackets.Text = String.Format("{0:0}", cboBracketArrayForComboBox[i].bracket);
            cboTaxBrackets.Items.AddRange(GetTaxBrackets()); cboTaxBrackets.SelectedIndex = -1;

            //cboOwnerForProperty.Text = String.Format("{0:0}", houseList[i].OwnerID);

            //cboOwnerForProperty.SelectedItem = String.Format("{0:0}", houseList[i].OwnerID);
            //for (int j = 0; j < cboBracketArrayForComboBox.Length; j++)
            //{
            //    cboTaxBrackets.Items.Add(String.Format("{0, cboBracketArrayForComboBox[j].Id);
            //}
        }

        private void MakeOwnerTextBoxesVisible()
        {
            txtAllOwnerRecords.Visible = true;
            lblAllOwners.Visible = true;
        }

        private void btnSaveOwner_Click(object sender, EventArgs e)//UPDATE OWNER
        {
            //get data to update
            int currentRecord = Convert.ToInt32(txtIdOwnerRecord.Text);
            string ownerName = txtOwnerName.Text;
            decimal bracket = Convert.ToDecimal(cboTaxBrackets.SelectedItem);

            //1. first select the record
            var data = db.Owners.Where(c => c.Id == currentRecord).Select(c => c);
            List<Owner> saveOwnerList = data.ToList();
            //second, updating, one by one
            saveOwnerList[0].ownerName = ownerName;
            saveOwnerList[0].bracket = bracket;
            db.SubmitChanges();
            cboAvailableOwners.Text = String.Format("ID: {0} Owner Name: {1}", saveOwnerList[0].Id, saveOwnerList[0].ownerName);

            //display data , first get the where select thign, then like normal
            //var display = db.CASAs.Where(c => c.Id == currentRecord).Select(c => c);
            //txtOwnerSingleResult.Text = "";
            //txtOwnerSingleResult.Text = String.Format("ID: {0}\r\nOwner Name: {1}\r\nTax Bracket: {2}\r\n", saveOwnerList[0].Id, saveOwnerList[0].ownerName, saveOwnerList[0].bracket);
            // put in combo box new owner.
            PopulateOwnerComboBox();
            DisplayAllOwnerRecords();
            PopulateOwnerComboBox();
            PopulateOwnerIDforProperty();
            DisplayAllPropertyRecords();
            cboTaxBrackets.Items.AddRange(GetTaxBrackets());
            btnSaveOwner.Visible = false;
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)//DELETE OWNER
        {
            int instantCase = Convert.ToInt32(txtIdOwnerRecord.Text);
            var ownerIdsItemToDelete = db.CASAs.Where(c => c.OwnerID == instantCase).Select(c => c); //this will just delete the owner record from owner database.
            List<CASA> deleteOwnerIdList = ownerIdsItemToDelete.ToList();

            for (int i = 0; i < deleteOwnerIdList.Count; i++)
            {
                deleteOwnerIdList[i].OwnerID = null;
            }
            db.SubmitChanges();
            //delete from owner list.
            var ownerItemToDelete = db.Owners.Where(c => c.Id == instantCase).Select(c => c).Single(); //this will just delete the owner record from owner database.
            Owner ownerToDelete = (Owner)ownerItemToDelete;
            db.Owners.DeleteOnSubmit(ownerToDelete); db.SubmitChanges();
            txtOwnerName.Text = "";
            txtBracket.Text = "";
            cboTaxBrackets.Text = "";
            //Must be deleted from property that has the owner that was just deleted.
            //display all data; there is no single record to display because it is deleted.

            //update display of single record;
            //var data = db.CASAs.Where(c => c.Id == currentRecord).Select(c => c);
            //int i = cboAvailableProperties.SelectedIndex;
            //currentOwnerRecord = i;
            //var data = db.CASAs.Select(c => c);
            //List<CASA> houseList = data.ToList();
            int j = cboAvailableProperties.SelectedIndex;
            currentOwnerRecord = j;
            var data = db.CASAs.Select(c => c);
            List<CASA> houseList = data.ToList();
            try
            {
                DisplayInstancePropertyRecord(houseList, j);
            }
            catch (Exception)
            {
            }
            DisplayAllPropertyRecords();
            DisplayAllOwnerRecords();
            PopulateOwnerComboBox();
            PopulateOwnerIDforProperty();
            try
            {
                PopulatePropertyTextBoxesToFillIn(cboAvailableProperties.SelectedIndex, houseList);
            }
            catch (Exception)
            {
            }
        }

        //DISPLAY METHODS
        private void DisplayAllPropertyRecords()
        {
            txtAllPropertyRecords.Text = "";
            var display = db.CASAs.Select(p => p);
            foreach (var z in display)
            {
                if (z.bathrooms % 1 == 0)
                    txtAllPropertyRecords.Text += $"ID:{z.Id}\tadd:{z.address}\tarea:{z.area:0} s.f.\tbeds:{z.bedrooms:0}\tbaths:{z.bathrooms:0}\t\tgarage spaces:{z.garage:0}\tbasement:{z.basement}\tapp rate:{z.appreciationRate}\tOwnerID:{z.OwnerID}\r\n";
                if (z.bathrooms % 1 != 0)
                    txtAllPropertyRecords.Text += $"ID:{z.Id}\tadd:{z.address}\tarea:{z.area:0} s.f.\tbeds:{z.bedrooms:0}\tbaths:{z.bathrooms:0.0}\t\tgarage spaces:{z.garage:0}\tbasement:{z.basement}\tapp rate:{z.appreciationRate}\tOwnerID:{z.OwnerID}\r\n";
            }
        }

        private void DisplayAllOwnerRecords()
        {
            txtAllOwnerRecords.Text = "";
            var display = db.Owners.Select(p => p);
            foreach (var z in display) { txtAllOwnerRecords.Text += $"ID: {z.Id}, Owner Name: {z.ownerName}, Tax Bracket: {z.bracket:0.0}\r\n"; }
        }

        private void DisplayInstancePropertyRecord(List<CASA> propertyFieldsList, int i)
        {
            //txtPropertySingleResult.Text = "";
            //txtPropertySingleResult.Text = String.Format("ID: {0}\r\nAddress: {1}\r\nSquare Feet: {2}\r\nBedrooms: {3:0}\r\nBathrooms: {4}\r\nGarage Spaces: {5}\r\nBasement: {6}\r\nReal Estate Apprecation: {7}\r\nOwnerID: {8}", propertyFieldsList[i].Id, propertyFieldsList[i].address, propertyFieldsList[i].area, propertyFieldsList[i].bedrooms, propertyFieldsList[i].bathrooms, propertyFieldsList[i].garage, propertyFieldsList[i].basement, propertyFieldsList[i].appreciationRate, propertyFieldsList[i].OwnerID);
        }

        //POPULATE METHODS
        private void PopulatePropertyTextBoxesToFillIn(int i, List<CASA> houseList)
        {
            //i = 0;
            currentRecord = houseList[i].Id;
            txtCurrentPropertyId.Text = Convert.ToString(currentRecord);
            txtAddress.Text = houseList[i].address;
            txtSqFt.Text = String.Format("{0:0}", houseList[i].area);
            cboBedrooms.Text = String.Format("{0:0}", houseList[i].bedrooms);
            if (houseList[i].bathrooms % 1 == 0)
                cboBathrooms.Text = String.Format("{0:0}", houseList[i].bathrooms);
            if (houseList[i].bathrooms % 1 != 0)
                cboBathrooms.Text = String.Format("{0:0.0}", houseList[i].bathrooms);
            cboGarage.Text = String.Format("{0:0}", houseList[i].garage);
            cboBasement.Text = String.Format("{0}", houseList[i].basement);
            txtAppreciation.Text = String.Format("{0:0.00}", houseList[i].appreciationRate);
            cboOwnerForProperty.SelectedItem = String.Format("{0:0}", houseList[i].OwnerID);
            cboAvailableProperties.SelectedItem = String.Format("{0:0}", houseList[i].OwnerID);
            cboOwnerForProperty.Text = String.Format("{0:0}", houseList[i].OwnerID);
        }

        private void PopulatePropertyComboBox()
        {
            //cboAvailableProperties.Text = "";
            cboAvailableProperties.Items.Clear();
            CASA[] cboPropertyArrayForComboBox = db.CASAs.Select(p => p).ToArray();
            for (int i = 0; i < cboPropertyArrayForComboBox.Length; i++)
            {
                cboAvailableProperties.Items.Add(String.Format("{0}, address {1}", cboPropertyArrayForComboBox[i].Id, cboPropertyArrayForComboBox[i].address));
            }
            //cboAvailableProperties.Text = "";
        }

        private void PopulateOwnerComboBox()
        {
            //populate available owner records

            cboAvailableOwners.Items.Clear();
            Owner[] cboOwnerArrayForComboBox = db.Owners.Select(p => p).ToArray();
            for (int i = 0; i < cboOwnerArrayForComboBox.Length; i++)
            {
                cboAvailableOwners.Items.Add(String.Format("ID: {0} Owner Name: {1}", cboOwnerArrayForComboBox[i].Id, cboOwnerArrayForComboBox[i].ownerName));
            }
            //cboAvailableOwners.Text = "";
        }

        private void PopulateOwnerIDforProperty()
        {
            //populate available owner records
            cboOwnerForProperty.Text = "";
            cboOwnerForProperty.Items.Clear();
            Owner[] cboOwnerArrayForComboBox = db.Owners.Select(p => p).ToArray();
            for (int i = 0; i < cboOwnerArrayForComboBox.Length; i++)
            {
                cboOwnerForProperty.Items.Add(String.Format("ID: {0} Owner Name: {1}", cboOwnerArrayForComboBox[i].Id, cboOwnerArrayForComboBox[i].ownerName));
            }
            //cboOwnerForProperty.Text = "";
        }

        private void btnValidatePropety_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            foreach (Control control in grpBasicProp.Controls)
            {
                string controlType = control.GetType().ToString();
                if (controlType == "System.Windows.Forms.TextBox")
                {
                    TextBox txtBox = (TextBox)control;
                    if (string.IsNullOrEmpty(txtBox.Text))
                    {
                        MessageBox.Show(txtBox.Name + " Can not be empty");
                        isValid = false;
                        break;
                    }
                }
            }
            if (isValid) { btnSaveProperty.Visible = true; }
        }

        private void btnValidateOwner_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            foreach (Control control in grpOwner.Controls)
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
                    if (isValid)
                    {
                        btnSaveOwner.Visible = true;
                    }
                }
            }
        }
    }
}

//https://stackoverflow.com/questions/792412/unable-to-cast-object-of-type-system-data-linq-dataquery1system-int32-to-ty
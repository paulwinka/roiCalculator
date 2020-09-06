namespace ROI
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtLoanOriginationFees = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtPeriods = new System.Windows.Forms.TextBox();
            this.txtMonthlyPayment = new System.Windows.Forms.TextBox();
            this.txtPresVal = new System.Windows.Forms.TextBox();
            this.txtLtvRatio = new System.Windows.Forms.TextBox();
            this.txtDownPayment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDepreciableClosingCosts = new System.Windows.Forms.TextBox();
            this.txtOtherClosingCosts = new System.Windows.Forms.TextBox();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtCurrentMortgage = new System.Windows.Forms.TextBox();
            this.txtSingleMortgageRecord = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreateMortgage = new System.Windows.Forms.Button();
            this.txtAllMortgageRecords = new System.Windows.Forms.TextBox();
            this.cboPropertyIDs = new System.Windows.Forms.ComboBox();
            this.txtCurrentPropertyAddress = new System.Windows.Forms.TextBox();
            this.txtSeeAll = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboMortgageRecord = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCurrentPropertyID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnDerived = new System.Windows.Forms.Button();
            this.grpMortgagePurchase = new System.Windows.Forms.GroupBox();
            this.btnValidateMortgage = new System.Windows.Forms.Button();
            this.grpMortgagePurchase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(15, 474);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(147, 23);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.Text = "&delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(164, 556);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(147, 23);
            this.btnNext.TabIndex = 37;
            this.btnNext.Text = "&next -->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtLoanOriginationFees
            // 
            this.txtLoanOriginationFees.Location = new System.Drawing.Point(218, 226);
            this.txtLoanOriginationFees.Name = "txtLoanOriginationFees";
            this.txtLoanOriginationFees.Size = new System.Drawing.Size(100, 20);
            this.txtLoanOriginationFees.TabIndex = 5;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(218, 197);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 20);
            this.txtRate.TabIndex = 4;
            this.txtRate.Text = "3.625";
            // 
            // txtPeriods
            // 
            this.txtPeriods.Location = new System.Drawing.Point(218, 168);
            this.txtPeriods.Name = "txtPeriods";
            this.txtPeriods.Size = new System.Drawing.Size(100, 20);
            this.txtPeriods.TabIndex = 3;
            this.txtPeriods.Text = "360";
            // 
            // txtMonthlyPayment
            // 
            this.txtMonthlyPayment.Location = new System.Drawing.Point(923, 87);
            this.txtMonthlyPayment.Name = "txtMonthlyPayment";
            this.txtMonthlyPayment.ReadOnly = true;
            this.txtMonthlyPayment.Size = new System.Drawing.Size(100, 20);
            this.txtMonthlyPayment.TabIndex = 10;
            this.txtMonthlyPayment.TextChanged += new System.EventHandler(this.txtMonthlyPayment_TextChanged);
            // 
            // txtPresVal
            // 
            this.txtPresVal.Location = new System.Drawing.Point(923, 59);
            this.txtPresVal.Name = "txtPresVal";
            this.txtPresVal.ReadOnly = true;
            this.txtPresVal.Size = new System.Drawing.Size(100, 20);
            this.txtPresVal.TabIndex = 2;
            this.txtPresVal.TabStop = false;
            this.txtPresVal.TextChanged += new System.EventHandler(this.txtPresVal_TextChanged);
            // 
            // txtLtvRatio
            // 
            this.txtLtvRatio.Location = new System.Drawing.Point(218, 110);
            this.txtLtvRatio.Name = "txtLtvRatio";
            this.txtLtvRatio.Size = new System.Drawing.Size(100, 20);
            this.txtLtvRatio.TabIndex = 0;
            this.txtLtvRatio.Text = ".8";
            // 
            // txtDownPayment
            // 
            this.txtDownPayment.Location = new System.Drawing.Point(923, 115);
            this.txtDownPayment.Name = "txtDownPayment";
            this.txtDownPayment.ReadOnly = true;
            this.txtDownPayment.Size = new System.Drawing.Size(100, 20);
            this.txtDownPayment.TabIndex = 6;
            this.txtDownPayment.TextChanged += new System.EventHandler(this.txtDownPayment_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(657, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "down payment amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "loan origination fees";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "interest rate (%, int)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "loan term (months, periods)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "monthly payment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "loan amount (PV)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "loan-to-value ratio (%)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "3. MORTGAGE AND PURCHASE INPUTS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "depreciable closing costs";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "purchase price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "other closing costs";
            // 
            // txtDepreciableClosingCosts
            // 
            this.txtDepreciableClosingCosts.Location = new System.Drawing.Point(218, 255);
            this.txtDepreciableClosingCosts.Name = "txtDepreciableClosingCosts";
            this.txtDepreciableClosingCosts.Size = new System.Drawing.Size(100, 20);
            this.txtDepreciableClosingCosts.TabIndex = 7;
            // 
            // txtOtherClosingCosts
            // 
            this.txtOtherClosingCosts.Location = new System.Drawing.Point(218, 284);
            this.txtOtherClosingCosts.Name = "txtOtherClosingCosts";
            this.txtOtherClosingCosts.Size = new System.Drawing.Size(100, 20);
            this.txtOtherClosingCosts.TabIndex = 8;
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(218, 139);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(100, 20);
            this.txtPurchasePrice.TabIndex = 1;
            this.txtPurchasePrice.Text = "135000";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(16, 556);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(147, 23);
            this.btnBack.TabIndex = 88;
            this.btnBack.Text = "<-- &back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtCurrentMortgage
            // 
            this.txtCurrentMortgage.Location = new System.Drawing.Point(218, 23);
            this.txtCurrentMortgage.Name = "txtCurrentMortgage";
            this.txtCurrentMortgage.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentMortgage.TabIndex = 89;
            // 
            // txtSingleMortgageRecord
            // 
            this.txtSingleMortgageRecord.Location = new System.Drawing.Point(1015, 6);
            this.txtSingleMortgageRecord.Multiline = true;
            this.txtSingleMortgageRecord.Name = "txtSingleMortgageRecord";
            this.txtSingleMortgageRecord.ReadOnly = true;
            this.txtSingleMortgageRecord.Size = new System.Drawing.Size(40, 23);
            this.txtSingleMortgageRecord.TabIndex = 90;
            this.txtSingleMortgageRecord.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(15, 445);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(147, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "&save (update)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreateMortgage
            // 
            this.btnCreateMortgage.Location = new System.Drawing.Point(15, 416);
            this.btnCreateMortgage.Name = "btnCreateMortgage";
            this.btnCreateMortgage.Size = new System.Drawing.Size(147, 23);
            this.btnCreateMortgage.TabIndex = 92;
            this.btnCreateMortgage.Text = "&create";
            this.btnCreateMortgage.UseVisualStyleBackColor = true;
            this.btnCreateMortgage.Click += new System.EventHandler(this.btnCreateMortgage_Click);
            // 
            // txtAllMortgageRecords
            // 
            this.txtAllMortgageRecords.Location = new System.Drawing.Point(364, 285);
            this.txtAllMortgageRecords.Multiline = true;
            this.txtAllMortgageRecords.Name = "txtAllMortgageRecords";
            this.txtAllMortgageRecords.ReadOnly = true;
            this.txtAllMortgageRecords.Size = new System.Drawing.Size(669, 345);
            this.txtAllMortgageRecords.TabIndex = 93;
            this.txtAllMortgageRecords.TabStop = false;
            // 
            // cboPropertyIDs
            // 
            this.cboPropertyIDs.FormattingEnabled = true;
            this.cboPropertyIDs.Location = new System.Drawing.Point(583, 198);
            this.cboPropertyIDs.Name = "cboPropertyIDs";
            this.cboPropertyIDs.Size = new System.Drawing.Size(185, 21);
            this.cboPropertyIDs.TabIndex = 94;
            this.cboPropertyIDs.SelectedIndexChanged += new System.EventHandler(this.cboPropertyIDs_SelectedIndexChanged);
            // 
            // txtCurrentPropertyAddress
            // 
            this.txtCurrentPropertyAddress.Location = new System.Drawing.Point(218, 81);
            this.txtCurrentPropertyAddress.Name = "txtCurrentPropertyAddress";
            this.txtCurrentPropertyAddress.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPropertyAddress.TabIndex = 95;
            // 
            // txtSeeAll
            // 
            this.txtSeeAll.Location = new System.Drawing.Point(15, 503);
            this.txtSeeAll.Name = "txtSeeAll";
            this.txtSeeAll.Size = new System.Drawing.Size(147, 23);
            this.txtSeeAll.TabIndex = 97;
            this.txtSeeAll.Text = "see &all records";
            this.txtSeeAll.UseVisualStyleBackColor = true;
            this.txtSeeAll.Click += new System.EventHandler(this.btnSeeAll_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(657, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 13);
            this.label10.TabIndex = 98;
            this.label10.Text = "DERIVED CALCULATIONS";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(380, 202);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(197, 13);
            this.label13.TabIndex = 99;
            this.label13.Text = "Properties Available to Attach Mortgage:";
            // 
            // cboMortgageRecord
            // 
            this.cboMortgageRecord.FormattingEnabled = true;
            this.cboMortgageRecord.Location = new System.Drawing.Point(12, 58);
            this.cboMortgageRecord.Name = "cboMortgageRecord";
            this.cboMortgageRecord.Size = new System.Drawing.Size(300, 21);
            this.cboMortgageRecord.TabIndex = 100;
            this.cboMortgageRecord.SelectedIndexChanged += new System.EventHandler(this.cboMortgageRecord_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 13);
            this.label14.TabIndex = 101;
            this.label14.Text = "Mortgage of Record";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 13);
            this.label15.TabIndex = 104;
            this.label15.Text = "property address (if set):";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 13);
            this.label16.TabIndex = 105;
            this.label16.Text = "current mortgage ID selected:";
            // 
            // txtCurrentPropertyID
            // 
            this.txtCurrentPropertyID.Location = new System.Drawing.Point(218, 52);
            this.txtCurrentPropertyID.Name = "txtCurrentPropertyID";
            this.txtCurrentPropertyID.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPropertyID.TabIndex = 106;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 13);
            this.label17.TabIndex = 107;
            this.label17.Text = "property Id (if set):";
            // 
            // btnDerived
            // 
            this.btnDerived.Location = new System.Drawing.Point(163, 416);
            this.btnDerived.Name = "btnDerived";
            this.btnDerived.Size = new System.Drawing.Size(147, 139);
            this.btnDerived.TabIndex = 108;
            this.btnDerived.Text = "do deri&ved calculations";
            this.btnDerived.UseVisualStyleBackColor = true;
            this.btnDerived.Visible = false;
            this.btnDerived.Click += new System.EventHandler(this.btnDerived_Click);
            // 
            // grpMortgagePurchase
            // 
            this.grpMortgagePurchase.Controls.Add(this.label16);
            this.grpMortgagePurchase.Controls.Add(this.label2);
            this.grpMortgagePurchase.Controls.Add(this.label17);
            this.grpMortgagePurchase.Controls.Add(this.label5);
            this.grpMortgagePurchase.Controls.Add(this.txtCurrentPropertyID);
            this.grpMortgagePurchase.Controls.Add(this.label6);
            this.grpMortgagePurchase.Controls.Add(this.label7);
            this.grpMortgagePurchase.Controls.Add(this.label15);
            this.grpMortgagePurchase.Controls.Add(this.txtLtvRatio);
            this.grpMortgagePurchase.Controls.Add(this.txtPeriods);
            this.grpMortgagePurchase.Controls.Add(this.txtRate);
            this.grpMortgagePurchase.Controls.Add(this.txtLoanOriginationFees);
            this.grpMortgagePurchase.Controls.Add(this.label9);
            this.grpMortgagePurchase.Controls.Add(this.label11);
            this.grpMortgagePurchase.Controls.Add(this.txtCurrentPropertyAddress);
            this.grpMortgagePurchase.Controls.Add(this.label12);
            this.grpMortgagePurchase.Controls.Add(this.txtDepreciableClosingCosts);
            this.grpMortgagePurchase.Controls.Add(this.txtOtherClosingCosts);
            this.grpMortgagePurchase.Controls.Add(this.txtPurchasePrice);
            this.grpMortgagePurchase.Controls.Add(this.txtCurrentMortgage);
            this.grpMortgagePurchase.Location = new System.Drawing.Point(12, 85);
            this.grpMortgagePurchase.Name = "grpMortgagePurchase";
            this.grpMortgagePurchase.Size = new System.Drawing.Size(346, 324);
            this.grpMortgagePurchase.TabIndex = 109;
            this.grpMortgagePurchase.TabStop = false;
            this.grpMortgagePurchase.Text = "3. MORTGAGE AND PURCHASE INPUTS";
            this.grpMortgagePurchase.Visible = false;
            // 
            // btnValidateMortgage
            // 
            this.btnValidateMortgage.Location = new System.Drawing.Point(16, 532);
            this.btnValidateMortgage.Name = "btnValidateMortgage";
            this.btnValidateMortgage.Size = new System.Drawing.Size(147, 23);
            this.btnValidateMortgage.TabIndex = 110;
            this.btnValidateMortgage.Text = "&validate mortgage";
            this.btnValidateMortgage.UseVisualStyleBackColor = true;
            this.btnValidateMortgage.Click += new System.EventHandler(this.btnValidateMortgage_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1057, 688);
            this.Controls.Add(this.btnValidateMortgage);
            this.Controls.Add(this.grpMortgagePurchase);
            this.Controls.Add(this.btnDerived);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboMortgageRecord);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSeeAll);
            this.Controls.Add(this.cboPropertyIDs);
            this.Controls.Add(this.txtAllMortgageRecords);
            this.Controls.Add(this.btnCreateMortgage);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtSingleMortgageRecord);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtMonthlyPayment);
            this.Controls.Add(this.txtPresVal);
            this.Controls.Add(this.txtDownPayment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Property Analyzer  - Input Screen 2 of 2";
            this.grpMortgagePurchase.ResumeLayout(false);
            this.grpMortgagePurchase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtLoanOriginationFees;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtPeriods;
        private System.Windows.Forms.TextBox txtMonthlyPayment;
        private System.Windows.Forms.TextBox txtPresVal;
        private System.Windows.Forms.TextBox txtLtvRatio;
        private System.Windows.Forms.TextBox txtDownPayment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDepreciableClosingCosts;
        private System.Windows.Forms.TextBox txtOtherClosingCosts;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtCurrentMortgage;
        private System.Windows.Forms.TextBox txtSingleMortgageRecord;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreateMortgage;
        private System.Windows.Forms.TextBox txtAllMortgageRecords;
        private System.Windows.Forms.ComboBox cboPropertyIDs;
        private System.Windows.Forms.TextBox txtCurrentPropertyAddress;
        private System.Windows.Forms.Button txtSeeAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboMortgageRecord;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCurrentPropertyID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnDerived;
        private System.Windows.Forms.GroupBox grpMortgagePurchase;
        private System.Windows.Forms.Button btnValidateMortgage;
    }
}
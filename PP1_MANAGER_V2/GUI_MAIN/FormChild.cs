using GUI_MAIN.BLL;
using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_MAIN
{
    public partial class frmFormChild : Form
    {
        public frmFormChild()
        {
            InitializeComponent();
        }
        
        History historyMain = new History();
        public bool actionAddData = false;

        public frmFormChild(Address address, DataTable listAfter)
        {
            InitializeComponent();
            this.historyMain.historyAddressID = address.addressID;
            this.lblDepartment.Text = address.departmentName;

            //Thuc hien lay du lieu
            this.dgvData.Rows.Clear();
            foreach (DataRow row in listAfter.Rows)
            {
                this.dgvData.Rows.Add(row.ItemArray);
            }
            this.lblAddress.Text = address.addressName;
            this.lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.lblSum.Text = "Số bản ghi: " + listAfter.Rows.Count;

        }

        private void frmFormChild_Load(object sender, EventArgs e)
        {
            //SetFucntion
            this.rdoOK.Checked = true;
            this.txtResistor.TextChanged += TextBox_TextChanged;
            this.txtVoltage.TextChanged += TextBox_TextChanged;

            this.txtResistor.Focus();
        }
        //Thuc hien lay
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long valueA = 0;
                long valueB = 0;

                bool isValidA = long.TryParse(this.txtResistor.Text, out valueA);
                bool isValidB = long.TryParse(this.txtVoltage.Text, out valueB);


                if (valueA > 1000 || valueB > 100)
                {
                    this.rdoNG.Checked = true;
                }
                else
                {
                    this.rdoOK.Checked = true;
                }

            }
            catch
            {
                this.rdoOK.Checked = true;
            }

        }

        private void btnCloseChild_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            //Lay du lieu
            this.grpMain.Enabled = false;
            this.GetInput();
            string resultValue = ActionChild.CheckValueInput(ref this.historyMain);
            if (resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error Validate Child", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.grpMain.Enabled = true;
                return;
            }

            resultValue = ActionChild.AddHistory(this.historyMain);
            if (resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error Add History", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.actionAddData = true;
            this.Close();
        }
        private void GetInput()
        {
            this.historyMain.historyResistor = this.txtResistor.Text;//Lay dien  tro
            this.historyMain.historyVoltage = this.txtVoltage.Text;//Lay hieu dien the
            this.historyMain.historyNote = this.txtNote.Text;//Lay ghi chu
            this.historyMain.historyStatus = this.rdoOK.Checked;//Thuc hien lay  trang thai
        }

        private void rdoOK_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOK.Checked == true)
            {
                rdoOK.ForeColor = Color.Green;
                rdoOK.Font = new Font(rdoOK.Font.FontFamily, 18, rdoOK.Font.Style);
                rdoNG.ForeColor = Color.Black;
                rdoNG.Font = new Font(rdoNG.Font.FontFamily, 14, rdoNG.Font.Style);
            }
            else
            {
                rdoOK.ForeColor = Color.Black;
                rdoOK.Font = new Font(rdoOK.Font.FontFamily, 14, rdoOK.Font.Style);
                rdoNG.ForeColor = Color.Red;
                rdoNG.Font = new Font(rdoNG.Font.FontFamily, 18, rdoNG.Font.Style);
            }
        }

        private void txtResistor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
    }
}

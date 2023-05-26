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
            this.historyMain.historyAddressID = address.addressID;
            InitializeComponent();

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
            this.txtResistor.Focus();
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
    }
}

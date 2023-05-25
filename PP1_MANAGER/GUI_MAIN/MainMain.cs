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
    public partial class frmMainMain : Form
    {
        public frmMainMain()
        {
            InitializeComponent();
        }

        Address addressMain = new Address();
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void frmMainMain_Load(object sender, EventArgs e)
        {
            this.grpAdd.Enabled = false;
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.CheckAddress();
                return;
            }
        }
        private void CheckAddress()
        {
            DataTable listAfter = new DataTable();
            this.addressMain.addressName = this.txtAddress.Text;

            string resultValue = ActionMain.AddItem(ref this.addressMain, ref listAfter);
            if(resultValue == RESULT.ERROR_HAS_DATA)
            {


                return;
            }

            if(resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error Input Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.lblAddress.Text = 
        }
    }
}

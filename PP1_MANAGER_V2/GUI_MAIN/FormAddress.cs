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
    public partial class frmFormAddress : Form
    {
        public frmFormAddress()
        {
            InitializeComponent();
        }

        private void frmFormAddress_Load(object sender, EventArgs e)
        {
            this.grpAdd.Enabled = false;
            string resultValue = ManagerAddress.GetDataAddress(ref this.dgvData);
            if (resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error Load Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.lblSum.Text = "Số bản ghi: " + this.dgvData.Rows.Count;
            this.grpAdd.Enabled = true;
            this.txtAddress.Focus();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            try
            {
                this.grpAdd.Enabled = false;
                string resultValue = ManagerAddress.AddAddress(this.txtAddress.Text);
                if (resultValue != RESULT.OK)
                {
                    MessageBox.Show(resultValue, "Error Add Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.grpAdd.Enabled = true;
                    return;
                }

                MessageBox.Show("Thêm thành công vị trí: " +this.txtAddress.Text + "!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ManagerAddress.GetDataAddress(ref this.dgvData);
                if (resultValue != RESULT.OK)
                {
                    MessageBox.Show(resultValue, "Error ReLoad Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.grpAdd.Enabled = false;
                    return;
                }
                this.lblSum.Text = "Số bản ghi: " + this.dgvData.Rows.Count;
                this.grpAdd.Enabled = true;
                this.txtAddress.Text = "";

            }
            finally
            {
                this.txtAddress.Focus();
            }

        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btnAddAddress.PerformClick();
            }
        }
    }
}

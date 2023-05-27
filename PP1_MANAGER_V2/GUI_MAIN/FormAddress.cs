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
using MyExcel = Microsoft.Office.Interop.Excel;

namespace GUI_MAIN
{
    public partial class frmFormAddress : Form
    {
        public frmFormAddress()
        {
            InitializeComponent();
        }
        private Address tempAddress = new Address();

        public frmFormAddress(ComboBox combobox)
        {
            InitializeComponent();
            this.cmbAddress.DataSource = combobox.DataSource;
            this.cmbAddress.DisplayMember = "departmentName"; // Hiển thị dữ liệu từ cột "Name"
            this.cmbAddress.ValueMember = "departmentID"; // Lấy giá trị từ cột "ID"
            this.cmbAddress.SelectedIndex = -1;
            this.tempAddress.addressDepartment = -1;
        }


        private void frmFormAddress_Load(object sender, EventArgs e)
        {
            this.grpAdd.Enabled = false;
            this.ReLoad();
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

                this.tempAddress.addressName = this.txtAddress.Text;

                string resultValue = ManagerAddress.AddAddress(this.tempAddress);
                if (resultValue != RESULT.OK)
                {
                    MessageBox.Show(resultValue, "Error Add Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.grpAdd.Enabled = true;
                    return;
                }

                MessageBox.Show("Thêm thành công vị trí: " + this.txtAddress.Text + "!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ReLoad();
              

            }
            finally
            {
                this.txtAddress.Focus();
            }

        }
        private void ReLoad()
        {
            string totalRow = "";
            string resultValue = ManagerAddress.GetDataAddress(ref totalRow, ref this.dgvData);
            if (resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error ReLoad Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.grpAdd.Enabled = false;
                return;
            }
            this.lblSum.Text = "Số bản ghi: " + totalRow;
            this.grpAdd.Enabled = true;
            this.txtAddress.Text = "";
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAddAddress.PerformClick();
            }
        }

        private void cmbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tempAddress.addressDepartment = Convert.ToInt32(this.cmbAddress.SelectedValue);
            this.tempAddress.departmentName = this.cmbAddress.Text;
        }

        /// <summary>
        /// Thuc hien chuc nang import excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.grpAdd.Enabled = false;
                    using (var ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "Excel file: |*.xlsx;";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            List<ImportAddress> listAdd = new List<ImportAddress>();
                            string resultValue = ManagerAddress.CheckFileImport(ofd.FileName, ref listAdd, this.cmbAddress);
                            if (resultValue != RESULT.OK)
                            {
                                MessageBox.Show(resultValue, "Error Add Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            DialogResult dialogResult = MessageBox.Show("Bạn có thực sự muốn chèn file excel: " + ofd.FileName + "?", "Confirm Import File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                resultValue = ManagerAddress.AddAddressMulti(listAdd);
                                MessageBox.Show("Import thành công các vị trí: " + listAdd.Count, "Import Excel Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.ReLoad();
                            }    
                        }
                    }
                }
                finally
                {
                    this.grpAdd.Enabled = true;
                }
            }
            finally
            {


            }
        }
    }
}

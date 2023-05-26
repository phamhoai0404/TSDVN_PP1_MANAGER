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
        History historyMain = new History();
        DataTable listAfter = new DataTable();

        //Thuc hien lay du lieu
        private void GetInput()
        {
            this.historyMain.historyAddressID = this.addressMain.addressID;//Lay dia chi ID cua ke
            this.historyMain.historyResistor = this.txtResistor.Text;//Lay dien  tro
            this.historyMain.historyVoltage = this.txtVoltage.Text;//Lay hieu dien the
            this.historyMain.historyNote = this.txtNote.Text;//Lay ghi chu
            this.historyMain.historyStatus = this.rdoOK.Checked;//Thuc hien lay  trang thai
        }
        private void ClearData()
        {
            this.grpAdd.Enabled = false;
            this.txtAddress.Text = "";
            this.lblAddress.Text = "NO";
            this.txtResistor.Text = "";
            this.txtVoltage.Text = "";
            this.rdoOK.Checked = true;
            this.txtNote.Text = "";

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearData();
            this.txtAddress.Focus();
        }
        #region Action Style
        /// <summary>
        /// Thuc hien set nut hanh dong trang thai
        /// </summary>
        /// <param name="action"></param>
        /// CreatedBy: HoaiPT(?/?/2022)
        private void actionButton(bool action)
        {
            if (action == true)
            {
                this.picExecute.Visible = false;
                this.picDone.Visible = true;
                this.grpMainMain.Enabled = true;

                this.updateLable("Sẵn sàng thực hiện");
            }
            else
            {
                this.grpMainMain.Enabled = false;

                this.picDone.Visible = false;
                this.picExecute.Visible = true;
            }
            this.picExecute.Update();
            this.picDone.Update();
        }
        /// <summary>
        /// Thuc hien update label 
        /// </summary>
        /// <param name="nameText">Ten label muon cap nhat</param>
        /// CreatedBy: HoaiPT(?/?/2022)
        private void updateLable(string nameText)
        {
            this.lblDisplay.Text = nameText;
            this.lblDisplay.Update();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.actionButton(false);
                this.updateLable("Thực hiện lấy dữ liệu");
                //Thuc hien lay du lieu
                this.GetInput();

                this.updateLable("Thực hiện check dữ liệu");
                //Thuc hien check du lieu dau vao
                string resultValue = ActionMain.CheckValueInput(ref this.historyMain);
                if (resultValue != RESULT.OK)
                {
                    MessageBox.Show(resultValue, "Error Validate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.updateLable("Thực hiện ghi lịch sử");
                //Thuc hien ghi lai du lieu
                resultValue = ActionMain.AddHistory(this.historyMain);
                if (resultValue != RESULT.OK)
                {
                    MessageBox.Show(resultValue, "Error Add History", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.ClearData();//Thuc hien tro ve
            }
            finally
            {
                if (this.grpAdd.Enabled)
                {
                    this.actionButton(true);
                    this.txtResistor.Focus();
                }
                else
                {
                    this.tmrProgram.Start();
                }
            }
        }


        private void frmMainMain_Load(object sender, EventArgs e)
        {
            this.actionButton(false);
            this.updateLable("Load dữ liệu");
            this.grpAdd.Enabled = false;
            this.tmrSartLoad.Start();
        }
        private void tmrSartLoad_Tick(object sender, EventArgs e)
        {
            this.tmrSartLoad.Stop();
            this.updateLable("Load dữ liệu bộ phận");

            DataTable listDepartment = new DataTable();
            string resultValue = ActionMain.GetDepartment(ref listDepartment);
            if (resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error Get Department", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.cmbAddress.DataSource = listDepartment;
            this.cmbAddress.DisplayMember = "departmentName"; // Hiển thị dữ liệu từ cột "Name"
            this.cmbAddress.ValueMember = "departmentID"; // Lấy giá trị từ cột "ID"
            this.cmbAddress.SelectedIndex = -1;
            this.addressMain.addressDepartment = -1;
            this.addressMain.departmentName = "";

            this.tmrProgram.Start();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            this.grpAdd.Enabled = false;

            if (e.KeyCode == Keys.Enter)
            {
                this.CheckAddress();
                return;
            }

        }
        private void CheckAddress()
        {
            try
            {
                this.actionButton(false);
                this.updateLable("Thực hiện lấy check địa chỉ");
                this.listAfter.Clear();//Clear du lieu
                this.addressMain.addressName = this.txtAddress.Text;
                this.addressMain.addressID = MdlCommon.NOT_ADDRESS;

                this.updateLable("Check sự tồn vị trí trong lịch sử");
                string resultValue = ActionMain.CheckAddress(ref this.addressMain, ref listAfter);
                if (resultValue == RESULT.ERROR_HAS_DATA)
                {
                    this.updateLable("Trường hợp đã có dữ liệu");
                    frmFormChild formChild = new frmFormChild(this.addressMain, this.listAfter);
                    formChild.ShowDialog();
                    if (formChild.actionAddData == true)
                    {
                        this.tmrProgram.Start();
                    }
                    return;
                }

                
                if (resultValue != RESULT.OK)
                {
                    MessageBox.Show(resultValue, "Error Input Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.grpAdd.Enabled = true;
                this.lblAddress.Text = this.addressMain.addressName;
            }
            finally
            {
                this.actionButton(true);
                if (this.grpAdd.Enabled)
                {
                    this.txtResistor.Focus();
                }
                else
                {
                    this.txtAddress.Focus();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.CheckAddress();
        }

        private void tmrProgram_Tick(object sender, EventArgs e)
        {
            this.tmrProgram.Stop();

            this.updateLable("Load dữ liệu toàn bộ...");
            string totalSum = "";
            string resultValue = ActionMain.GetData(ref totalSum, ref this.dgvData);
            if (resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error Get Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.lblSum.Text = "Số bản ghi: " + totalSum;
            this.actionButton(true);
            this.txtAddress.Focus();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnManagerAddress_Click(object sender, EventArgs e)
        {
            this.actionButton(false);
            this.updateLable("Quản lý Vị trí kệ");
            frmFormAddress frmAddress = new frmFormAddress(this.cmbAddress);
            frmAddress.ShowDialog();
            this.actionButton(true);
            this.txtAddress.Focus();

        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            this.actionButton(false);
            this.updateLable("Xuất dữ liệu");
            frmFormExport frmFormExport = new frmFormExport();
            frmFormExport.ShowDialog();
            this.actionButton(true);
            this.txtAddress.Focus();
        }

        private void cmbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                this.addressMain.addressDepartment = Convert.ToInt32(this.cmbAddress.SelectedValue);
                this.addressMain.departmentName = this.cmbAddress.Text;
            }
            catch 
            {
            }
        }
    }
}

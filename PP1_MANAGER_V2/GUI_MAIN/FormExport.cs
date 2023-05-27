using GUI_MAIN.BLL;
using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_MAIN
{
    public partial class frmFormExport : Form
    {
        public frmFormExport(ComboBox comboBox)
        {
            InitializeComponent();
            this.cmbAddress.DataSource = comboBox.DataSource;
            this.cmbAddress.DisplayMember = "departmentName"; // Hiển thị dữ liệu từ cột "Name"
            this.cmbAddress.ValueMember = "departmentID"; // Lấy giá trị từ cột "ID"
            this.cmbAddress.SelectedIndex = -1;

            this.valueExport.deparmentID = -1;//Set dau tien khong lua chon gia tri nao

        }
        SearchData valueExport = new SearchData();

        private void frmFormExport_Load(object sender, EventArgs e)
        {
            this.pnlMain.Enabled = false;
            this.grpDate.Enabled = false;//Mac dinh dang khong chon ngay

            string totalSum = "";
            string resultValue = ActionMain.GetData(ref totalSum, ref this.dgvData);
            if (resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error Get Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.lblSum.Text = "Số bản ghi: " + totalSum;

            this.valueExport.deparmentID = MdlCommon.NOT_DEPARTMENT;
            this.pnlMain.Enabled = true;
        }



        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            this.grpDate.Enabled = this.chkDate.Checked;
        }

        private void GetInput()
        {
            //Thuc hien lay du lieu


            this.valueExport.deparmentID = Convert.ToInt64(this.cmbAddress.SelectedValue == null ? MdlCommon.NOT_DEPARTMENT : this.cmbAddress.SelectedValue);


            if (this.chkDate.Checked)
            {
                this.valueExport.exportDate = true;
                this.valueExport.dateFrom = this.dtmFrom.Value;
                this.valueExport.dateTo = this.dtmTo.Value;
            }
            else
            {
                this.valueExport.exportDate = false;
            }
            this.valueExport.keySearch = this.txtSearch.Text;
        }
        /// <summary>
        /// Thuc hien xuat du lieu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnlMain.Enabled = false;

                //Lay gia tri
                this.GetInput();

                DataTable listData = new DataTable();
                string resultValue = ActionExport.ExportData(this.valueExport, ref listData);
                if (resultValue != RESULT.OK)
                {
                    MessageBox.Show(resultValue, "Error Get Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string folderPath = "";
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    DialogResult result = folderBrowserDialog.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                    {
                        folderPath = MyFunction.ConvertLocalToNetwork(folderBrowserDialog.SelectedPath);
                    }
                }
                //Neu khong con cai nao thi dung lai
                if (folderPath == "") return;

                var csv = new StringBuilder();
                string tempAdd = "";
                if (this.valueExport.deparmentID != -1)
                {
                    tempAdd = "\"Bộ phận:\"" + ",\"" + this.cmbAddress.Text + "\"";
                    csv.AppendLine(tempAdd);
                }
                else
                {
                    tempAdd = "\"Bộ phận:\"" + ",\"ALL\"";
                    csv.AppendLine(tempAdd);
                }
                if (this.valueExport.exportDate == true)
                {
                    tempAdd = "\"Từ ngày:\"" + ",\"'" + this.valueExport.dateFrom?.ToString("dd/MM/yyyy") + "\"";
                    csv.AppendLine(tempAdd);
                    tempAdd = "\"Đến ngày:\"" + ",\"'" + this.valueExport.dateTo?.ToString("dd/MM/yyyy") + "\"";
                    csv.AppendLine(tempAdd);
                }

                //Thuc hien ghi du lieu
                tempAdd = "\"Ngày thêm\",\"Vị trí\",\"Trạng thái\",\"Điện trở\",\"Hiệu đện thế\",\"Ghi chú\"";//Tieu de
                csv.AppendLine(tempAdd);
                foreach (DataRow row in listData.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    csv.AppendLine(string.Join(",", fields));
                }

                //Thuc hien lua file
                string tempFile = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                tempFile = Path.Combine(folderPath, tempFile);
                using (var writer = new StreamWriter(tempFile, false, Encoding.UTF8))
                {
                    writer.Write(csv.ToString());
                }
                MessageBox.Show("Xuất file thành công: " + tempFile + "!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.pnlMain.Enabled = true;
            }



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//Thuc hien dong du lieu
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch.PerformClick();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.txtSearch.Text = "";
            this.chkDate.Checked = false;
            this.cmbAddress.SelectedIndex = -1;
            this.SearchData();
        }

        private void SearchData()
        {
            this.pnlMain.Enabled = false;

            //Lay gia tri
            this.GetInput();

            string totalRow = "";
            string resultValue = ActionExport.GetDataSearch(this.valueExport, ref this.dgvData, ref totalRow);
            if (resultValue != RESULT.OK)
            {
                MessageBox.Show(resultValue, "Error Get Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.lblSum.Text = "Số bản ghi: " + totalRow;
            this.pnlMain.Enabled = true;
            this.txtSearch.Focus();
        }

        private void cmbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xuLiDoThi
{
    public partial class XuLyDoThi : Form
    { 
        // SInh viên: Trương Minh Triều - 21110326

        int soDinh;
        // khai báo mảng 1 chiều lưu dữ liệu của ma trận kề
        int[] arr = new int[10000];
        int lenArr = 0;
        // khai báo mảng 2 chiều cho ma trận kề
        int[,] arrDouble = new int[100, 100];
        
        string output;
        public XuLyDoThi()
        {
            InitializeComponent();
        }

        private void btn_nhapThongTinDoThi_Click(object sender, EventArgs e)
        {
            // xử lý dữ liệu nhập vào text bõ thành dữ liệu chuẩn 
            xuLyDuLieuNhapVao();

            // hiện dữ liệu đã xử lý ra màn hình để kiểm tra
            string outputKiemTra = "Số đỉnh: " + soDinh.ToString() + "\n" + "Ma trận kề của đồ thị: \n    ";
            for (int i = 0; i < soDinh; i++)
            {
                for (int j = 0; j < soDinh; j++)
                    outputKiemTra += arrDouble[i, j].ToString() + " ";

                outputKiemTra += "\n    ";
            }

            MessageBox.Show(outputKiemTra, "Dữ liệu bạn đã nhập là:",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void xuLyDuLieuNhapVao ()
        {
            // lấy số đỉnh từ dữ liệu nhập vào
            soDinh = Convert.ToInt32(tbx_soDinhDoThi.Text);

            // xử lý dữ liệu nhập vào text box từ string chuyển về mảng 1 chiều
            string input = tbx_maTranKeDoThi.Text;
            string[] arrListStr = input.Split('\n');
            int lenArrStr = arrListStr.Length;
            for (int i = 0; i < lenArrStr; i++)
            {
                string[] arrListInt = arrListStr[i].Split(' ');
                int lenArrInt = arrListInt.Length;
                for (int j = 0; j < lenArrInt; j++)
                {
                    string temp = arrListInt[j];
                    arr[lenArr] = Convert.ToInt32(temp);
                    lenArr++;
                }
            }

            // chuyển mảng 1 chiều chứa dữ liệu đã xử lý thành mảng 2 chiều tương ứng ma trận kề
            lenArr = 0;
            for (int i = 0; i < soDinh; i++)
                for (int j = 0; j < soDinh; j++)
                    arrDouble[i, j] = arr[lenArr++];
        }

        private void btn_runLevel1_Click(object sender, EventArgs e)
        {
            
            if (cbx_level1.Text == "Xác định các thông tin đồ thị")
            {
                output = "";
                // Xac dinh do thi co huong hay vo huong
                if (thongTinDoThi.ktraHuongDoThi(arrDouble, soDinh))
                {
                    output += "Đồ thị đã nhập là đồ thị có hướng";

                    // Xac dinh da do thi hay don do thi
                    if (thongTinDoThi.ktraDaDonDoThi(arrDouble, soDinh))
                        output += "\nĐồ thị đã nhập là đa đồ thị";
                    else
                        output += "\nĐồ thị đã nhập là đơn đồ thị";
                }
                else
                {
                    output += "Đồ thị đã nhập là đồ thị vô hướng";

                    // Xac dinh da do thi hay don do thi
                    if (thongTinDoThi.ktraDaDonDoThi(arrDouble, soDinh))
                        output += "\nĐồ thị đã nhập là đa đồ thị";
                    else
                        output += "\nĐồ thị đã nhập là đơn đồ thị";

                    // Xac dinh gia do thi
                    if (thongTinDoThi.ktraGiaDoThi(arrDouble, soDinh))
                        output += "\nĐồ thị đã nhập là giả đồ thị";
                    else
                        output += "\nĐồ thị đã nhập không là giả đồ thị";
                }
                // tinh bac do thi
                output += "\n" + thongTinDoThi.tinhBac(arrDouble, soDinh);
            }

            else if (cbx_level1.Text == "Kiểm tra đồ thị có hướng hay vô hướng")
            {
                output = "";
                if (thongTinDoThi.ktraHuongDoThi(arrDouble, soDinh))
                    output += "Đồ thị đã nhập là đồ thị có hướng";
                else
                    output += "Đồ thị đã nhập là đồ thị vô hướng";
            }

            else if (cbx_level1.Text == "Kiểm tra đơn đồ thị hay đa đồ thị")
            {
                output = "";
                if (thongTinDoThi.ktraDaDonDoThi(arrDouble, soDinh))
                    output += "\nĐồ thị đã nhập là đa đồ thị \n";
                else
                    output += "\nĐồ thị đã nhập là đơn đồ thị \n";
            }

            else if (cbx_level1.Text == "Kiểm tra giả đồ thị")
            {
                output = "";
                if (thongTinDoThi.ktraGiaDoThi(arrDouble, soDinh))
                    output += "\nĐồ thị đã nhập là giả đồ thị";
                else
                    output += "\nĐồ thị đã nhập không là giả đồ thị";
            }

            else if (cbx_level1.Text == "Tính bậc đồ thị")
            {
                output = "";
                output += thongTinDoThi.tinhBac(arrDouble, soDinh);
            }

            MessageBox.Show(output, "Thông tin của bạn cần: ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_runLevel2_Click(object sender, EventArgs e)
        {
            int dinhBatDauDuyet = Convert.ToInt32(tbx_dinhBatDauDuyet.Text);

            if (cbx_level2.Text == "Duyệt đồ thị theo chiều sâu")
            {
                output = "Duyệt sâu: ";
                output += duyetDoThi_duyetSau.duyetSau(arrDouble, soDinh, dinhBatDauDuyet);
            }
            else if (cbx_level2.Text == "Duyệt đồ thị theo chiều rộng")
            {
                output = "Duyệt rộng: ";
                output += duyetDoThi_duyetRong.duyetRong(arrDouble, soDinh, dinhBatDauDuyet);
            }

            MessageBox.Show(output, "Kết quả của duyệt đồ thị theo thuật toán: ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_runLevel3_Click(object sender, EventArgs e)
        {
            if (cbx_level3.Text == "Xây dựng cây khung theo chiều sâu")
            {
                int dinhChonLamGoc = Convert.ToInt32(tbx_dinhChonLamGoc.Text) - 1;

                output = "Cây khung của đồ thị đã nhập là: \n";
                output += xayDungCayKhung_theoChieuSau.xayDungCayKhungDFS(arrDouble, soDinh, dinhChonLamGoc);
            }
            else if (cbx_level3.Text == "Tính số lượng cây khung của đồ thị")
            {

                double temp = Math.Pow(soDinh, soDinh - 2);
                output = "Số lượng cây khung của đồ thị là: " + temp.ToString();
            }

            MessageBox.Show(output, "Kết quả sau khi xử lý là: ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

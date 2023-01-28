using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuLiDoThi
{
    class thongTinDoThi
    {
        // method 1 - thuật toán kiểm tra hướng đồ thị
        public static bool ktraHuongDoThi(int[,] A, int nA)
        {
            for (int i = 0; i < nA; i++)
            {
                for (int j = 0; j < nA; j++)
                {
                    if (A[i, j] != A[j, i])
                        return true;
                }
            }
            return false;
        }

        // method 2 - thuật toán kiểm tra đơn đồ thị / đa đồ thị
        public static bool ktraDaDonDoThi(int[,] A, int nA)
        {
            for (int i = 0; i < nA; i++)
            {
                for (int j = 0; j < nA; j++)
                {
                    if (A[i, j] > 1)
                        return true;
                }
            }
            return false;
        }

        // method 3 - thuật toán kiểm tra giả đồ thị
        public static bool ktraGiaDoThi(int[,] A, int nA)
        {
            for (int i = 0; i < nA; i++)
            {
                if (A[i,i] != 0)
                    return true;
            }
            return false;
        }

        // method 4 - thuật toán tính bậc các đỉnh của đồ thị
        public static string tinhBac(int[,] A, int nA)
        {
            string outputTemp = "";

            // Tinh bac truong hop do thi co huong
            if (ktraHuongDoThi(A, nA))
            {
                for (int i = 0; i < nA; i++)
                {
                    int temp = 0;
                    for (int j = 0; j < nA; j++)
                    {
                        temp += A[i, j];
                    }
                    outputTemp += $"Bậc ra đỉnh {i + 1} là: {temp} \n";
                }

                for (int j = 0; j < nA; j++)
                {
                    int temp = 0;
                    for (int i = 0; i < nA; i++)
                    {
                        temp += A[i, j];
                    }
                    outputTemp += $"Bậc vào đỉnh {j + 1} là: {temp} \n";
                }
            }

            // Tinh bac truong hop do thi vo huong
            else
            {
                for (int i = 0; i < nA; i++)
                {
                    int temp = 0;
                    for (int j = 0; j < nA; j++)
                    {
                        temp += A[i, j];
                    }
                    outputTemp += $"Bậc đỉnh {i + 1} là: {temp} \n";
                }
            }

            return outputTemp;
        }
    }
}

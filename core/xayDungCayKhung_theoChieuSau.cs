using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuLiDoThi
{
    class xayDungCayKhung_theoChieuSau
    {
        static string outputCayKhung = "";

        static int[] chuaXet = new int[100];
        static int[] dsDinhKe = new int[100];
        static int nKe = 0;
        static int[] dsDinhKeTam = new int[100];
        static int nKeTam;

        public static string xayDungCayKhungDFS (int[,] A, int nA, int dinhChonLamGoc)
        {
            outputCayKhung = "";
            for (int i = 0; i < nA; i++)
                chuaXet[i] = 1;

            timCayKhung(A, nA, dinhChonLamGoc);

            for (int i = 0; i < nA; i++)
            {
                if (chuaXet[i] == 1)
                {
                    int temp = timNgayTruoc(A, nA, i);
                    timCayKhung(A, nA, temp);
                }
            }

            return outputCayKhung;
        }

        static int timNgayTruoc(int[, ] A, int nA, int a)
        {
            for (int i = 0; i < nA; i++)
                if (A[a, i] != 0)
                {
                    return i;
                }
            return 0;
        }

        static void timCayKhung(int[, ] A, int nA, int a)
        {
            //outputCayKhung += "\n";
            chuaXet[a] = 0;

            nKeTam = 0;
            for (int i = 0; i < nA; i++)
                if (chuaXet[i] == 1 && A[a, i] != 0)
                    dsDinhKeTam[nKeTam++] = i;

            tongHopDinhKe();
            int temp = dsDinhKe[0];
            xuLi();

            if (chuaXet[temp] == 1)
            {
                
                outputCayKhung += $"({a+1}, {temp+1}) ";
                timCayKhung(A, nA, temp);
            }
        }

        static void tongHopDinhKe()
        {
            int[] temp = new int[100];
            int nTemp = 0;

            for (int i = 0; i < nKeTam; i++)
                temp[nTemp++] = dsDinhKeTam[i];

            for (int i = 0; i < nKe; i++)
                temp[nTemp++] = dsDinhKe[i];

            for (int i = 0; i < nTemp; i++)
                dsDinhKe[i] = temp[i];

            nKe = nTemp;
        }

        static void xuLi()
        {
            for (int i = 0; i < nKe - 1; i++)
                dsDinhKe[i] = dsDinhKe[i + 1];

            nKe--;
        }
    }
}

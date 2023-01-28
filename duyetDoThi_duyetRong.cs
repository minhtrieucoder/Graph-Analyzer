using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuLiDoThi
{
    class duyetDoThi_duyetRong
    {
        static string outputDuyetRong;
        static int[] chuaXet = new int[100];
        static int[] dsDinhKe = new int[100];
        static int[] dsDinhKeTam = new int[100];
        static int nKe = 0;
        static int nKeTam;
        public static string duyetRong(int[,] A, int nA, int dinhBatDauDuyet)
        {
            nKe = 0;
            outputDuyetRong = "";

            // bat dau duyet
            for (int i = 0; i < nA; i++)
                chuaXet[i] = 1;

            duyetDinh(A, nA, dinhBatDauDuyet);
            // ket thuc duyet

            return outputDuyetRong;
        }

        static void duyetDinh (int[,] A, int nA, int a)
        {
            outputDuyetRong += " ";
            chuaXet[a] = 0;

            if (a == 0)
                outputDuyetRong += "a";
            else if (a == 1)
                outputDuyetRong += "b";
            else if (a == 2)
                outputDuyetRong += "c";
            else if (a == 3)
                outputDuyetRong += "d";
            else if (a == 4)
                outputDuyetRong += "e";
            else if (a == 5)
                outputDuyetRong += "f";
            else if (a == 6)
                outputDuyetRong += "g";
            else if (a == 7)
                outputDuyetRong += "h";
            else if (a == 8)
                outputDuyetRong += "k";
            else if (a == 9)
                outputDuyetRong += "m";
            else if (a == 10)
                outputDuyetRong += "i";

            nKeTam = 0;
            for (int i = 0; i < nA; i++)
                if (chuaXet[i] == 1 && A[a, i] != 0 && ktraLap(i))
                    dsDinhKeTam[nKeTam++] = i;

            for (int i = 0; i < nKeTam; i++)
                dsDinhKe[nKe++] = dsDinhKeTam[i];

            int temp = dsDinhKe[0];
            xuLi();

            if (chuaXet[temp] == 1)
                duyetDinh(A, nA, temp);
        }

        static void xuLi()
        {
            for (int i = 0; i < nKe - 1; i++)
                dsDinhKe[i] = dsDinhKe[i + 1];

            nKe--;
        }

        static bool ktraLap(int x)
        {
            for (int i = 0; i < nKe; i++)
                if (x == dsDinhKe[i])
                    return false;

            return true;
        }
    }
}

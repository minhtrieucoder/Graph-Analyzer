using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuLiDoThi
{
    class duyetDoThi_duyetSau
    {
        static string outputDuyetSau;
        static int[] chuaXet = new int[100];
        static int[] dsDinhKe = new int[100];
        static int[] dsDinhKeTam = new int[100];
        static int nKe = 0;
        static int nKeTam;

        public static string duyetSau(int[,] A, int nA, int dinhBatDauDuyet)
        {
            outputDuyetSau = "";
            // bat dau duyet
            for (int i = 0; i < nA; i++)
                chuaXet[i] = 1;

            duyetDinh(A, nA, dinhBatDauDuyet);

            for (int i = 0; i < nA; i++)
            {
                if (chuaXet[i] == 1)
                    duyetDinh(A, nA, i);
            }
            // ket thuc duyet

            return outputDuyetSau;
        }

        static void duyetDinh(int[,] A, int nA, int a)
        {
            outputDuyetSau += " ";
            chuaXet[a] = 0;

            if (a == 0)
                outputDuyetSau += "a";
            else if (a == 1)
                outputDuyetSau += "b";
            else if (a == 2)
                outputDuyetSau += "c";
            else if (a == 3)
                outputDuyetSau += "d";
            else if (a == 4)
                outputDuyetSau += "e";
            else if (a == 5)
                outputDuyetSau += "f";
            else if (a == 6)
                outputDuyetSau += "g";
            else if (a == 7)
                outputDuyetSau += "h";
            else if (a == 8)
                outputDuyetSau += "k";
            else if (a == 9)
                outputDuyetSau += "m";
            else if (a == 10)
                outputDuyetSau += "i"; 

            nKeTam = 0;
            for (int i = 0; i < nA; i++)
                if (chuaXet[i] == 1 && A[a, i] != 0)
                    dsDinhKeTam[nKeTam++] = i;

            tongHopDinhKe();
            int temp = dsDinhKe[0];
            xuLi();

            if (chuaXet[temp] == 1)
                duyetDinh(A, nA, temp);
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

        static bool ktraLap(int x)
        {
            for (int i = 0; i < nKe; i++)
                if (x == dsDinhKe[i])
                    return false;

            return true;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace CommandAT.Tools.GSM
{
    class AtCommandManager
    {
        static public bool ManageCOPN(string result, ref Hashtable hash)
        {
            /*
                 +COPN: “20416″,”T-Mobile NL”
                 +COPN: “20420″,”Orange NL”
                 OK
            */
            if (!result.Contains("+COPN:"))
                return false;
            string exp = @"\+COPN: '(\d+)','(.*)'";
            exp = exp.Replace("'", "\"");

            Regex regCSQ = new Regex(exp);
            MatchCollection mCSQ = regCSQ.Matches(result);

            if (mCSQ.Count == 0)
                return false;

            for (int i = 0; i < mCSQ.Count; i++)
            {
                GroupCollection gc = mCSQ[i].Groups;
                if (gc.Count > 3)
                {
                    string numericn = gc[1].Value;
                    string alphan = gc[2].Value;

                    hash.Add(numericn, alphan);
                }
            }

            return true;
        }

        static public bool ManageCOPS(string result, ref Hashtable hash)
        {
            /*
                +COPN: “20416″,”T-Mobile NL”
                +COPN: “20420″,”Orange NL”
                OK
            */
            if (!result.Contains("+COPS:"))
                return false;
            string exp = @"\+COPS: \((\d+),'([0-9a-zA-Z\-\s]+)','([a-zA-Z\-\s]+)','(\d+)'\)";
            exp = exp.Replace("'", "\"");

            Regex regCSQ = new Regex(exp);
            MatchCollection mCSQ = regCSQ.Matches(result);

            if (mCSQ.Count == 0)
                return false;

            for (int i = 0; i < mCSQ.Count; i++)
            {
                GroupCollection gc = mCSQ[i].Groups;
                if (gc.Count > 3)
                {
                    string numericn = gc[1].Value;
                    string alphan = gc[2].Value;

                    hash.Add(numericn, alphan);
                }
            }

            return true;
        }

        static public bool ManageSMONP(string result, ref Hashtable hash)
        {
            if (!result.Contains("OK"))
                return false;

            if (result.Contains("\r\n2G:\r\n -,-"))
            {
                hash["ACT"] = "3G";
                int posStart = result.IndexOf("3G:\r\n");
                if (posStart == -1)
                    return false;

                int posEnd = result.IndexOf("\r\nOK", posStart);
                if (posEnd == -1)
                    return false;

                string all = result.Substring(posStart, posEnd - posStart);
                all = all.Replace("\r", "");
                string[] lines = all.Split('\n');
                int nbCells = 0;
                foreach (string line in lines)
                {
                    string[] items = line.Split(',');
                    if (items.Length == 4)
                    {
                        nbCells++;
                        hash.Add("UARFC" + nbCells.ToString(), items[0]);
                        hash.Add("PSC" + nbCells.ToString(), items[1]);
                        hash.Add("EC/nO" + nbCells.ToString(), items[2]);
                        hash.Add("RSCP" + nbCells.ToString(), items[3]);
                    }
                }
                hash.Add("NBCELLS", nbCells.ToString());
            }
            else
            {
                hash["ACT"] = "2G";
                int posStart = result.IndexOf("2G:\r\n");
                if (posStart == -1)
                    return false;

                int posEnd = result.IndexOf("\r\n3G", posStart);
                if (posEnd == -1)
                    return false;

                string all = result.Substring(posStart, posEnd - posStart);
                all = all.Replace("\r", "");
                string[] lines = all.Split('\n');
                int nbCells = 0;
                foreach (string line in lines)
                {
                    string[] items = line.Split(',');
                    if (items.Length == 2)
                    {
                        nbCells++;
                        hash.Add("ARFC" + nbCells.ToString(), items[0]);
                        hash.Add("BCCH" + nbCells.ToString(), items[1]);
                    }
                }
                hash.Add("NBCELLS", nbCells.ToString());
            }

            return true;
        }

        static public GSMNetworkMesure ManageSMONI(string result)
        {
            var mesure = new GSMNetworkMesure();

            //\r\n^SMONI: 3G,10787,397,10,-61,208,01,7503,ABB5,22,52\r\n\r\nOK\r\n4þÀ%,þ
            if (string.IsNullOrEmpty(result))
                return null;
            if (!result.Contains("^SMONI: "))
                return null;

            int pos = result.IndexOf(' ');
            result = result.Substring(pos + 1);
            string[] items = result.Split(new char[] { ',', '\r' });
            if (items.Length == 0)
                return mesure;

            if (items[0] == "3G")
            {
                if (items.Length >= 11)
                {
                    mesure.ACT = items[0];
                    mesure.UARFCN = items[1];
                    mesure.PSC = items[2];
                    mesure.ECn0 = items[3];
                    mesure.RSCP = items[4];
                    mesure.MCC = items[5];
                    mesure.MNC = items[6];
                    mesure.LAC = items[7];
                    mesure.Cell = Convert.ToInt32(items[8], 16).ToString();
                    mesure.SQual = items[9];
                    mesure.SRxLev = items[10];
                }
                else
                    return null;
            }
            else
            {
                if (items.Length >= 8)
                {
                    mesure.ACT = items[0];
                    mesure.ARFCN = items[1];
                    mesure.BCCH = items[2];
                    mesure.MCC = items[3];
                    mesure.MNC = items[4];
                    mesure.LAC = items[5];
                    mesure.Cell = Convert.ToInt32(items[6], 16).ToString();
                    mesure.C1 = items[7];
                }
                else
                    return null;
            }

            if (string.IsNullOrEmpty(mesure.ACT) || string.IsNullOrEmpty(mesure.MCC) || string.IsNullOrEmpty(mesure.MNC))
                return null;
            else
                return mesure;
        }

        static public bool ManageCPIN(string result, ref string state)
        {
            if (!result.Contains("OK"))
            {
                state = "phone disabled";
                return false;
            }

            if (!result.Contains("+CPIN: READY"))
            {
                state = "PIN not entered";
                return true;
            }

            state = "PIN OK";
            return true;
        }

        static public bool ManageCOPS(string result, ref string curroperator)
        {
            if (!result.Contains("+COPS:"))
                return false;
            //AT+COPS?
            //+COPS: 0,2,"20801",0
            string exp = @"(.*)\+COPS: (\d+),(\d+),'([0-9a-zA-Z\-\s]+)',(\d+)";
            exp = exp.Replace("'", "\"");

            Regex regCOPS = new Regex(exp);
            Match mCOPS = regCOPS.Match(result);
            if (mCOPS.Success)
                curroperator = mCOPS.Groups[4].Value;

            return true;
        }

        static public bool ManageCREG(string result, ref string state)
        {
            if (!result.Contains("+CREG:"))
                return false;
            //AT+CREG?
            //+CREG: 2,1,"3801","E8C0"
            string exp = @"(.*)\+CREG: (\d+),(\d+),'([0-9a-zA-Z\-\s]+)','([0-9a-zA-Z\-\s]+)'";
            exp = exp.Replace("'", "\"");

            Regex regCREG = new Regex(exp);
            Match mCREG = regCREG.Match(result);
            if (mCREG.Success)
            {
                int n = Convert.ToInt32(mCREG.Groups[2].Value);
                int st = Convert.ToInt32(mCREG.Groups[3].Value);

                switch (st)
                {
                    case 0:
                        state = "Not registered";
                        break;
                    case 1:
                        state = "Registered to home network";
                        break;
                    case 2:
                        state = "Not registered but ME is currently searching for a new operator";
                        break;
                    case 3:
                        state = "Registration denied";
                        break;
                    case 4:
                        state = "Unknown";
                        break;
                    case 5:
                        state = "Registered roaming";
                        break;
                    default:
                        state = "Unknwown";
                        break;
                }
            }

            return true;
        }

        static public bool ManageCSQ(string result, ref Int32 dBm)
        {
            dBm = 0;
            if (!result.Contains("+CSQ:"))
                return false;
            Regex regCSQ = new Regex(@"(.*)+CSQ: (\d+),(\d+)\r\n\r\nOK(.*)");
            Match mCSQ = regCSQ.Match(result);
            if (mCSQ.Success)
            {
                int rssi = Convert.ToInt32(mCSQ.Groups[2].Value);
                switch (rssi)
                {
                    case 0:
                        dBm = -113;
                        break;

                    case 1:
                        dBm = -111;
                        break;

                    case 31:
                        dBm = -51;
                        break;

                    case 99:
                        dBm = 0;
                        break;

                    default:
                        //2..30 -> + 28
                        //-109..-53 => + 56
                        dBm = -109 + (((rssi - 2) * 100 / 28) * 56 / 100);
                        break;
                }

                return true;
            }
            else
                return false;
        }
    }
}

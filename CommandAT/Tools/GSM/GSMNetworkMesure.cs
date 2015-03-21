using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CommandAT.Tools.GSM
{
    /// <summary>
    /// Données d'une mesure de signal GSM
    /// </summary>
    class GSMNetworkMesure
    {
        /// <summary>
        /// Qualité du signal
        /// </summary>
        public double Dbm { get; set; }

        /// <summary>
        /// Parametre technique GPS : ACT
        /// </summary>
        public string ACT { get; set; }

        /// <summary>
        /// Parametre technique GPS : UARFCN
        /// </summary>
        public string UARFCN { get; set; }

        /// <summary>
        /// Parametre technique GPS : PSC
        /// </summary>
        public string PSC { get; set; }

        /// <summary>
        /// Parametre technique GPS : ECn0
        /// </summary>
        public string ECn0 { get; set; }

        /// <summary>
        /// Parametre technique GPS : RSCP
        /// </summary>
        public string RSCP { get; set; }

        /// <summary>
        /// Parametre technique GPS : MCC
        /// </summary>
        public string MCC { get; set; }

        /// <summary>
        /// Parametre technique GPS : MNC 
        /// </summary>
        public string MNC { get; set; }

        /// <summary>
        /// Parametre technique GPS : LAC 
        /// </summary>
        public string LAC { get; set; }

        /// <summary>
        /// Identifiant de la cellule
        /// </summary>
        public string Cell { get; set; }

        /// <summary>
        /// Parametre technique GPS : SQual 
        /// </summary>
        public string SQual { get; set; }

        /// <summary>
        /// Parametre technique GPS : SRxLev 
        /// </summary>
        public string SRxLev { get; set; }

        /// <summary>
        /// Parametre technique GPS : ARFCN 
        /// </summary>
        public string ARFCN { get; set; }

        /// <summary>
        /// Parametre technique GPS : BCCH 
        /// </summary>
        public string BCCH { get; set; }

        /// <summary>
        /// Parametre technique GPS : C1 
        /// </summary>
        public string C1 { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public GSMNetworkMesure()
        {
            ACT = string.Empty;
        }
    }
}

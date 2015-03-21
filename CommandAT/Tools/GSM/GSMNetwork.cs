using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CommandAT.Tools.GSM
{
    /// <summary>
    /// Représente un opérateur de téléphonie GSM
    /// </summary>
    public class GSMNetwork
    {
        /// <summary>
        /// Nom de l'opérateur tel qu'il est diffusé sur le réseau
        /// </summary>
        public string BroadcastName { get; set; }

        /// <summary>
        /// Identifiant du réseau (PLMN Public Land Mobile Network = MCC Mobile Country Code + MNC Mobile Network Code
        /// ex : 20820, 20821, 20888 (bouygues telecom)
        ///    : 20801, 20802 (orange)
        ///    : 20809, 20810, 20813 (sfr)
        /// </summary>
        public string NetworkCode { get; set; }

        public string Generation { get; set; }

        /// <summary>
        /// Informations techniques sur le réseau
        /// </summary>
        internal CommandAT.Tools.GSM.RIL.RILOPERATORINFO Info { get; set; }
    }
}
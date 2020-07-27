using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.Model
{
    public class Ruleta_Model
    {
        private int _IdRuleta;
        private bool _Estado;
        private DateTime _Apertura;
        private DateTime _Cierre;

        public int IdRuleta { get => _IdRuleta; set => _IdRuleta = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }
        public DateTime Apertura { get => _Apertura; set => _Apertura = value; }
        public DateTime Cierre { get => _Cierre; set => _Cierre = value; }
    }
}

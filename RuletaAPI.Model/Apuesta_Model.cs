using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.Model
{
    public class Apuesta_Model
    {
        private int _IdApuesta;
        private int _NumeroApuesta;
        private string _ColorApuesta = string.Empty;
        private decimal _ValorApuesta;
        private int _IdUsuario;
        private int _IdRuleta;

        public int IdApuesta { get => _IdApuesta; set => _IdApuesta = value; }
        public int NumeroApuesta { get => _NumeroApuesta; set => _NumeroApuesta = value; }
        public string ColorApuesta { get => _ColorApuesta; set => _ColorApuesta = value; }
        public decimal ValorApuesta { get => _ValorApuesta; set => _ValorApuesta = value; }
        public int IdRuleta { get => _IdRuleta; set => _IdRuleta = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
    }
}

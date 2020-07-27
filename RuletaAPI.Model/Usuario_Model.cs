using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.Model
{
    public class Usuario_Model
    {
        private int _IdUsuario;
        private string _NombreUsuario;
        private string _Contrasena;
        private decimal _LimiteCredito;

        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string Contrasena { get => _Contrasena; set => _Contrasena = value; }
        public decimal LimiteCredito { get => _LimiteCredito; set => _LimiteCredito = value; }
    }
}

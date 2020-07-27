using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.Model
{
    public class RuletaApuesta_Model
    {
        private Ruleta_Model _Ruleta;
        private Apuesta_Model _Apuesta;

        public Ruleta_Model Ruleta { get => _Ruleta; set => _Ruleta = value; }
        public Apuesta_Model Apuesta { get => _Apuesta; set => _Apuesta = value; }
    }
}

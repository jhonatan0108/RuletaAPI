using RuletaAPI.DataAccess;
using RuletaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.Management
{
    public class Ruleta_Management
    {
        public static Ruleta Model_To_RuletaDB(Ruleta_Model model)
        {
            try
            {
                Ruleta ruleta = new Ruleta()
                {
                    Estado = model.Estado,
                    Apertura = model.Apertura.ToString("yyyy/MM/ddTHH:mm:ss.fffffffK"),
                };
                return ruleta;
            }
            catch (Exception ex)
            {

                throw new Exception("MxMTR - " + ex.Message);
            }
        }
        public static Ruleta_Model RuletaDB_To_Model(Ruleta model)
        {
            try
            {
                Ruleta_Model ruleta = new Ruleta_Model();
                if (model != null)
                {
                    ruleta = new Ruleta_Model()
                    {
                        IdRuleta = model.IdRuleta,
                        Estado = model.Estado,
                        Apertura = string.IsNullOrEmpty(model.Apertura) ? DateTime.MinValue : DateTime.Parse(model.Apertura),
                        Cierre = string.IsNullOrEmpty(model.Cierre) ? DateTime.MinValue : DateTime.Parse(model.Cierre)
                    };
                }
                return ruleta;
            }
            catch (Exception ex)
            {
                throw new Exception("MxRTM - " + ex.Message);
            }
        }
        public static List<Ruleta_Model> ListRuletasDB_To_Model(List<Ruleta> listaR)
        {
            try
            {
                List<Ruleta_Model> listaRuletas = new List<Ruleta_Model>();
                foreach (var item in listaR)
                {
                    Ruleta_Model ruleta = new Ruleta_Model()
                    {
                        IdRuleta = item.IdRuleta,
                        Estado = item.Estado,
                        Apertura = string.IsNullOrEmpty(item.Apertura) ? DateTime.MinValue : DateTime.Parse(item.Apertura),
                        Cierre = string.IsNullOrEmpty(item.Cierre) ? DateTime.MinValue : DateTime.Parse(item.Cierre)
                    };
                    listaRuletas.Add(ruleta);
                }

                return listaRuletas;
            }
            catch (Exception ex)
            {
                throw new Exception("MxLRTM - " + ex.Message);
            }
        }
    }
}

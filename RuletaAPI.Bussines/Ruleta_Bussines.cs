using RuletaAPI.DataAccess;
using RuletaAPI.Management;
using RuletaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.Bussines
{
    public class Ruleta_Bussines
    {
        public Ruleta_Model crearRuleta()
        {
            try
            {
                Ruleta_Model modeloRuleta = new Ruleta_Model()
                {
                    Estado = false,
                    Apertura = DateTime.Now
                };
                return Ruleta_Management.RuletaDB_To_Model(new AccesoDatos().crearRuleta(Ruleta_Management.Model_To_RuletaDB(modeloRuleta)));
            }
            catch (Exception ex)
            {
                throw new Exception("BxCR - " + ex.Message);
            }
        }
        public bool aperturaRuleta(int IdRuleta)
        {
            try
            {
                bool respuesta = false;
                Ruleta datosRuleta = new AccesoDatos().consultaRuletaporID(IdRuleta);
                if (datosRuleta != null)
                {
                    datosRuleta.Apertura = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss.fffffffK");
                    datosRuleta.Estado = true;
                    respuesta = new AccesoDatos().aperturayCierreRuleta(datosRuleta);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("BxCR - " + ex.Message);
            }
        }
        public bool cierreRuleta(int IdRuleta)
        {

            try
            {
                bool respuesta = false;
                Ruleta datosRuleta = new AccesoDatos().consultaRuletaporID(IdRuleta);
                if (datosRuleta != null)
                {
                    datosRuleta.Cierre = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss.fffffffK");
                    datosRuleta.Estado = false;
                    respuesta = new AccesoDatos().aperturayCierreRuleta(datosRuleta);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("BxCR - " + ex.Message);
            }
        }
        public Ruleta_Model consultaRuletaporID(int idRuleta, bool cierre = false)
        {
            try
            {
                if (cierre)
                {
                    return Ruleta_Management.RuletaDB_To_Model(new AccesoDatos().consultaRuletaporID(idRuleta, cierre));
                }
                else
                {
                    return Ruleta_Management.RuletaDB_To_Model(new AccesoDatos().consultaRuletaporID(idRuleta));
                }

            }
            catch (Exception ex)
            {
                throw new Exception("BxCRI - " + ex.Message);
            }
        }
        public List<Ruleta_Model> consultaRuletas()
        {
            try
            {
                return Ruleta_Management.ListRuletasDB_To_Model(new AccesoDatos().consultaRuletas());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

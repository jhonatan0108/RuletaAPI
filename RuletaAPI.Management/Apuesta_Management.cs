using RuletaAPI.DataAccess;
using RuletaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.Management
{
    public class Apuesta_Management
    {
        public static Apuesta Model_To_ApuestaDB(Apuesta_Model datosApuesta)
        {
            try
            {
                Apuesta apuesta = new Apuesta()
                {
                    NumeroApuesta = datosApuesta.NumeroApuesta,
                    ColorApuesta = datosApuesta.ColorApuesta,
                    ValorApuesta = datosApuesta.ValorApuesta,
                    IdUsuarioApuesta = datosApuesta.IdUsuario,
                    IdRuleta = datosApuesta.IdRuleta,
                };
                return apuesta;
            }
            catch (Exception ex)
            {

                throw new Exception("MxMTA - " + ex.Message);
            }
        }
        public static Apuesta_Model ApuestaDB_To_Model(Apuesta datos)
        {
            try
            {
                Apuesta_Model apuesta = new Apuesta_Model()
                {
                    IdApuesta = datos.IdApuesta,
                    NumeroApuesta = datos.NumeroApuesta,
                    ColorApuesta = datos.ColorApuesta,
                    ValorApuesta = datos.ValorApuesta,
                    IdUsuario = datos.IdUsuarioApuesta,
                    IdRuleta = datos.IdRuleta,
                };
                return apuesta;
            }
            catch (Exception ex)
            {

                throw new Exception("MxATM - " + ex.Message);
            }
        }
        public static List<Apuesta_Model> ListApuestaDB_To_Model(List<Apuesta> listaApuestas)
        {
            try
            {
                List<Apuesta_Model> listApuesta = new List<Apuesta_Model>();
                foreach (var item in listaApuestas)
                {
                    Apuesta_Model apuesta = new Apuesta_Model()
                    {
                        IdApuesta = item.IdApuesta,
                        NumeroApuesta = item.NumeroApuesta,
                        ColorApuesta = item.ColorApuesta,
                        ValorApuesta = item.ValorApuesta,
                        IdUsuario = item.IdUsuarioApuesta,
                        IdRuleta = item.IdRuleta,
                    };
                    listApuesta.Add(apuesta);
                }

                return listApuesta;
            }
            catch (Exception ex)
            {

                throw new Exception("MxLATM - " + ex.Message);
            }
        }
    }
}

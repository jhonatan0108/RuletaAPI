using RuletaAPI.Model;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.DataAccess
{
    public class AccesoDatos
    {
        public Ruleta crearRuleta(Ruleta datosRuleta)
        {
            try
            {
                LasVegasEntities vegasEntities = new LasVegasEntities();
                vegasEntities.Ruleta.Add(datosRuleta);
                vegasEntities.SaveChanges();

                return datosRuleta;
            }
            catch (Exception ex)
            {
                throw new Exception("ADxCR - " + ex.Message);
            }

        }
        public List<Ruleta> consultaRuletas()
        {
            try
            {
                LasVegasEntities vegasEntities = new LasVegasEntities();
                return vegasEntities.Ruleta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ADxCR - "+ ex.Message);
            }
        }

        public Ruleta consultaRuletaporID(int idRuleta)
        {
            try
            {
                LasVegasEntities vegasEntities = new LasVegasEntities();

                Ruleta resultado = vegasEntities.Ruleta.AsNoTracking().Where(x => x.IdRuleta == idRuleta && x.Cierre == null).FirstOrDefault();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("ADxCRI - " + ex.Message);
            }
        }
        public Ruleta consultaRuletaporID(int idRuleta, bool cierre)
        {
            try
            {
                LasVegasEntities vegasEntities = new LasVegasEntities();

                Ruleta resultado = vegasEntities.Ruleta.AsNoTracking().Where(x => x.IdRuleta == idRuleta).FirstOrDefault();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("ADxCRI - " + ex.Message);
            }
        }
        public bool aperturayCierreRuleta(Ruleta datosRuleta)
        {
            try
            {

                LasVegasEntities vegasEntities = new LasVegasEntities();
                int respuesta = 0;
                vegasEntities.Ruleta.Add(datosRuleta);
                vegasEntities.Entry(datosRuleta).State = System.Data.Entity.EntityState.Modified;
                respuesta = vegasEntities.SaveChanges();

                if (respuesta > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("ADxAR - " + ex.Message);
            }
        }
        public Usuarios consultaUsuario(int IdUsuario)
        {
            try
            {
                LasVegasEntities vegasEntities = new LasVegasEntities();
                Usuarios resultado = vegasEntities.Usuarios.AsNoTracking().Where(x => x.IdUsuario == IdUsuario).FirstOrDefault();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("ADxCRI - " + ex.Message);
            }
        }
        public Apuesta generaApuesta(Apuesta datosApuesta)
        {
            try
            {
                LasVegasEntities vegasEntities = new LasVegasEntities();
                vegasEntities.Apuesta.Add(datosApuesta);
                vegasEntities.SaveChanges();

                return datosApuesta;
            }
            catch (SqlException ex)
            {
                throw new Exception("ADxGA - " + ex.Message);
            }
        }

        public List<Apuesta> ListaApuestarporIDRuleta(Ruleta ruleta)
        {
            try
            {
                LasVegasEntities vegasEntities = new LasVegasEntities();
                List<Apuesta> list = (from a in vegasEntities.Apuesta
                                      join r in vegasEntities.Ruleta
                                          on a.IdRuleta equals r.IdRuleta
                                      where a.IdRuleta == r.IdRuleta
                                                  && r.Estado == false
                                                  && r.Cierre != ""
                                      select a).ToList();

                return list;
            }
            catch (SqlException ex)
            {
                throw new Exception("ADxLAR - " + ex.Message);
            }
        }
    }
}

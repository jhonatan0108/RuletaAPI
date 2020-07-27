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
    public class Apuesta_Bussines
    {
        public bool Autenticado(string idUsuario, decimal ValorApuesta)
        {
            try
            {
                bool respuesta = false;
                Usuario_Model datoUsuario = Usuario_Management.UsuarioDB_To_Model(new AccesoDatos().consultaUsuario(int.Parse(idUsuario)));
                if (datoUsuario.NombreUsuario != null)
                {
                    #region Validacion de Limite de Credito
                    if (ValorApuesta < datoUsuario.LimiteCredito)
                    {
                        respuesta = true;
                    }
                    #endregion
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("BxAU - " + ex.Message);
            }
        }
        public bool validacionApuesta(Apuesta_Model datosApuesta)
        {
            try
            {
                #region Validacion de Datos para generar apuesta
                if ((!string.IsNullOrEmpty(datosApuesta.NumeroApuesta.ToString()) && datosApuesta.NumeroApuesta != 0)
                        && !string.IsNullOrWhiteSpace(datosApuesta.ColorApuesta.ToString()))
                {
                    throw new Exception("Debe Enviar unicamente un parametro {NumeroApuesta} ó {ColorApuesta} ");
                }
                if ((!string.IsNullOrEmpty(datosApuesta.NumeroApuesta.ToString()) && datosApuesta.NumeroApuesta != 0))
                {
                    if (!(datosApuesta.NumeroApuesta > 0 && datosApuesta.NumeroApuesta <= 36))
                    {
                        throw new Exception("El numero de la apuesta debe estar en el rango de 0 a 36, por favor verificar");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(datosApuesta.ColorApuesta.ToString()))
                {
                    if (!(datosApuesta.ColorApuesta.ToLower().Equals("rojo") || datosApuesta.ColorApuesta.ToLower().Equals("negro")))
                    {
                        throw new Exception("los colores permitidos para la apuesta son unicamente ROJO y NEGRO, por favor verificar");
                    }
                }
                if (!string.IsNullOrWhiteSpace(datosApuesta.IdRuleta.ToString()))
                {
                    var datosRuleta = new Ruleta_Bussines().consultaRuletaporID(datosApuesta.IdRuleta);
                    if (datosRuleta.IdRuleta > 0)
                    {
                        if (!datosRuleta.Estado)
                        {
                            throw new Exception("La ruleta ingresada no tiene apertura, por favor verificar");
                        }
                    }
                    else
                    {
                        throw new Exception("El id de la ruleta ingresado aun no se encuentra, por favor verificar");
                    }
                }
                if (!string.IsNullOrWhiteSpace(datosApuesta.ValorApuesta.ToString()))
                {

                    if (datosApuesta.ValorApuesta > 10000)
                    {
                        throw new Exception("El valor de la apuesta no puede superar un monto maximo de 10.000 USD, por favor verifique");
                    }
                }
                else
                {
                    throw new Exception("El parametro {ValorApuesta} debe estar informado, por favor verifique");
                }
                return true;
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("BxVAL  - " + ex.Message);
            }
        }
        public Apuesta_Model generaApuesta(Apuesta_Model datosApuesta)
        {
            try
            {
                return Apuesta_Management.ApuestaDB_To_Model(new AccesoDatos().generaApuesta(Apuesta_Management.Model_To_ApuestaDB(datosApuesta)));
            }
            catch (Exception ex)
            {
                throw new Exception("BxGRA - " + ex.Message);
            }
        }
        public List<Apuesta_Model> cierreApuesta(int idRuleta)
        {
            try
            {
                return Apuesta_Management.ListApuestaDB_To_Model(new AccesoDatos().ListaApuestarporIDRuleta(
                Ruleta_Management.Model_To_RuletaDB(new Ruleta_Bussines().consultaRuletaporID(idRuleta, true))));
            }
            catch (Exception ex)
            {

                throw new Exception("BxCA - " + ex.Message);
            }
        }
    }
}

using RuletaAPI.DataAccess;
using RuletaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaAPI.Management
{
    public class Usuario_Management
    {
        public static Usuario_Model UsuarioDB_To_Model(Usuarios usuario)
        {
            try
            {
                Usuario_Model datosUsuario = new Usuario_Model();
                if (usuario != null)
                {
                    datosUsuario = new Usuario_Model()
                    {
                        IdUsuario = usuario.IdUsuario,
                        NombreUsuario = usuario.NombreUsuario,
                        Contrasena = usuario.Contrasena,
                        LimiteCredito = usuario.LimiteCredito,
                    };
                }
                return datosUsuario;

            }
            catch (Exception ex)
            {
                throw new Exception("MxUTM - " + ex.Message);
            }
        }
        public static Usuarios Model_To_UsuarioDB(Usuario_Model usuario)
        {
            try
            {
                Usuarios datosUsuario = new Usuarios()
                {
                    IdUsuario = usuario.IdUsuario,
                    NombreUsuario = usuario.NombreUsuario,
                    Contrasena = usuario.Contrasena,
                    LimiteCredito = usuario.LimiteCredito,
                };
                return datosUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("MxMTU - " + ex.Message);
            }
        }
    }
}

using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Entidades_DAL;
using System.Linq;

namespace AccesoDatos
{
    public class AccesoDatosSQL : IAccesoSQL
    {

        #region  Metodos Usuarios


        #region Agregar Usuarios


        public bool AgregarUsuarios(Usuarios P_Entidad)
        {
            bool resultado = false;
            TutoriaContext contexto = null;

            try
            {
                contexto = new TutoriaContext();
                contexto.Usuarios.Add(P_Entidad);
                contexto.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }


        #endregion

        #region Modificar Usuarios

        public bool ModificarUsuarios(Usuarios P_Entidad)
        {
            bool resultado = false;
            TutoriaContext contexto = null;

            try
            {
                contexto = new TutoriaContext();
                var consulta = (from x in contexto.Usuarios
                                where x.Usuario.Equals(P_Entidad.Usuario)
                                select x).FirstOrDefault();

                if (consulta != null)
                {

                    consulta.Usuario = P_Entidad.Usuario;
                    consulta.UsuarioActivo = P_Entidad.UsuarioActivo;
                    consulta.RolesUsuarios = P_Entidad.RolesUsuarios;
                    consulta.Contrasena = P_Entidad.Contrasena;
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }


        #endregion

        #region Consultar Usuarios


        public List<Usuarios> ConsultarUsuarios(Usuarios P_Entidad)
        {
            TutoriaContext contexto = null;
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                contexto = new TutoriaContext();

                if (Convert.ToString(P_Entidad.Usuario).Length == 0)
                {
                    var consulta = (from x in contexto.Usuarios
                                    select x).ToList();

                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
                else
                {
                    var consulta = (from x in contexto.Usuarios
                                    where x.Usuario.Equals(P_Entidad.Usuario)
                                    select x).ToList();

                    if (consulta != null)
                    {
                        consulta.ForEach(x =>
                        {
                            lista.Add(x);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return lista;
        }



        #endregion

        #region Eliminar Usuarios
        public bool EliminarUsuarios(Usuarios P_Entidad)
        {
            bool resultado = false;
            TutoriaContext contexto = null;

            try
            {
                contexto = new TutoriaContext();
                var consulta = (from x in contexto.Usuarios
                                where x.Usuario.Equals(P_Entidad.Usuario)
                                select x).FirstOrDefault();

                if (consulta != null)
                {
                    contexto.Usuarios.Remove(consulta);
                    contexto.SaveChanges();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contexto != null)
                    contexto.Dispose();
            }

            return resultado;
        }
        #endregion


        #endregion

    }
}

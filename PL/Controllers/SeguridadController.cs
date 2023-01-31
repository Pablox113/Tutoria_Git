using AccesoDatos.Models;
using AccesoDatos;
using Entidades_DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace PL.Controllers
{
    public class SeguridadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly TutoriaContext _hotel;

        public SeguridadController()
        {
            _hotel = new TutoriaContext();
        }


        public IActionResult AccesoDenegado()
        {
            return View();
        }

        public IActionResult ErrorAcceso()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Autenticacion(Usuarios _usuario)
        {
            IAccesoMongo bitacora = new AccesoDatosMongo();
            #region Autenticación con código cableado
            /*
            _usuario.Estado = true;
            Models.Usuarios objUsuario = _usuario.ValidarUsuario();
            if (objUsuario != null)
            {
            var claims = new List<Claim>()
            {
            new Claim(ClaimTypes.Name, objUsuario.Usuario),
            new Claim("Usuario", objUsuario.Usuario)
            };

            foreach (Perfil item in objUsuario.Perfiles)
            claims.Add(new Claim(ClaimTypes.Role, item.Codigo.ToString()));

            var claimidentidad = new ClaimsIdentity(claims ,CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimidentidad));

            return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
            // */
            #endregion

            #region Autenticación a la base de datos
            // /*
            var usuario = await _hotel.Usuarios
                .FirstOrDefaultAsync(x => x.Usuario == _usuario.Usuario);

            if (usuario == null)
                return RedirectToAction("ErrorAcceso");

            if (!(usuario.Contrasena == _usuario.Contrasena))
                return RedirectToAction("ErrorAcceso");

            if (!usuario.UsuarioActivo)
                return RedirectToAction("ErrorAcceso");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Usuario),
                new Claim("Usuario", usuario.Usuario)
            };

            List<RolesUsuarios> rolesUsuario = await _hotel.RolesUsuarios.ToListAsync();

            foreach (RolesUsuarios rolUsuario in rolesUsuario)
            {
                if (rolUsuario.Usuario == usuario.Usuario)
                {
                    var rol = await _hotel.Roles
                        .FirstOrDefaultAsync(x => x.IdRol == rolUsuario.IdRol);

                    if (rol != null)
                        claims.Add(new Claim(ClaimTypes.Role, rol.Descripcion));
                }
            }

            var claimID = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimID));
            /*  bitacora.AgregarRegistroBitacora(new Accion()
              {
                  AccionRealizada = "AbrirSesion",
                  Objeto = "WebApplicationSession",
                  Instancia = this.Url.ToString(),
                  Usuario = HttpContext.User.Claims.First().Value,
                  Resultado = "SessionAbierta",
                  Momento = DateTime.Now

              });*/
            return RedirectToAction("Index", "Home");

            #endregion
        }


        [HttpGet]
        public async Task<IActionResult> CerrarSesion()
        {
            IAccesoMongo bitacora = new AccesoDatosMongo();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            bitacora.AgregarRegistroBitacora(new Accion()
            {
                AccionRealizada = "CerrarSesion",
                Objeto = "WebApplicationSession",
                Instancia = this.Url.ToString(),
                Usuario = HttpContext.User.Claims.First().Value,
                Resultado = "SessionCerrada",
                Momento = DateTime.Now

            });

            return RedirectToAction("Index", "Seguridad");

        }
    }
}


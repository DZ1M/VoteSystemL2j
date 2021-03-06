﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using VoteSystemL2j.Helpers;
using VoteSystemL2j.Models;
using VoteSystemL2j.Services;

namespace VoteSystemL2j.Controllers
{
    public class HomeController : Controller
    {
        private IHttpContextAccessor _accessor;
        public HomeController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        [HttpGet]
        public ActionResult Login()
        {
            // Verifica se usuario ja esta logado, se estiver manda direto pro Vote
            if (!String.IsNullOrEmpty(User.Identity.GetUserId()))
                return RedirectToAction("Index", "Vote");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Accounts usuario)
        {
            if (usuario == default(Accounts))
            {
                TempData["Error"] = "Informe os campos corretamente!";
                return View();
            }

            if (String.IsNullOrWhiteSpace(usuario.Login) || String.IsNullOrWhiteSpace(usuario.Password))
            {
                TempData["Error"] = "Informe os campos corretamente!";
                return View();
            }

            var obj = new ConsultaService().BuscaPorLoginSenha(usuario.Login, usuario.Password.CryptografaSenha());
            if (obj == default(Accounts))
            {
                TempData["Error"] = "Login ou senha invalidos!";
                return View();
            }
            // Mais uma validacao, apenas para confirmar
            if (!String.IsNullOrEmpty(obj.Login) && !String.IsNullOrEmpty(obj.Password))
            {
                string ipUsuario = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                System.IO.File.AppendAllText("logVoteSystem.txt", "Login: " + obj.Login + " ip: " + ipUsuario + " -> Logou no vote system\n");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, obj.Login),
                    new Claim("IpUsuario", ipUsuario),
                    new Claim(ClaimTypes.NameIdentifier, obj.Login.ToString()),
                    new Claim(ClaimTypes.Role, "Usuario"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20), // Expira em 20 minutos
                    IsPersistent = false,
                    AllowRefresh = false
                };

                // Gera o Cookie de authenticacao
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Vote");
            }

            return View();
        }

        public IActionResult Sair()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Contexts;
using Bibliotec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bibliotec_mvc.Controllers
{
    [Route("[controller]")]
    public class LivroController : Controller
    {
        private readonly ILogger<LivroController> _logger;

        public LivroController(ILogger<LivroController> logger)
        {
            _logger = logger;
        }

            Context context = new Context();
        public IActionResult Index()
        {
            ViewBag.Admin =  HttpContext.Session.GetString("Admin")!;
            
            //Criar uma lista de livros
            List<Livro>listralivros = context.Livro.ToList();

            //Verificar se o livro tem reserva ou nao
            var livroReservados = context.LivroReserva.ToDictionary(livro => livro.LivroID, livror => livror.DtReserva
            livroReservados => livror.DtReservados );
            
            ViewBag.Livros = listralivros;
            ViewBag.LivrosComReserva = livroReservados;
            
            
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}
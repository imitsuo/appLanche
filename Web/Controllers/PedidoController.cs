using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using appLanche.Web.Models;
using appLanche.Domain;
using appLanche.Services;

namespace appLanche.Web.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoService pedidoService;
        public PedidoController(IPedidoService service)
        {
            this.pedidoService = service;
        }
        public IActionResult Index()
        {
            return View();
        }


        public List<Ingrediente> ListarIngredientes()
        {
            return this.pedidoService.ListarIngredientes();
        }

        public List<Lanche> ListarLanches()
        {
            return pedidoService.ListarLanches();
        }

    }
}

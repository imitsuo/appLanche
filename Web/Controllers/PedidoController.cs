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
            var model = new PedidoModel();
            model.Lanches = pedidoService.ListarLanches();

            return View(model);
            //return View(ListarLanches());
        }

        public IActionResult MontarPedido(int? id)
        {
            var model = new PedidoModel();
            var lanches = pedidoService.ListarLanches();
            model.Lanches = lanches;

            var lanche = lanches.First(x => x.Id == id);
            model.Item = new ItemDoPedido(lanche);

            return View("MontarPedido", model);
        }

        public List<Ingrediente> ListarIngredientes()
        {
            return this.pedidoService.ListarIngredientes();
        }

        public List<Lanche> ListarLanches()
        {
            var model = new List<LancheModel>();
            var lanches = pedidoService.ListarLanches();

            //lanches.ForEach(l => model.Add( new LancheModel{Id = l.ID, Nome = l.Nome}));
            //return model;

            return pedidoService.ListarLanches();            
        }

        [HttpPost]
        public MontarPedidoModel CalcularPreco(MontarPedidoModel model)
        {

            return model;
        }

    }
}

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
            return pedidoService.ListarLanches();            
        }

        [HttpPost]
        public ItemDoPedido CalcularPreco(MontarPedidoModel model)
        {
            var lanche = pedidoService.ObterLanche(model.LancheId).FirstOrDefault();
            
            if(lanche == null)
                throw new Exception("Lanche nao encontrado");

            var item = new ItemDoPedido(lanche);

            var ingredientes = this.pedidoService.ListarIngredientes();

            model.IngredientesAdicionais.ForEach(a => 
                {
                    item.AdicionarIngrediente(
                        ingredientes.First(x => x.Id == int.Parse(a))
                        );
                }
            );
            
            model.IngredientesRemovidos.ForEach(a => 
                {
                    item.RemoverIngrediente(
                        ingredientes.First(x => x.Id == int.Parse(a))
                        );
                }
            );


            return pedidoService.CalcularValorDoPedido(item);
        }

        [HttpPost]
        public ItemDoPedido GerarPedido(ItemDoPedido item)
        {
            return pedidoService.GerarPedido(item);
        }

    }
}

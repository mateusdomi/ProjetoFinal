using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Infra;
using ProjetoFinal.Models.Avaliacoes;

namespace ProjetoFinal.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly AvaliacaoService _avaliacaoService;

        public AvaliacaoController(AvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        public async Task<IActionResult> Index()
        {
            var avaliacoes = await _avaliacaoService.ListarTodasAvaliacoes();
            return View(avaliacoes);
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var avaliacao = await _avaliacaoService.BuscarAvaliacao(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

       /* public async Task<IActionResult> Criar()
        {
            ViewBag.Materias = await _avaliacaoService.ListarTodasAvaliacoes();
            return View();
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                await _avaliacaoService.InserirAvaliacao(avaliacao);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Materias = await _avaliacaoService.ListarTodasAvaliacoes();
            return View(avaliacao);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var avaliacao = await _avaliacaoService.BuscarAvaliacao(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            ViewBag.Materias = await _avaliacaoService.ListarTodasAvaliacoes();
            return View(avaliacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.AvaliacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _avaliacaoService.AtualizarAvalicao(avaliacao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AvaliacaoExists(avaliacao.AvaliacaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Materias = await _avaliacaoService.ListarTodasAvaliacoes();
            return View(avaliacao);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var avaliacao = await _avaliacaoService.BuscarAvaliacao(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            await _avaliacaoService.ExcluirAvaliacao(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AvaliacaoExists(int id)
        {
            var avaliacao = await _avaliacaoService.BuscarAvaliacao(id);
            return avaliacao != null;
        }
    }

}

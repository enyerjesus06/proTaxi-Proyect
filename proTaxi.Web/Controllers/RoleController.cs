using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Interfaces;
using proTaxi.Persistence.Models.Role;

namespace proTaxi.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        // GET: RoleController
        public async Task<IActionResult> Index()
        {
            // Obtener el resultado directamente sin inicialización innecesaria
            DataResult<List<RoleModel>> result = await this.roleRepository.GetRoles();

            // Pasar la lista de roles (Data) a la vista, no result.Result
            return View(result);
        }

        // GET: RoleController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            DataResult<RoleModel> result = await this.roleRepository.GetRole(id);
            return View(result.Result);
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}

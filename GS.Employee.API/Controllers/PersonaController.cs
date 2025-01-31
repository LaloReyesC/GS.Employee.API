namespace GS.Employee.API.Controllers
{
    public class PersonaController(IPersonaDataAccess personaDataAccess) : Controller
    {
        private readonly IPersonaDataAccess _personaDataAccess = personaDataAccess;

        public ActionResult Index()
        {
            List<Persona> personas = _personaDataAccess.ObtenerPersonas();
            return View(personas);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear([FromBody] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona.Estatus = true;
                
                _personaDataAccess.InsertarPersona(persona);

                return Json(new { Message = "Se ha registrado correctamnente la información de la persona", Success = true });
            }

            return Json(new { Message = "Verifica la información de la persona", Success = false });
        }

        public ActionResult Editar(int id)
        {
            var personas = _personaDataAccess.ObtenerPersonas();
            var persona = personas.Find(p => p.Id == id);

            if (persona is null || persona.Eliminado) 
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View(persona);
        }

        [HttpPost]
        public ActionResult Editar([FromBody] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _personaDataAccess.ActualizarPersona(persona);

                return Json(new { Message = "Se ha actualizado correctamnente la información de la persona", Success = true });
            }

            return Json(new { Message = "Verifica la información de la persona", Success = false });
        }

        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            try
            {
                _personaDataAccess.EliminarPersona(id);

                return Json(new { Message = "Se ha eliminado el registro", Success = true });
            }
            catch
            {
                return Json(new { Message = "Ocurrio un error al eliminar el registro", Success = false });
            }
        }
    }
}
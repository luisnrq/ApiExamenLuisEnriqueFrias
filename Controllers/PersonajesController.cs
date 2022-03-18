using ApiExamenLuisEnriqueFrias.Models;
using ApiExamenLuisEnriqueFrias.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenLuisEnriqueFrias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repo;

        public PersonajesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajes()
        {
            return this.repo.GetPersonajes();
        }

        [HttpPost]
        public ActionResult InsertarPersonaje(Personaje personaje)
        {
            this.repo.InsertarPersonaje(personaje.NombrePersonaje, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdatePersonaje(Personaje personaje)
        {
            this.repo.UpdatePersonaje(personaje.IdPersonaje, personaje.NombrePersonaje, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Personaje> GetPersonaje(int id)
        {
            return this.repo.FindPersonaje(id);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePersonaje(int id)
        {
            this.repo.DeletePersonaje(id);
            return Ok();
        }

        [HttpPut("{idpersonaje}/{idserie}")]
        public ActionResult UpdatePersonajeSerie(int idpersonaje, int idserie)
        {
            this.repo.PersonajesSeries(idpersonaje, idserie);
            return Ok();
        }

    }
}

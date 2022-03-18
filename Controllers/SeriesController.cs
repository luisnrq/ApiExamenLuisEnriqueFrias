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
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;

        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            return this.repo.GetSeries();
        }

        [HttpPost]
        public ActionResult InsertarSerie(Serie serie)
        {
            this.repo.InsertarSerie(serie.IdSerie, serie.NombreSerie, serie.Imagen, serie.Puntuacion, serie.Anio);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateSerie(Serie serie)
        {
            this.repo.UpdateSerie(serie.IdSerie, serie.NombreSerie, serie.Imagen, serie.Puntuacion, serie.Anio);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Serie> GetSerie(int id)
        {
            return this.repo.FindSerie(id);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSerie(int id)
        {
            this.repo.DeleteSerie(id);
            return Ok();
        }

        [HttpGet]
        [Route("[action]/{idserie}")]
        public ActionResult<List<Personaje>> PersonajesSerie(int idserie)
        {
            return this.repo.PersonajesSerie(idserie);
        }

    }
}

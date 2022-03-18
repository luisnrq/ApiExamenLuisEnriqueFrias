using ApiExamenLuisEnriqueFrias.Data;
using ApiExamenLuisEnriqueFrias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenLuisEnriqueFrias.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        #region Personajes
        public List<Personaje> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }

        private int GetMaxIdPersonaje()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
            }
        }


        public void InsertarPersonaje(string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonaje();
            personaje.NombrePersonaje = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();
        }

        public Personaje FindPersonaje(int idpersonaje)
        {
            return this.context.Personajes.FirstOrDefault(x => x.IdPersonaje == idpersonaje);
        }

        public void UpdatePersonaje(int idpersonaje, string nombre, string imagen, int idserie)
        {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            personaje.NombrePersonaje = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.SaveChanges();
        }

        public void DeletePersonaje(int idpersonaje) 
        {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            this.context.Personajes.Remove(personaje);
            this.context.SaveChanges();
        }

        public void PersonajesSeries(int idpersonaje, int idserie)
        {
            Personaje personaje = FindPersonaje(idpersonaje);
            personaje.IdSerie = idserie;
            this.context.SaveChanges();
        }

        #endregion

        #region Series

        public List<Serie> GetSeries()
        {
            return this.context.Series.ToList();
        }

        private int GetMaxIdSerie()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Series.Max(z => z.IdSerie) + 1;
            }
        }

        public void InsertarSerie(int idserie, string nombre, string imagen, double puntuacion, int anio)
        {
            Serie serie = new Serie();
            serie.IdSerie = this.GetMaxIdSerie();
            serie.NombreSerie = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Anio = anio;
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }

        public Serie FindSerie(int idserie)
        {
            return this.context.Series.FirstOrDefault(x => x.IdSerie == idserie);
        }

        public void UpdateSerie(int idserie, string nombre, string imagen, double puntuacion, int anio)
        {
            Serie serie = this.FindSerie(idserie);
            serie.NombreSerie = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Anio = anio;
            this.context.SaveChanges();
        }

        public void DeleteSerie(int idserie)
        {
            Serie serie = this.FindSerie(idserie);
            this.context.Series.Remove(serie);
            this.context.SaveChanges();
        }

        public List<Personaje> PersonajesSerie(int idserie)
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == idserie
                           select datos;
            return consulta.ToList();
        }



        #endregion
    }
}

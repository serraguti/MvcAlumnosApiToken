using Microsoft.Azure.Cosmos.Table;
using MvcAlumnosApiToken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAlumnosApiToken.Services
{
    public class ServiceTableAlumnos
    {
        private string UrlTableAlumnos;

        public ServiceTableAlumnos(string urltablealumnos)
        {
            this.UrlTableAlumnos = urltablealumnos;
        }

        public async Task<List<Alumno>> GetAlumnosAsync(string token)
        {
            //PARA CONECTARNOS DE ESTA FORMA NECESITAMOS 
            //CREDENCIALES CON EL TOKEN
            StorageCredentials credentials =
                new StorageCredentials(token);
            //NECESITAMOS UN TABLE CLIENT QUE RECIBIRA LA URL 
            //DE ACCESO LA TABLA Y TAMBIEN RECIBIRA LAS CREDENCIALES
            CloudTableClient tableClient =
                new CloudTableClient(new Uri(this.UrlTableAlumnos), credentials);
            CloudTable tablaAlumnos = tableClient.GetTableReference("alumnos");
            TableQuery<Alumno> query = new TableQuery<Alumno>();
            var results =
            await tablaAlumnos.ExecuteQuerySegmentedAsync<Alumno>(query, null);
            return results.ToList();
        }
    }
}

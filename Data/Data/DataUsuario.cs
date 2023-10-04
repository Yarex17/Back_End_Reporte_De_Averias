using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Data.Context;

namespace Data.Data
{
    public class DataUsuario
    {
        public async Task<List<Usuario>> listarUsuario()
        {
            return null;
        }

        public async Task<String> registarUsuario(Usuario usuario)
        {
            using (var dbContext = new DBContext()) {


            }
            return null;
        }

        public async Task<List<Usuario>> buscarUsuario(string nombre)
        {
            return null;
        }

        public async Task<String> modificarEdificio(Usuario usuario)
        {

            return null;

        }

        public async Task<String> eliminarEdificio(Usuario usuario)
        {
            return null;
        }
    }
}

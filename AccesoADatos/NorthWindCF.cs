using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Instalar el EF desde NuGet y luego hacer referencia a la libreria System.Data.Entity
using System.Data.Entity;
//Se referencia el proyecto Entidades donde contiene las clases de las tablas.
using Entidades;

namespace AccesoADatos
{
    //La Clase debe heredar de DbContext
    public class NorthWindCF:DbContext
    {   
        //Se definen las tablas del modelo
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}

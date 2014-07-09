using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; 
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        //Por convención, el ID, id o CategoriaId o CategoriaID el EF lo reconoce como llave primaria.
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Se establece la propiedad de navegación: está se debe indicar para navegar por su tabla relacionada Producto
        public virtual ICollection<Producto> Productos { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        //En este caso el Id del producto será IdProducto donde el EF lo dejará como PK.
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int UnidadesEnExistencia { get; set; }
        public string Comentarios { get; set; }

        //Se establece la llave FK para índicar la categoría del producto donde puede ser una de estas tres opciones:
        //public int CategoriaAsignadaId { get; set; }
        public int CategoriaId { get; set; }
        //public int id { get; set; }

        ///Se establece la propiedad de navegación
        public virtual Categoria CategoriaAsignada {get;set;}
    }
}

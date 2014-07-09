using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se referencias los proyectos y la clase System.Data
using AccesoADatos;
using Entidades;
using System.Data;

namespace PruebaCF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se crea contexto para poder interactuar con nuestra base de datos
            NorthWindCF contexto = new NorthWindCF();

            Categoria Bebidas = new Categoria
            {
                Nombre = "Bebidas embotelladas"
            };

            contexto.Categorias.Add(Bebidas);
            Categoria Lacteos = new Categoria
            {
                Nombre = "Lacteos y derivados"
            };
            contexto.Categorias.Add(Lacteos);
            //Devuelve las cantidades de grabaciones en la BD.
            int Actualizaciones = contexto.SaveChanges();

            Console.WriteLine("Actualizaciones: {0}", Actualizaciones);
            Console.WriteLine("Agregadas categoria: {0}, {1}", Bebidas.Id, Lacteos.Id);

            Categoria Vegetales = new Categoria
            {
                Nombre = "Vegetales"
            };

            contexto.Categorias.Add(Vegetales);
            contexto.SaveChanges();

            Producto Naranjada = new Producto
            {
                Nombre = "Naranjada Natural",
                Precio = 10,
                UnidadesEnExistencia = 100,
                //Se hace referencia a la propieda de navegación cuando se entrega la instancia de bebidas
                CategoriaAsignada = Bebidas

            };
            contexto.Productos.Add(Naranjada);
            contexto.SaveChanges();

            Console.WriteLine("Id del nuevo producto: {0}", Naranjada.ProductoId);
            Producto Queso = new Producto
            {
                Nombre = "Queso",
                Precio = 40,
                UnidadesEnExistencia = 30,
                //Se hace referencia a la propiedad de la tabla si se le entrega el valor directo
                CategoriaId = Lacteos.Id
            };
            contexto.Productos.Add(Queso);
            contexto.SaveChanges();
            Console.WriteLine("Id del nuevo producto: {0}", Queso.ProductoId);

            Producto Lechuga = new Producto
            {
                Nombre = "Lechuga",
                Precio = 10,
                UnidadesEnExistencia = 140,
                CategoriaId = Vegetales.Id
            };
            contexto.Productos.Add(Lechuga);
            contexto.SaveChanges();
            Console.WriteLine("Id del nuevo producto: {0}", Lechuga.ProductoId);

            //Busqueda en base a un valor: en esta caso busca la categoria con valor 1 y
            //devuelve la referencia de la categoria encontrada
            Categoria Encontrada = contexto.Categorias.Find(1);
            Console.WriteLine("Categoria encontrada:  {0}, {1}", Encontrada.Id, Encontrada.Nombre);
            //cambios realizados al contexto
            foreach (Categoria c in contexto.Categorias)
            {
                Console.WriteLine("{0}, {1}", c.Id, c.Nombre);
                foreach (Producto p in c.Productos)
                {
                    Console.WriteLine("\t{0}, {1}", p.ProductoId, p.Nombre);
                }
            }

            //Cambia el nombre de la categoria encontrada en el contexto
            Encontrada.Nombre = "Bebidas embotelladas exclusivas";
            contexto.SaveChanges();
            //Elimina en cascada. elimina las categorias vegetales y los productos asociados.
            contexto.Categorias.Remove(Vegetales);
            contexto.SaveChanges();

            foreach (Categoria c in contexto.Categorias)
            {
                Console.WriteLine("No debe aparecer Vegetales");
                Console.WriteLine("{0}, {1}", c.Id, c.Nombre);
                foreach (Producto p in c.Productos)
                {
                    Console.WriteLine("\t{0}, {1}", p.ProductoId, p.Nombre);
                }
            }

            Console.WriteLine("presiones enter para continuar");
            Console.ReadLine();
        }
    }   
}

using System.Collections.Generic;

namespace PracticaN3.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string NombreCategoria { get; set; }
        public ICollection<Producto> Producto { get; set; }
    }
}
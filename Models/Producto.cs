namespace PracticaN3.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string NombreProducto { get; set; }
        public string Foto { get; set; }
        public string Descripcion  { get; set; }
        public decimal Precio {get ; set;}
        public string Celular {get;set;}
        public string LugarCompra{get;set;}
        public string NombreComprador { get; set; }
        public Categoria categoria {get;set;}
        public int CategoriaId {get;set;}


    }
}
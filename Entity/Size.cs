namespace EF_Mappings.Entity
{
    public class Size
    {
        public int Id { get; set; } 

        public string SizeName { get; set; }

         public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}

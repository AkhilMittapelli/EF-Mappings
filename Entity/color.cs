namespace EF_Mappings.Entity
{
    public class color
    {
        public int Id { get; set; }

        public string colorName { get; set; }

        public List<Product> Products { get; set; }
    }
}

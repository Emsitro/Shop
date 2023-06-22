namespace shop.models
{
    public class product
    {
            public int Id { get; set; }     
            public string Name { get; set; } = string.Empty; 
            public int Price { get; set; }  = 0;                    
            public string ProductCategory { get; set; } = string.Empty;
    }
}

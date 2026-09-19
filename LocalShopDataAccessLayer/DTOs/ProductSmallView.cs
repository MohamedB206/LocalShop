using LocalShopDataAccessLayer.Models;

namespace LocalShopDataAccessLayer.DTOs
{
    public class ProductSmallView
    {

        public string Name { get; set; } = null!;

        public int Price { get; set; }
        public virtual ICollection<ProductsImage> ProductsImages { get; set; } = new List<ProductsImage>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}

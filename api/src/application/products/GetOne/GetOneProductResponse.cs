using Domain;

namespace Application.Products.GetOne
{
    public class GetOneProductResponse
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static GetOneProductResponse FromProduct(Product product)
        {
            return new GetOneProductResponse
            {
                Identifier = product.Identifier,
                Title = product.Title,
                Description = product.Description,
            };
        }
    }
}

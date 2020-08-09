using Microsoft.Extensions.DependencyInjection;

namespace Application.Products
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
        }
    }
}

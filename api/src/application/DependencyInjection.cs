using Application.Lessons;
using Application.Modules;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Products
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<ILessonService, LessonService>();

            var storageConnectionString = configuration.GetConnectionString("Storage");
            var blobContainer = new BlobContainerClient(storageConnectionString, "uberflieger");
            services.AddSingleton(blobContainer);
        }

    }
}

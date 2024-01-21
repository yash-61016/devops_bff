using devops_bff.DTOs.Product;
using devops_bff.Models;
using devops_bff.Services.IServices;

namespace devops_bff.Services
{
    public class ProductFakeService : IProductService
    {
        public static readonly ProductCategoryDTO[] MockCategories = new ProductCategoryDTO[]
        {
            new ProductCategoryDTO { Id = 1, Name = "Watch", PreferenceIndex = 1 },
            new ProductCategoryDTO { Id = 2, Name = "Mac", PreferenceIndex = 2 },
            new ProductCategoryDTO { Id = 3, Name = "iPhone", PreferenceIndex = 3 },
            new ProductCategoryDTO { Id = 4, Name = "iPad", PreferenceIndex = 4 },
            new ProductCategoryDTO { Id = 5, Name = "AirPods", PreferenceIndex = 5 },
            new ProductCategoryDTO { Id = 6, Name = "Vision", PreferenceIndex = 6 }
        };
        public static ImageDTO NewFeatureImage = new ImageDTO
        {
            ImageUrl = "smartwatches/featuredProduct/newFeature.png",
            AltText = null
        };

        public static ImageDTO[] BannerImages = new ImageDTO[]
        {
            new ImageDTO
            {
                ImageUrl = "smartwatches/featuredProduct/banner1.png",
                AltText = null
            },
            new ImageDTO
            {
                ImageUrl = "smartwatches/featuredProduct/banner2.png",
                AltText = null
            },
            new ImageDTO
            {
                ImageUrl = "smartwatches/featuredProduct/banner3.png",
                AltText = null
            }
        };

        public static ImageDTO[] FeaturedImages = new ImageDTO[]
        {
            new ImageDTO
            {
                ImageUrl = "smartwatches/featuredProduct/featured1.png",
                AltText = null
            },
            new ImageDTO
            {
                ImageUrl = "smartwatches/featuredProduct/featured2.png",
                AltText = null
            },
            new ImageDTO
            {
                ImageUrl = "smartwatches/featuredProduct/featured3.png",
                AltText = null
            }
        };

        public static PropertyDTO[] Properties = new PropertyDTO[]
        {
            new PropertyDTO
            {
                Key = "size",
                Type = "Size",
                Value = "44mm case size"
            },
            new PropertyDTO
            {
                Key = "display",
                Type = "Display",
                Value = "Always-On Retina"
            },
            new PropertyDTO
            {
                Key = "processor",
                Type = "Processor",
                Value = "S9 SiP"
            }
        };

        public static ProductTemplateDTO[] ProductTemplates = new ProductTemplateDTO[]
        {
            new ProductTemplateDTO
            {
                Id = 1201,
                Brand = "Apple",
                Name = "Watch Ultra",
                Description = "A magical new way to use your watch without touching the screen. The brightest Apple display ever. And now you can choose a case and strap combination that is carbon neutral.",
                DefaultImages = new ImageDTO[]
                {
                    new ImageDTO
                    {
                        ImageUrl = "smartwatches/appleWatchUltra/awu_d_1.png",
                        AltText = null
                    },
                    new ImageDTO
                    {
                        ImageUrl = "smartwatches/appleWatchUltra/awu_d_2.png",
                        AltText = null
                    },
                    new ImageDTO
                    {
                        ImageUrl = "smartwatches/appleWatchUltra/awu_d_3.png",
                        AltText = null
                    }
                },
                ProductCategoryId = 1,
                Products = new ProductDTO[]
                {
                    new ProductDTO
                    {
                        Id = 1301,
                        Name = "Apple Watch Ultra 44mm",
                        Price = 799.00,
                        DiscountedPrice = null,
                        Images = new ImageDTO { ImageUrl = "smartwatches/appleWatchUltra/awu_d_2.png", AltText = "Product A Image" },
                        Properties = new PropertyDTO[] { new PropertyDTO { Key = "Color", Type = "String", Value = "Blue" } },
                        ProductTemplateId = 1201,
                        Tags = new string[] { "New" },
                        Color = "#4d4249"
                    },
                    new ProductDTO
                    {
                        Id = 1302,
                        Name = "Apple Watch Ultra 44mm",
                        Price = 799.00,
                        DiscountedPrice = null,
                        Images = new ImageDTO { ImageUrl = "smartwatches/appleWatchUltra/awu_d_2.png", AltText = "Product A Image" },
                        Properties = new PropertyDTO[] { new PropertyDTO { Key = "Color", Type = "String", Value = "Blue" } },
                        ProductTemplateId = 1201,
                        Tags = new string[] { "New" },
                        Color = "#f6754a"
                    }
                },
                Badges = new string[] { "new" },
                DisplayPrice = 799,
                DisplayDiscountedPrice = null
            },
            new ProductTemplateDTO
            {
                Id = 1202,
                Brand = "Google",
                Name = "Pixel Watch",
                Description = "A magical new way to use your watch without touching the screen. The brightest Apple display ever. And now you can choose a case and strap combination that is carbon neutral.",
                DefaultImages = new ImageDTO[]
                {
                    new ImageDTO { ImageUrl = "smartwatches/googlePixelWatch/gpw_d_1.png", AltText = null },
                    new ImageDTO { ImageUrl = "smartwatches/googlePixelWatch/gpw_d_2.png", AltText = null },
                    new ImageDTO { ImageUrl = "smartwatches/googlePixelWatch/gpw_d_3.png", AltText = null }
                },
                ProductCategoryId = 1,
                Products = new ProductDTO[]
                {
                    new ProductDTO
                    {
                        Id = 1303,
                        Name = "Google Pixel Watch 44mm",
                        Price = 349.00,
                        DiscountedPrice = 300.00,
                        Images = new ImageDTO { ImageUrl = "smartwatches/googlePixelWatch/gpw_d_2.png", AltText = "Product A Image" },
                        Properties = new PropertyDTO[] { new PropertyDTO { Key = "Color", Type = "String", Value = "Blue" } },
                        ProductTemplateId = 1201,
                        Tags = new string[] { "New" },
                        Color = "#68746f"
                    },
                    new ProductDTO
                    {
                        Id = 1304,
                        Name = "Google Pixel Watch 44mm",
                        Price = 349.00,
                        DiscountedPrice = 300.00,
                        Images = new ImageDTO { ImageUrl = "smartwatches/googlePixelWatch/gpw_d_2.png", AltText = "Product A Image" },
                        Properties = new PropertyDTO[] { new PropertyDTO { Key = "Color", Type = "String", Value = "Blue" } },
                        ProductTemplateId = 1201,
                        Tags = new string[] { "New" },
                        Color = "#1e1e1e"
                    },
                    new ProductDTO
                    {
                        Id = 1305,
                        Name = "Google Pixel Watch 44mm",
                        Price = 349.00,
                        DiscountedPrice = 300.00,
                        Images = new ImageDTO { ImageUrl = "smartwatches/googlePixelWatch/gpw_d_2.png", AltText = "Product A Image" },
                        Properties = new PropertyDTO[] { new PropertyDTO { Key = "Color", Type = "String", Value = "Blue" } },
                        ProductTemplateId = 1201,
                        Tags = new string[] { "New" },
                        Color = "#95bbea"
                    }
                },
                Badges = new string[] { "refurbished" },
                DisplayPrice = 349,
                DisplayDiscountedPrice = 300
            }
        };

        public static FeaturedProductTemplateDTO FeaturedProduct = new FeaturedProductTemplateDTO
        {
            Id = 2,
            Name = "Apple Watch Ultra",
            BriefDescription = "The most rugged and capable Apple Watch pushes the limits again. Featuring the all-new S9 SiP.",
            StartingPrice = 799.00,
            Title = "Next-level adventure.",
            Description = "A magical new way to use your watch without touching the screen. The brightest Apple display ever. And now you can choose a case and strap combination that is carbon neutral.",
            NewFeatureImage = NewFeatureImage,
            NewFeatureDescription = " The lightweight titanium case is rugged and corrosion resistant.",
            NewFeatureImage2 = NewFeatureImage,
            NewFeatureDescription2 = " The customizable Action button gives you quick functions. ",
            BannerImages = BannerImages,
            BannerTitle = "New Guts. More Glory.",
            FeaturedImages = FeaturedImages,
            ProductCategoryId = 1,
            Products = new ProductDTO[] { },
            Properties = Properties
        };

        public static Dictionary<int, FeaturedProductTemplateDTO> FeaturedProducts = new Dictionary<int, FeaturedProductTemplateDTO>
        {
            { 1, FeaturedProduct },
        };

        public static Dictionary<int, ProductTemplateDTO[]> ProductTemplatesByCategory = new Dictionary<int, ProductTemplateDTO[]>
        {
            { 1, ProductTemplates },
        };

        public Task<APIResponse> GetProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetProductCategoriesAsync()
        {
            var apiResponse = new APIResponse();
            apiResponse.Result = MockCategories;
            apiResponse.IsSuccess = true;
            return Task.FromResult(apiResponse);
        }

        public Task<APIResponse> GetProductsAsync(int categoryId)
        {
            var apiResponse = new APIResponse();

            ProductTemplateDTO[] ProductTemplates = null;
            if (ProductTemplatesByCategory.ContainsKey(categoryId))
            {
                ProductTemplates = ProductTemplatesByCategory[categoryId];
            }

            var result = ProductTemplates;
            apiResponse.Result = result;
            apiResponse.IsSuccess = true;
            return Task.FromResult(apiResponse);
        }

        public Task<APIResponse> GetFeaturedProductAsync(int categoryId)
        {
            var apiResponse = new APIResponse();

            FeaturedProductTemplateDTO featuredProduct = null;
            if (FeaturedProducts.ContainsKey(categoryId))
            {
                featuredProduct = FeaturedProducts[categoryId];
            }

            var result = featuredProduct;
            apiResponse.Result = result;
            apiResponse.IsSuccess = true;
            return Task.FromResult(apiResponse);
        }
    }
}
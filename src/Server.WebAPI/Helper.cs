using Microsoft.AspNetCore.Identity;
using Server.Domain.Entities;
using Server.Infrastructure.Context;

namespace Server.WebAPI;

public static class Helper
{
    public static async Task GenerateData(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope
                .ServiceProvider
                .GetRequiredService<AppDbContext>();

            var userManager = scope
                .ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();

            var roleManager = scope
                .ServiceProvider
                .GetRequiredService<RoleManager<AppRole>>();

            CancellationToken cancellationToken = new();

            if (!roleManager.Roles.Any())
            {
                List<AppRole> roles = new List<AppRole>()
                {
                    new AppRole() { Name = "Admin" },
                    new AppRole() { Name = "Customer" }
                };

                foreach (var role in roles)
                {
                    await roleManager
                        .CreateAsync(role);
                }
            }

            if (!userManager.Users.Any())
            {
                AppUser user = new()
                {
                    FullName = "Ahmet Hakan Eroğlu",
                    UserName = "aheroglu@outlook.com",
                    Email = "aheroglu@outlook.com"
                };

                var result = await userManager
                      .CreateAsync(user, "Ahmet123!");

                if (result.Succeeded)
                {
                    await userManager
                        .AddToRoleAsync(user, "Admin");
                }
            }

            if (!context.Set<Product>().Any())
            {
                var products = new List<Product>
                {
                    // Smartphones Category
                    new Product { Id = Guid.NewGuid().ToString(), Name = "iPhone 16 Pro", CategoryId = "5541b7f3-01c8-438f-affb-fe4e1f8b32cd", BrandId = "ccb100d9-7577-4784-9c93-c955079a6eba", Model = "A2933", Description = "High-end Apple smartphone", Url = "iphone-16-pro", Price = 1499, Stock = 100 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Galaxy S30", CategoryId = "5541b7f3-01c8-438f-affb-fe4e1f8b32cd", BrandId = "1359a85e-4439-4786-aefa-0ccf8ce91039", Model = "SMG998B", Description = "Flagship Samsung phone", Url = "galaxy-s30", Price = 1299, Stock = 120 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Xiaomi Mi 14", CategoryId = "5541b7f3-01c8-438f-affb-fe4e1f8b32cd", BrandId = "3e5ea74f-377c-4c7a-a540-22a2a565f139", Model = "MI14", Description = "Affordable flagship", Url = "xiaomi-mi-14", Price = 699, Stock = 300 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Huawei P60", CategoryId = "5541b7f3-01c8-438f-affb-fe4e1f8b32cd", BrandId = "fc638d0b-3d46-4d3c-b932-ada1a4f2a73c", Model = "P60", Description = "Huawei's flagship phone", Url = "huawei-p60", Price = 1199, Stock = 100 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Lenovo Legion Phone", CategoryId = "5541b7f3-01c8-438f-affb-fe4e1f8b32cd", BrandId = "234145ba-054c-4ad5-8417-2c09b1217dcf", Model = "Legion", Description = "Gaming Lenovo smartphone", Url = "lenovo-legion-phone", Price = 999, Stock = 150 },

                    // Laptops Category
                    new Product { Id = Guid.NewGuid().ToString(), Name = "MacBook Pro 16", CategoryId = "c7a40328-8892-4345-b2c6-3c363b93f99e", BrandId = "ccb100d9-7577-4784-9c93-c955079a6eba", Model = "MBP16", Description = "High-performance Apple laptop", Url = "macbook-pro-16", Price = 2499, Stock = 50 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "HP Spectre x360", CategoryId = "c7a40328-8892-4345-b2c6-3c363b93f99e", BrandId = "075c0663-522b-4cd7-b9f4-78c56a4b5d46", Model = "SPX360", Description = "Convertible HP laptop", Url = "hp-spectre-x360", Price = 1899, Stock = 90 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Acer Predator Helios", CategoryId = "c7a40328-8892-4345-b2c6-3c363b93f99e", BrandId = "70160b6a-3212-4855-b5e1-5d6dedff6259", Model = "PH", Description = "Gaming Acer laptop", Url = "acer-predator-helios", Price = 1599, Stock = 80 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Lenovo ThinkPad X1", CategoryId = "c7a40328-8892-4345-b2c6-3c363b93f99e", BrandId = "234145ba-054c-4ad5-8417-2c09b1217dcf", Model = "TPX1", Description = "Business-focused Lenovo laptop", Url = "lenovo-thinkpad-x1", Price = 1999, Stock = 120 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Samsung Galaxy Book", CategoryId = "c7a40328-8892-4345-b2c6-3c363b93f99e", BrandId = "1359a85e-4439-4786-aefa-0ccf8ce91039", Model = "GBX", Description = "Premium Samsung laptop", Url = "samsung-galaxy-book", Price = 1899, Stock = 80 },

                    // Accessories Category
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Logitech MX Master 3", CategoryId = "f7893b21-4144-4cc4-bdd1-5f0df8eeddcc", BrandId = "6459fd34-35f5-44e3-9df8-47bec4d1db49", Model = "MX3", Description = "High-performance wireless mouse", Url = "logitech-mx-master-3", Price = 99, Stock = 500 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Samsung T7 Portable SSD", CategoryId = "f7893b21-4144-4cc4-bdd1-5f0df8eeddcc", BrandId = "1359a85e-4439-4786-aefa-0ccf8ce91039", Model = "T7", Description = "High-speed portable storage", Url = "samsung-t7-ssd", Price = 150, Stock = 300 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "HP USB-C Dock", CategoryId = "f7893b21-4144-4cc4-bdd1-5f0df8eeddcc", BrandId = "075c0663-522b-4cd7-b9f4-78c56a4b5d46", Model = "USBDOCK", Description = "HP docking station", Url = "hp-usb-c-dock", Price = 200, Stock = 100 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Monster RGB Keyboard", CategoryId = "f7893b21-4144-4cc4-bdd1-5f0df8eeddcc", BrandId = "23631991-eb26-43a8-b8f7-74f28403d695", Model = "RGBKB", Description = "Gaming RGB keyboard", Url = "monster-rgb-keyboard", Price = 120, Stock = 200 },
                    new Product { Id = Guid.NewGuid().ToString(), Name = "Rampage Gaming Headset", CategoryId = "f7893b21-4144-4cc4-bdd1-5f0df8eeddcc", BrandId = "14e596f3-6edf-425a-bffc-8b8b72bafd6b", Model = "RGH", Description = "High-quality gaming headset", Url = "rampage-gaming-headset", Price = 80, Stock = 150 }
                };

                await context
                    .Set<Product>()
                    .AddRangeAsync(products, cancellationToken);

                await context
                    .SaveChangesAsync(cancellationToken);
            }
        }
    }
}

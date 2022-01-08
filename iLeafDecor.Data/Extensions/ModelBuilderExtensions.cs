using iLeafDecor.Data.Entities;
using iLeafDecor.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace iLeafDecor.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of iLeaf Decor" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of iLeaf Decor" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of iLeaf Decor" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { ID = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { ID = "en", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = 1,
                    IsShowOnHome = true,
                    ParentID = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                new Category()
                {
                    ID = 2,
                    IsShowOnHome = true,
                    ParentID = null,
                    SortOrder = 2,
                    Status = Status.Active
                });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() { ID = 1, CategoryID = 1, Name = "Ngoại thất", LanguageID = "vi", SeoAlias = "ngoai-that", SeoDescription = "Sản phẩm ngoại thất", SeoTittle = "Sản phẩm ngoại thất" },
                new CategoryTranslation() { ID = 2, CategoryID = 1, Name = "Outdoors", LanguageID = "en", SeoAlias = "outdoors", SeoDescription = "The products for outdoor decor", SeoTittle = "The products for outdoor decor" },
                new CategoryTranslation() { ID = 3, CategoryID = 2, Name = "Phòng ngủ", LanguageID = "vi", SeoAlias = "phong-ngu", SeoDescription = "Sản phẩm nội thất phòng ngủ", SeoTittle = "Sản phẩm nội thất phòng ngủ" },
                new CategoryTranslation() { ID = 4, CategoryID = 2, Name = "Bedroom", LanguageID = "en", SeoAlias = "bedroom", SeoDescription = "The products for bedroom decor", SeoTittle = "The products for bedroom decor" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ID = 1,
                    CreatedDate = DateTime.Now,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0,
                });
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    ID = 1,
                    ProductID = 1,
                    Name = "Ghế treo hai chỗ ngồi ngoài trời - Màu xám",
                    LanguageID = "vi",
                    SeoAlias = "ghe-treo-hai-cho-ngoi-ngoai-troi",
                    SeoDescription = "Ghế treo hai chỗ ngồi ngoài trời - Màu xám",
                    SeoTittle = "Ghế treo hai chỗ ngồi ngoài trời - Màu xám",
                    Details = "Ghế treo hai chỗ ngồi ngoài trời - Màu xám",
                    Description = "Ghế treo hai chỗ ngồi ngoài trời - Màu xám"
                },
                new ProductTranslation()
                {
                    ID = 2,
                    ProductID = 1,
                    Name = "Outdoor Two Seater Wicker Hanging Chair - Grey",
                    LanguageID = "en",
                    SeoAlias = "outdoor-two-seater-wicker-hanging-chair-grey",
                    SeoDescription = "Outdoor Two Seater Wicker Hanging Chair - Grey",
                    SeoTittle = "Outdoor Two Seater Wicker Hanging Chair - Grey",
                    Details = "Outdoor Two Seater Wicker Hanging Chair - Grey",
                    Description = "Outdoor Two Seater Wicker Hanging Chair - Grey"
                });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductID = 1, CategoryID = 1 }
                );

            // Guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "sonlh98ba@gmail.com",
                NormalizedEmail = "sonlh98ba@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Son",
                LastName = "Le",
                DOB = new DateTime(1998, 04, 11)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}

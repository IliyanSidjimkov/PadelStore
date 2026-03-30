

namespace PadelStore.Data.Common
{
    public class EntityValidation
    {
        public static class Brand
        {
            public const int BrandNameMaxLength = 70;
        }

        public static class Category
        {
            public const int CategoryNameMaxLength = 70;
        }

        public static class Product
        {
           public const int ProductNameMaxLength = 70;
           public const int ProductDescriptionMaxLength = 500;

        }

        public static class Review
        {
            public const int CommentMaxLength = 500;

        }
    }
}



namespace PadelStore.GCommon
{

    public static class ViewModelValidation
    {
        public static class Product
        {
            public const int ProductNameMinLength = 3;
            public const int ProductNameMaxLength = 100;

            public const int ProductDescriptionMinLength = 10;
            public const int ProductDescriptionMaxLength = 500;

            public const double minPrice = 10.00;
            public const double maxPrice = 10000.00;
        }
        public static class Category 
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 20;

        }
        public static class Brand
        {
            public const int BrandNameMinLength = 3;
            public const int BrandNameMaxLength = 50;

        }
        public static class Review
        {
            public const int ReviewCommentMinLenght = 5;
            public const int ReviewCommentMaxLenght = 500;
        }

    }
}

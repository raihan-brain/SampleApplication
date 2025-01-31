﻿namespace SampleApplication.Models
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Pie> AllPies =>
            new List<Pie>
            {
                new() {PieId = 1, Name = "Strawberry Pie", Price = 15.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum", Category = _categoryRepository.AllCategories.ToList()[0], ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg", InStock = true, IsPieOfTheWeek = true, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg"},
                new() {PieId = 2, Name = "Cheese Cake", Price = 18.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum", Category = _categoryRepository.AllCategories.ToList()[1], ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg", InStock = true, IsPieOfTheWeek = false, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg"},
                new() {PieId = 3, Name = "Rhubarb Pie", Price = 15.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum", Category = _categoryRepository.AllCategories.ToList()[2], ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg", InStock = true, IsPieOfTheWeek = false, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg"},
                new() {PieId = 4, Name = "Pumpkin Pie", Price = 12.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem Ipsum", Category = _categoryRepository.AllCategories.ToList()[2], ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg", InStock = true, IsPieOfTheWeek = true, ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg"}
            };

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return AllPies.Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId) =>
            AllPies.FirstOrDefault(p => p.PieId == pieId);


    }
}

 namespace SampleApplication.Models.ViewModels
{
    public class PieListViewModal
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }

        public PieListViewModal(IEnumerable<Pie> pies, string currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }
    }
}

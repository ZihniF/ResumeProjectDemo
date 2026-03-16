namespace ResumeProjectDemo.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public Category()
        {
            Portfolios = new List<Portfolio>(); // boş liste ile başlatıyoruz
        }
    }
}

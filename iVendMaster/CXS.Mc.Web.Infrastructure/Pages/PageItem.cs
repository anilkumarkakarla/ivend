namespace CXS.Mc.Web.Infrastructure.Pages
{
    public class PageItem
    {
        public string Id { get; set; }

        public PageGroupItem Group { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

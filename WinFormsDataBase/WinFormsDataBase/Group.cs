
namespace WinFormsDataBase
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int?  Year { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}

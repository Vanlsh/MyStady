namespace WinFormsDataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var group = new Group()
                {
                    Name = "Eminem",
                    Year = 1999
                };
                context.Groups.Add(group);
                context.SaveChanges();
                MessageBox.Show($"Name: {group.Name} Year:{group.Year}");
            }

            /*
             * C:\Users\Vanish\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB
            var context = new MyDbContext();

            string sqlCommand = "";
            sqlCommand += "USE test \n";
            sqlCommand += "CREATE TABLE table_name (column1 int) \n";

            context.Database.ExecuteSqlCommand(sqlCommand);
            MessageBox.Show("S");
            */
        }
    }
}
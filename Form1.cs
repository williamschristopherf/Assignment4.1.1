namespace Assignment4._1._1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Person> people = new Dictionary<string, Person>();
        private BindingSource bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            LoadForm1();
        }

        private void LoadForm1()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                MobilePhone = "555-555-5555",
                WorkPhone = "760-555-5555",
                Address = "123 Main Street"
            };

            var person2 = new Person
            {
                FirstName = "Josh",
                LastName = "Sanders",
                MobilePhone = "525-225-5234",
                WorkPhone = "760-523-5234",
                Address = "321 South Street"
            };

            people.Add(person.MobilePhone, person);
            people.Add(person2.MobilePhone, person2);

            bindingSource.DataSource = people.Values.ToList();
            dataGridView1.DataSource = bindingSource;
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDlt_Click(object sender, EventArgs e)
        {

        }
    }
}

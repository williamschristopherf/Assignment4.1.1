using System.Collections.Generic;

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
            var person1 = new Person
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

            var person3 = new Person
            {
                FirstName = "Amanda",
                LastName = "Smith",
                MobilePhone = "525-123-4567",
                WorkPhone = "760-987-6543",
                Address = "5573 Indiana Street"
            };

            people.Add(person1.MobilePhone, person1);
            people.Add(person2.MobilePhone, person2);
            people.Add(person3.MobilePhone, person3);

            bindingSource.DataSource = people.Values.ToList();
            dataGridView1.DataSource = bindingSource;
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText) )
            {
                MessageBox.Show("Please enter a search term.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                var foundPerson = people.Values.FirstOrDefault(p =>
                (!string.IsNullOrEmpty(p.FirstName) && p.FirstName.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.LastName) && p.LastName.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.MobilePhone) && p.MobilePhone.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.WorkPhone) && p.WorkPhone.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Address) && p.Address.ToLower().Contains(searchText)));

                if (foundPerson != null)
                {
                    MessageBox.Show($"Found:\n\nName: {foundPerson.FirstName} {foundPerson.LastName} {foundPerson.MobilePhone} {foundPerson.WorkPhone} {foundPerson.Address}", "Person Found", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No matching person found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Person person = new Person
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                MobilePhone = txtMobile.Text,
                WorkPhone = txtWork.Text,
                Address = txtAddress.Text,
            };

            people.Add(person.MobilePhone, person);
            dataGridView1.DataSource = null;
            bindingSource.DataSource = people.Values.ToList();
            dataGridView1.DataSource = bindingSource;
        }

        private void btnDlt_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                Person selectedPerson = (Person)dataGridView1.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"Are you sure you want to delete {selectedPerson.FirstName} {selectedPerson.LastName}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    people.Remove(selectedPerson.MobilePhone);
                    dataGridView1.DataSource = null;
                    bindingSource.DataSource = people.Values.ToList();
                    dataGridView1.DataSource = bindingSource;
                }
            }
            else
            {
                MessageBox.Show("Please select a person to delete.");
            }
        }
    }
}

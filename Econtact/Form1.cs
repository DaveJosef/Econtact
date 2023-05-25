using Econtact.Front.Model;
using Econtact.Front.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econtact
{
    public partial class Form1 : Form
    {
        private ContactRepository repository = new ContactRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(txtBoxId.Text);
            var FirstName = txtBoxFirstName.Text;
            var LastName = txtBoxLastName.Text;
            var ContactNo = txtBoxContactNo.Text;
            var Address = txtBoxAddress.Text;
            var Gender = cmbBoxGender.Text;

            Contact contactAdd = new Contact {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                ContactNo = ContactNo,
                Address = Address,
                Gender = Gender,
            };

            Contact result = repository.Insert(contactAdd);

            if (result.Id != 0)
            {
                MessageBox.Show("New Contact Successfully Inserted!");
                Clear();
            } else
            {
                MessageBox.Show("Failed to Add New Contact. Please, try again.");
            }

            var list = repository.List();

            var bindingList = new BindingList<Contact>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            txtBoxId.Text = "";
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxContactNo.Text = "";
            txtBoxAddress.Text = "";
            cmbBoxGender.Text = "";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtBoxId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxFirstName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxLastName.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxContactNo.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxAddress.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            cmbBoxGender.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(txtBoxId.Text);
            var FirstName = txtBoxFirstName.Text;
            var LastName = txtBoxLastName.Text;
            var ContactNo = txtBoxContactNo.Text;
            var Address = txtBoxAddress.Text;
            var Gender = cmbBoxGender.Text;

            Contact contactUpdate = new Contact
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                ContactNo = ContactNo,
                Address = Address,
                Gender = Gender,
            };

            Contact result = repository.Update(contactUpdate);

            if (result.Id != 0)
            {
                MessageBox.Show("The Contact was Successfully Updated!");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Update The Contact. Please, try again.");
            }

            var list = repository.List();

            var bindingList = new BindingList<Contact>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(txtBoxId.Text);

            int result = repository.Delete(Id);

            if (result != 0)
            {
                MessageBox.Show("The Contact was Successfully Deleted!");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Delete The Contact. Please, try again.");
            }

            var list = repository.List();

            var bindingList = new BindingList<Contact>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;

            var list = repository.List(keyword);

            var bindingList = new BindingList<Contact>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }
    }
}

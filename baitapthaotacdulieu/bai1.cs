using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace baitapthaotacdulieu
{
    public partial class bai1 : Form
    {
        int idInput = 0;
        int count1922 = 0;
        public bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reg = @"^.+, [0-3]?[0-9][\/][0-3]?[0-9][\/](?:[0-9]{2})?[0-9]{2}, .+,.+";
            string input = txtInput.Text;
            string id, name, birthday, address, classname;
            Regex checkinput = new Regex(reg);

            if (tableStudent.SelectedItems.Count > 2)
            {
                return;
            }

            if (!checkinput.IsMatch(input))
            {
                MessageBox.Show("Không đúng form input");
            }
            else
            {
                String[] res = Regex.Split(input, @",");
                name = res[0];
                birthday = res[1];
                int age = splitYear(birthday);
                if (age >= 19 && age <= 22) count1922++;
                address = res[2];
                classname = res[3];
                id = idInput.ToString();
                idInput++;
                ListViewItem item = new ListViewItem(id);
                item.SubItems.Add(name);
                item.SubItems.Add(birthday);
                item.SubItems.Add(address);
                item.SubItems.Add(classname);

                tableStudent.Items.Add(item);

                txtInput.Text = "";
                resCount.Text = count1922.ToString();
            }
        }

        private int splitYear(string birthDay)
        {
            var today = DateTime.Today;
            // Calculate the age.
            String[] res = Regex.Split(birthDay, @"/");
            int age = today.Year - int.Parse(res[2]);
            return age;
        }
    }
}

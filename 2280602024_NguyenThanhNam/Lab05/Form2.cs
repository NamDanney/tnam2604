using Lab05.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    public partial class Form2 : Form
    {
        StudentContextDB db;
        public Form2()
        {
            InitializeComponent();
            db = new StudentContextDB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox4.Text = "0";
            try
            {
                List<Faculty> listFalcuty = db.Faculties.ToList();
                BindGrid(listFalcuty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<Faculty> facultyList)
        {
            dataGridView2.Rows.Clear();
            foreach (var item in facultyList)
            {
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells["Col_MaKhoa"].Value = item.FacultyID;
                dataGridView2.Rows[index].Cells["Col_TenKhoa"].Value = item.FacultyName;
                dataGridView2.Rows[index].Cells["Col_TGS"].Value = item.TotalProfessor;


            }
        }

        private void CountTGS()
        {   
            textBox4.Text = db.Faculties.Sum(s => s.TotalProfessor).ToString();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Faculty> facultyList = db.Faculties.ToList();


                if (facultyList.Any(s => s.FacultyID == int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("Mã số đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (textBox2.Text.Length < 3 || textBox2.Text.Length > 100 || textBox2.Text.Any(c => !char.IsLetter(c) && c != ' '))
                {
                    MessageBox.Show("Tên khoa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(int.Parse(textBox3.Text) <0 || int.Parse(textBox3.Text) > 15)
                {
                    MessageBox.Show("Tổng giáo sư không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

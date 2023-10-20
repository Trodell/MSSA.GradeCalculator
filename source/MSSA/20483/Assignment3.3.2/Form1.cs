using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3._3._2
{
    /// <summary>
    /// User input is validated for ID to ensure that it is a number between 1-999 as well as checking the hard data from the list already defined if the ID is already in use
    /// the combo box for Month and Grade have been in given the additional element of their respective name. I've ensured that they have both been indexed at 0 and will be unreachable
    /// in the get and set block. I've decided to keep the data grid visible as a creative decision.
    /// When add button is clicked the the information will be stored in the data grid and the text boxes will be cleared, ready for additional input
    /// when the delete button is clicked the user will recieve a message prompt asking for their confirmation and, depending on their decision, the information from whichever indexed
    /// data within the data grid will be deleted. The exit button will close the application.
    /// </summary>
    public partial class Form1 : Form
    {
        List<Student> StudList; //list is now open for all methods within this class
        public Form1()
        {
            InitializeComponent();
        }
        void RefreshData()
        {
            txtStudId.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            comboMonth.SelectedIndex = 0;
            comboGrade.SelectedIndex = 0;
            studGrid.DataSource = null;
            studGrid.DataSource = StudList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StudList = new List<Student>();
            StudList.Add(new Student() { Id = 109, FirstName = "Tyler", LastName = "Rodell", Address = "1234 Address Rd", MonthOfAdmission = Month.April, StudentGrade = Grade.A});
            StudList.Add(new Student() { Id = 001, FirstName = "John", LastName = "Smith", Address = "3232 Kelso St", MonthOfAdmission = Month.January, StudentGrade = Grade.D });
            StudList.Add(new Student() { Id = 076, FirstName = "George", LastName = "Washington", Address = "1600 Pennsylvania Ave", MonthOfAdmission = Month.July, StudentGrade = Grade.A });
            StudList.Add(new Student() { Id = 598, FirstName = "Robert", LastName = "Duvall", Address = "321 Hollywood Ct", MonthOfAdmission = Month.October, StudentGrade = Grade.B });
            StudList.Add(new Student() { Id = 999, FirstName = "Roger", LastName = "Waters", Address = "00 Wall PkWay", MonthOfAdmission = Month.November, StudentGrade = Grade.F });
            studGrid.DataSource = StudList;
            comboMonth.DataSource = Enum.GetValues(typeof(Month));
            comboGrade.DataSource = Enum.GetValues(typeof(Grade));
            grpStudDetails.Visible = true;


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblStudId_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpStudDetails.Visible = true;
            if (txtStudId.Text != String.Empty && txtFName.Text != String.Empty && txtLName.Text != String.Empty && comboMonth.SelectedIndex != 0 && comboGrade.SelectedIndex != 0 )
            {
                Student newstud = new Student();
                newstud.Id=int.Parse(txtStudId.Text);
                newstud.FirstName=txtFName.Text;
                newstud.LastName=txtLName.Text;
                newstud.Address=txtAddress.Text;
                newstud.MonthOfAdmission=(Month)comboMonth.SelectedIndex;
                newstud.StudentGrade=(Grade)comboGrade.SelectedIndex;
                StudList.Add(newstud);
                MessageBox.Show("Student Added!");
                RefreshData();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var result=MessageBox.Show("Are you sure?","Caution!",MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                StudList.RemoveAt(studGrid.CurrentRow.Index);
                RefreshData();
            }

        }

        private void txtStudId_Validating(object sender, CancelEventArgs e)
        {
            
            if(!int.TryParse(txtStudId.Text,out int val) || int.Parse(txtStudId.Text) <= 0 || int.Parse(txtStudId.Text) > 999)
            {
                
                    MessageBox.Show("Please enter a number between 1-999");
                e.Cancel = true;
                txtStudId.Clear();
            }
            foreach (var student in StudList)
                {
                    if (txtStudId.Text == student.Id.ToString()) //Thank you for the help
                { 
                    MessageBox.Show("ID number has already been chosen");
                    e.Cancel = true;
                    txtStudId.Clear();
                } 
                   
                }
        }
    }
}

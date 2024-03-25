using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Q1.Models;
using Q1.Repository;
namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> Employeess = new List<Employee>();
        IEmpRepository empRepository;
        public MainWindow(IEmpRepository repository)
        {
            
            InitializeComponent();
            empRepository = repository;
        }
        private void LoadEmpList()
        {
            lvEmps.ItemsSource = empRepository.GetEmployees();
            
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadEmpList();
                MessageBox.Show("Loaded Successfully", "Load");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load car list");
            }
        }
        private int checkValidationInt()
        {
            try
            {
                int b = int.Parse(txtEmpId.Text);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }

        private bool blankInput()
        {
            if (txtEmpId.Text.Length < 1 || txtEmpName.Text.Length < 1 || txtPhone.Text.Length < 1
                 || myDatePicker.Text.Length < 1) return false;
            return true;
        }
        private Employee GetEmployeeObjects()
        {
            Employee employee = null;
            try
            {
                string check = "Female";
                if (male.IsChecked == true)
                {
                    check = "Male";
                }
                employee = new Employee
                {
                    //Id = int.Parse(txtEmpId.Text),
                    Name = txtEmpName.Text,
                    Phone = txtPhone.Text,
                    Idnumber = ComboBox1.Text,
                    Dob = myDatePicker.SelectedDate,
                    Gender = check
                };
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Employee");
            }

            return employee;
        }

        private Employee GetEmployeeObjectsEdit()
        {
            Employee employee = null;
            try
            {
                string check = "Female";
                if (male.IsChecked == true)
                {
                    check = "Male";
                }
                employee = new Employee
                {
                    Id = int.Parse(txtEmpId.Text),
                    Name = txtEmpName.Text,
                    Phone = txtPhone.Text,
                    Idnumber = ComboBox1.Text,
                    Dob = myDatePicker.SelectedDate,
                    Gender = check
                };
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Employee");
            }

            return employee;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkValidationInt() == 0)
                {
                    MessageBox.Show("id is interger");

                    return;
                }

                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Insert car");
                    return;
                }
                Employee employee = GetEmployeeObjects();
                empRepository.InsertEmployee(employee);
                LoadEmpList();
                MessageBox.Show($"{employee.Name} inserted successfully ", "Insert Employee");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Insert employee");
                    return;
                }
                Employee employee = GetEmployeeObjectsEdit();
                empRepository.UpdateEmployee(employee);
                LoadEmpList();
                MessageBox.Show($"{employee.Name} updated successfully ", "Update employee");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update car");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Insert car");
                    return;
                }
                Employee employee = GetEmployeeObjectsEdit();
                empRepository.DeleteEmployee(employee);
                LoadEmpList();
                MessageBox.Show($"{employee.Name} deleted successfully ", "Delete car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }
        private void btnAddList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Insert Employee");
                    return;
                }
                Employee employee = GetEmployeeObjectsEdit();
                Employeess.Add(employee);
                lvEmps.ItemsSource = Employeess.ToList();
                MessageBox.Show("add Emp sucess");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }
        private void btnImportFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Employee> list = ReadDataFromFile<List<Employee>>("data/stars.json");
                foreach (Employee item in list)
                {
                    Employeess.Add(item);
                }
                lvEmps.ItemsSource = Employeess.ToList();
                MessageBox.Show("Real file sucess");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }

        private  T ReadDataFromFile<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }

        private void btnSaveDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Employee item in Employeess)
                {
                    item.Id = 0;
                    empRepository.InsertEmployee(item);
                }
                LoadEmpList();
                MessageBox.Show("Save DB success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvEmps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee emp = (Employee)lvEmps.SelectedItem;
            if (emp == null)
                return;
            else
            {
                if (emp.Gender.Equals("Male"))
                {
                    male.IsChecked = true;
                }
                else
                {
                    female.IsChecked = true;
                }
            }
            ComboBox1.Text = emp.Idnumber;
            cba.IsChecked = true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Q1.Models;
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
using System.Xml.Serialization;

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Employee> emps = new List<Employee>();
        private void loadData()
        {
            //load data từ sql
            PRN221_Spr22Context _context = new PRN221_Spr22Context();
            lvEmps.ItemsSource = _context.Employees.ToList();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private bool blankInput()
        {
            if (txtEmpId.Text.Length < 1 || txtEmpName.Text.Length < 1 || txtPhone.Text.Length < 1
                 || myDatePicker.Text.Length < 1 || txtIDNumber.Text.Length < 1) return false;
            return true;
        }
        private Employee GetEmployee()
        {
            Employee emp = new Employee();
            emp.Name = txtEmpName.Text;
            emp.Gender = "Male";
            if (female.IsChecked == true)
            {
                emp.Gender = "Female";
            }
            emp.Dob = DateTime.Parse(myDatePicker.Text);
            emp.Phone = txtPhone.Text;
            emp.Idnumber = txtIDNumber.Text;
            return emp;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (blankInput() == false)
            {
                MessageBox.Show("Infomation not empty");
                return;
            }
            //get object
            Employee emp = GetEmployee();
            PRN221_Spr22Context _context = new PRN221_Spr22Context();
            _context.Employees.Add(emp);
            _context.SaveChanges();
            loadData();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (blankInput() == false)
            {
                MessageBox.Show("Infomation not empty");
                return;
            }
            Employee emp = GetEmployee();
            emp.Id = int.Parse(txtEmpId.Text);
            PRN221_Spr22Context _context = new PRN221_Spr22Context();
            _context.Entry(emp).State = EntityState.Modified;
            _context.SaveChanges();
            loadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (blankInput() == false)
            {
                MessageBox.Show("Infomation not empty");
                return;
            }
            Employee emp = GetEmployee();
            emp.Id = int.Parse(txtEmpId.Text);
            PRN221_Spr22Context _context = new PRN221_Spr22Context();
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            loadData();
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
        }

        private void btnAdd_To_List(object sender, RoutedEventArgs e)
        {
            Employee employee = GetEmployee();
            emps.Add(employee);
            lvEmps.ItemsSource = emps.ToList();

        }

        private void btnSave_DB(object sender, RoutedEventArgs e)
        {
            PRN221_Spr22Context _context = new PRN221_Spr22Context();
            foreach (var item in emps)
            {
                _context.Employees.Add(item);
            }
            _context.SaveChanges();
            loadData();
        }

        private void btnImport_Json(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            bool? result = openFileDialog.ShowDialog();
            try
            {
                List<Employee> list = ReadDataFromFile<List<Employee>>(openFileDialog.FileName);
                foreach (Employee item in list)
                {
                    emps.Add(item);
                }
                lvEmps.ItemsSource = emps.ToList();
                MessageBox.Show("Read file sucess");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }

        private T ReadDataFromFile<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }

        private void btnExport_Json(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "json";
            if (saveFileDialog.ShowDialog() != true)
            {
                return;
            }
            File.WriteAllText(saveFileDialog.FileName, JsonSerializer.Serialize(emps));
        }

        private void btnImport_Xml(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.Multiselect = false;

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string selectedFile = openFileDialog.FileName;

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    var Employees = (List<Employee>)xmlSerializer.Deserialize(fileStream);
                    lvEmps.ItemsSource = Employees;
                }
            }
        }

        private void btnExport_Xml(object sender, RoutedEventArgs e)
        {
            List<Employee> myList = new List<Employee>();
            Employee obj1 = new Employee
            {
                Id = 1,
                Name = "John Doe",
                Gender = "Male",
                Dob = new DateTime(1990, 1, 1),
                Phone = "123456789",
                Idnumber = "ABC123",
                Services = { }
            };
            myList.Add(obj1);

            // Create another instance of abc and add it to the list
            Employee obj2 = new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Gender = "Female",
                Dob = new DateTime(1995, 2, 2),
                Phone = "987654321",
                Idnumber = "DEF456",
                Services = { }
            };
            myList.Add(obj2);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() != true)
            {
                return;
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
            using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, myList);
            }
        }

        private void btnImport_Txt(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            bool? result = openFileDialog.ShowDialog();
            List<Employee> employees = new List<Employee>();

            // Read the text file and populate Employee objects
            using (StreamReader reader = new StreamReader(openFileDialog.FileName))
            {


                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Employee currentEmployee = new Employee();
                    string[] words = line.Split(",");
                    currentEmployee.Id = int.Parse(words[0]);
                    currentEmployee.Name = words[1];
                    currentEmployee.Gender = words[2];
                    currentEmployee.Dob = DateTime.Parse(words[3]);
                    currentEmployee.Phone = words[4];
                    currentEmployee.Idnumber = words[5];
                    employees.Add(currentEmployee);
                }
            }
            lvEmps.ItemsSource = employees;



        }

        private void btnExport_Txt(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            bool? result = openFileDialog.ShowDialog();
            // Write the list of employees to the text file
            using (StreamWriter writer = new StreamWriter(openFileDialog.FileName))
            {
                foreach (var employee in emps)
                {
                    writer.Write($"{employee.Id}");
                    writer.Write($"{employee.Name},");
                    writer.Write($"{employee.Gender},");
                    writer.Write($"{employee.Dob},");
                    writer.Write($"{employee.Phone},");
                    writer.Write($"{employee.Idnumber},");
                    // Write services if needed
                    foreach (var service in employee.Services)
                    {
                        writer.WriteLine($"{new Service()}"); // Replace "Property" with the actual property of Service class
                    }
                    writer.WriteLine(); // Add a blank line between employees
                }
                MessageBox.Show("success");
            }
        }
    }
}

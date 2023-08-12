using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace OO_programming
{
    public partial class Form1 : Form
    {
        string NEWLINE = Environment.NewLine;

        private List<Employee> listEmployee;
        
        /// <summary>
        /// form1 used to populate listbox and return information on employee
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Add code below to complete the implementation to populate the listBox
            // by reading the employee.csv file into a List of PaySlip objects, then binding this to the ListBox.
            // CSV file format: <employee ID>, <first name>, <last name>, <hourly rate>,<taxthreshold>

            listEmployee = new List<Employee>();
            LoadTextFileToListbox(@"employee.csv", listEmployee);
            


        }
        /// <summary>
        /// general surface of the payroll system, used as the square design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        ///  Used to load employee info to listbox
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="listEmployee"></param>
        private void LoadTextFileToListbox(string inputFilePath, List<Employee> listEmployee)
        {
            try
            {
                using (StreamReader inputFileReader = new StreamReader(inputFilePath))
                {
                    string line;
                    while ((line = inputFileReader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }
                        //used to load employee info in regard to each value
                        string[] columns = line.Split(',');
                        if (columns.Length >= 5)
                        {
                            string employeeID = columns[0].Trim();
                            string firstName = columns[1].Trim();
                            string lastName = columns[2].Trim();
                            double hourlyRate = double.Parse(columns[3].Trim());
                            string taxThreshold = columns[4].Trim().ToUpper() == "Y" ? "With Threshold" : "No Threshold";

                            Employee employee = new Employee(employeeID, firstName, lastName, hourlyRate, taxThreshold, 0);

                            listEmployee.Add(employee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while loading the input file: " + ex.Message);
            }
        }
        /// <summary>
        /// "Calculate" button used to calclulate the payment and enter employee details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedItem != null)
            {
                //employee inputs hours then tax calculations are done
                Employee selectedEmployee = (Employee)lstEmployee.SelectedItem;
                string hours = txtHours.Text;

                if (txtHours.Text == string.Empty)
                {
                    MessageBox.Show("Please enter your hours in the textbox.");
                    txtHours.Focus();
                }
                else if (!double.TryParse(hours, out double hoursWorked))
                {
                    MessageBox.Show("Invalid input for hours worked. Please enter a valid number.");
                    txtHours.Focus();
                }
                else if (hoursWorked < 0)
                {
                    MessageBox.Show("Invalid input for hours worked. Hours cannot be negative.");
                    txtHours.Focus();
                }
                else if (hoursWorked > 40)
                {
                    MessageBox.Show("Special permission from the manager is required for hours exceeding 40.");
                    txtHours.Focus();
                }
                else
                {
                    selectedEmployee.hoursWorked = hoursWorked;

                    selectedEmployee.hoursWorked = double.Parse(hours);

                    double tax = 0.0;
                    PayCalculator payCalculator = new PayCalculator();
                    //to deduce the tax of employee, see if they are with or without threshold
                    if (selectedEmployee.TaxThreshold == "With Threshold")
                    {
                        PayCalculatorWithThreshold calculator = new PayCalculatorWithThreshold();
                        tax = calculator.CalcTaxV2(selectedEmployee.GrossPay);
                        payCalculator = calculator;
                    }
                    else if (selectedEmployee.TaxThreshold == "No Threshold")
                    {
                        PayCalculator calculator = new PayCalculator();
                        tax = calculator.CalcTaxV3(selectedEmployee.GrossPay);
                        payCalculator = calculator;
                    }

                    selectedEmployee.CalculatePayment();
                    //to populate the info box with information after the hours are calculated
                    txtHoursInfo.Text = "Employee ID: " + selectedEmployee.EmployeeID + NEWLINE +
                        "Full Name: " + selectedEmployee.FullName + NEWLINE +
                        "Hours: " + hours + NEWLINE +
                        "Hourly Rate: $" + selectedEmployee.HourlyRate + NEWLINE +
                        "Tax Threshold: " + selectedEmployee.TaxThreshold + NEWLINE +
                        "Gross Pay: " + selectedEmployee.GrossPay.ToString("C") + NEWLINE +
                        "Tax: " + selectedEmployee.Tax.ToString("C") + NEWLINE +
                        "Net Pay: " + selectedEmployee.NetPay.ToString("C") + NEWLINE +
                        "Superannuation: " + selectedEmployee.Superannuation.ToString("C");
                    
                    
                    lstEmployee.DataSource = null; 
                    lstEmployee.DataSource = listEmployee; 
                    lstEmployee.DisplayMember = "EmployeeInfo";

                    btnSave.Enabled = true;
                }
            }
        }

        //Used to format the csv file
        private string FormatCurrency(double value)
        {
            return value.ToString("C", CultureInfo.InvariantCulture).Replace(",", "");
        }
        /// <summary>
        /// used to save employee info to csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedItem != null)
            {
                //selects all employee information and saves to prepare to save to csv
                Employee selectedEmployee = (Employee)lstEmployee.SelectedItem;
                btnSave.Enabled = true;
                string employeeID = selectedEmployee.EmployeeID;
                string fullName = selectedEmployee.FullName;              
                string taxThreshold = selectedEmployee.TaxThreshold;

                double hoursWorked, hourlyRate, grossPay, tax, netPay, superannuation;
                (hoursWorked, hourlyRate, grossPay, tax, netPay, superannuation) = 
                (selectedEmployee.hoursWorked, selectedEmployee.HourlyRate, selectedEmployee.GrossPay, 
                selectedEmployee.Tax, selectedEmployee.NetPay, selectedEmployee.Superannuation);

                string grossPayFormatted = FormatCurrency(selectedEmployee.GrossPay);
                string taxFormatted = FormatCurrency(selectedEmployee.Tax);
                string netPayFormatted = FormatCurrency(selectedEmployee.NetPay);


                //information to populate the csv file
                string outputFilePath = $"Pay_{fullName}_{DateTime.Now:yyyyMMddHHmmss}.csv";
                string fileC = $"Employee ID: {employeeID} {Environment.NewLine}"
                 + $"Full Name: {fullName} {Environment.NewLine}"
                 + $"Hours Worked: {hoursWorked} {Environment.NewLine}"
                 + $"Hourly Rate: {hourlyRate} {Environment.NewLine}"
                 + $"Tax Threshold: {taxThreshold} {Environment.NewLine}"
                 + $"Gross Pay: ${grossPay} {Environment.NewLine}"
                 + $"Tax: ${tax} {Environment.NewLine}"
                 + $"Net Pay: ${netPay} {Environment.NewLine}" 
                 + $"Superannuation: ${superannuation} {Environment.NewLine}";
                
                File.WriteAllText(outputFilePath, fileC);
                MessageBox.Show($"Saved at {DateTime.Now:yyyy/MM/dd HH:mm}");
            }
        }

        /// <summary>
        /// Used to input employee information into the listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //load listbox to choose from employees
            this.Text = "Employee List - Input Hours";
            lstEmployee.DataSource = listEmployee;
            lstEmployee.DisplayMember = "EmployeeInfo";
        }

        
    }
}
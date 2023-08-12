using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_programming
{
    /// <summary>
    /// employee class to retrieve all employee information
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// holds all variables for employee, used in listbox and in saved csv
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="hourlyRate"></param>
        /// <param name="taxThreshold"></param>
        /// <param name="hoursWorked"></param>
        public Employee(string employeeID, string firstName, string lastName, double hourlyRate, string taxThreshold, double hoursWorked)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = hourlyRate;
            TaxThreshold = taxThreshold;
            this.hoursWorked = hoursWorked;
        }
        /// <summary>
        /// id for employee
        /// </summary>
        public string EmployeeID { get; set; }
        /// <summary>
        /// firstname of employee
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// lastname of employee
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// employee's hourly rate
        /// </summary>
        public double HourlyRate { get; set; }
        /// <summary>
        /// tax threshold of employee
        /// </summary>
        public string TaxThreshold { get; set; }       
        /// <summary>
        /// grossPay of the employee
        /// </summary>
        public double GrossPay { get; set; }
        /// <summary>
        /// amount of tax paid by employee
        /// </summary>
        public double Tax { get; set; }
        /// <summary>
        /// employee's net pay
        /// </summary>
        public double NetPay { get; set; }
        /// <summary>
        /// superannuation of employee
        /// </summary>
        public double Superannuation { get; set; }
        /// <summary>
        /// used to shorten code, full name of employee
        /// </summary>
        public string FullName => FirstName + " " + LastName;
        /// <summary>
        /// used to further shorten code by combining employeeID and FullName
        /// </summary>
        public string EmployeeInfo => $"{EmployeeID} - {FullName}";
        /// <summary>
        /// hours worked by employee
        /// </summary>
        public double hoursWorked { get; internal set; }



        /// <summary>
        /// used to calculate the payment in the listbox 
        /// </summary>
        public void CalculatePayment()
        {
            PayCalculator payCalculator;
            //method to be called to calculate the tax
            if (TaxThreshold == "With Threshold")
                payCalculator = new PayCalculatorWithThreshold();
            else
                payCalculator = new PayCalculator();

            GrossPay = payCalculator.CalculateGrossPay(this);
            Tax = payCalculator.CalculateTax(GrossPay, TaxThreshold);
            Superannuation = payCalculator.CalculateSuperannuation(GrossPay);
            NetPay = payCalculator.CalculateNetPay(GrossPay, Tax);
        }


    }
}

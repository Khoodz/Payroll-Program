using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OO_programming;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Lifetime;

namespace OO_programming
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }


    /// <summary>
    /// Class a capture details accociated with an employee's pay slip record
    /// </summary>
    public class PaySlip
    {
        string paysummary;

        /// <summary>
        /// used to return paysummary
        /// </summary>
        /// <param name="paysummary"></param>
        public PaySlip(string paysummary)
        {
            this.paysummary = paysummary;
        }
    }

    /// <summary>
    /// Base class to hold all Pay calculation functions
    /// Default class behaviour is tax calculated with tax threshold applied
    /// </summary>
    public class PayCalculator
    {
        /// <summary>
        /// calculate grossPay based using employee variable to retrieve all information, etc hourly rate.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public double CalculateGrossPay(Employee employee)
        {
            double grossPay = employee.hoursWorked * employee.HourlyRate; //calculations to determine employee gross pay
            return grossPay;
        }
        /// <summary>
        /// used to calculate superannuation, it is grossPay times 0.105
        /// </summary>
        /// <param name="grossPay"></param>
        /// <returns></returns>
        public double CalculateSuperannuation(double grossPay)
        {
            double superannuation = grossPay * 0.105; //used to calculate the superannuation amount 
            return superannuation;
        }

        /// <summary>
        /// grossPay used to calculate grossPay
        /// taxThreshold used to determine tax threshold is true or not
        /// </summary>
        /// <param name="grossPay"></param>
        /// <param name="taxThreshold"></param>
        /// <returns></returns>
        public  double CalculateTax(double grossPay, string taxThreshold) //calculate tax method called in tax calculation
        { 
            double tax = 0.0;

            if (taxThreshold == "With Threshold")
            {
                // Calculate tax using CalcTaxV2 method
                PayCalculatorWithThreshold calculatorWithThreshold = new PayCalculatorWithThreshold();
                tax = calculatorWithThreshold.CalcTaxV2(grossPay);
            }
            else if (taxThreshold == "No Threshold")
            {
                // Calculate tax using CalcTaxV3 method
                tax = CalcTaxV3(grossPay);
            }

            return tax;
        }

        /// <summary>
        /// tax calculator for employees with no tax free threshold
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        //method is used to calculate the tax for a employee who has no tax free threshold
        //tax rates are grabbed from csv file
        public double CalcTaxV3(double salary)
        {
            const string fileName = "taxrate-nothreshold.csv";
            double tax = 0.0;

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                            continue;

                        string[] columns = line.Split(',');

                        if (columns.Length != 4)
                            throw new Exception("Invalid input file. Each line should contain 4 elements.");

                        double minValue = Convert.ToDouble(columns[0].Trim());
                        double maxValue = Convert.ToDouble(columns[1].Trim());
                        double coefficientA = Convert.ToDouble(columns[2].Trim());
                        double coefficientB = Convert.ToDouble(columns[3].Trim());

                        if (salary >= minValue && salary <= maxValue)
                        {
                            tax = (salary * coefficientA) - coefficientB;
                            break;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return tax;
        }



        /// <summary>
        /// used to calculate net pay by doing grossPay minus tax
        /// </summary>
        /// <param name="grossPay"></param>
        /// <param name="tax"></param>
        /// <returns></returns>
        public double CalculateNetPay(double grossPay, double tax)
        {
            double netPay = grossPay - tax; //calculation to receive net pay
            return netPay;
        }

        

    }
    
    
    
    


    /// <summary>
    /// paycalculator class with threshold
    /// </summary>
    public class PayCalculatorWithThreshold : PayCalculator
    {
        /// <summary>
        /// method to calculate tax with tax free threshold
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public double CalcTaxV2(double salary)
        {
            const string fileName = "taxrate-withthreshold.csv";
            double tax = 0.0;
            //method is used to calculate the tax for a employee who has tax free threshold
            //tax rates are grabbed from csv file
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                            continue;

                        string[] columns = line.Split(',');

                        if (columns.Length != 4)
                            throw new Exception("Invalid input file. Each line should contain 4 elements.");

                        double minValue = Convert.ToDouble(columns[0].Trim());
                        double maxValue = Convert.ToDouble(columns[1].Trim());
                        double coefficientA = Convert.ToDouble(columns[2].Trim());
                        double coefficientB = Convert.ToDouble(columns[3].Trim());

                        if (salary >= minValue && salary <= maxValue)
                        {
                            tax = (salary * coefficientA) - coefficientB;
                            break;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return tax;
        }



    }

}





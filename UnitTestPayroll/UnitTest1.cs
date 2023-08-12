using Microsoft.VisualStudio.TestTools.UnitTesting;
using OO_programming;
using System;
using System.Runtime.Remoting.Lifetime;

namespace UnitTestPayroll
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateGrossPay_ReturnsCorrectGrossPay()
        {
            // Arrange
            PayCalculator payCalculator = new PayCalculator();
            Employee employee = new Employee("Mickey", "Mouse", "123456", 20.33, "With Threshold", 30);
            double expectedGross = 609.9;
            // Act
            double actualGrossPay = payCalculator.CalculateGrossPay(employee), 
                tolenrence = 0.0000001;

        
            // Assert
            Assert.AreEqual(actualGrossPay, expectedGross, tolenrence);
            //Assert.AreEqual(expected: 3.5, actual: 3.4999999, delta: 0.1);
        }
        [TestMethod]
        public void CalculateNetPay_ReturnsCorrectNetPay()
        {
            // Arrange
            PayCalculator payCalculator = new PayCalculator();
            double grossPay = 1000;
            double tax = 200;

            // Act
            double netPay = payCalculator.CalculateNetPay(grossPay, tax);

            // Assert
            Assert.AreEqual(800, netPay);
        }

        [TestMethod]
        public void CalculateSuperannuation_ReturnsCorrectSuperannuation()
        {
            // Arrange
            PayCalculator payCalculator = new PayCalculator();
            double grossPay = 1000;
            double expectedSuper = grossPay * 0.105;

            // Act
            double actualSuper = payCalculator.CalculateSuperannuation(grossPay);

            // Assert
            Assert.AreEqual(expectedSuper, actualSuper, 0.0001);
        }

        [TestMethod]

        public void CalculateTax_WithThreshold_ReturnsCorrectTax()
        {
            //Testing that all tax brackets in the withThreshold method return correct.
            // Arrange
            //1st bracket
            double grossPay = 350; // Example gross pay
            double expectedTax = 0; // Expected tax based on the provided tax rate schedule

            PayCalculator payCalculator = new PayCalculator();
            Employee employee = new Employee("1", "Lebron", "James", 35, "With Threshold", 10); // Add hoursWorked parameter

            // Act
            double actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001); // Allowing a small margin for decimal error

            // Arrange 
            //2nd bracket
            grossPay = 420; 
            expectedTax = 11.4538; 

            payCalculator = new PayCalculator();
            employee = new Employee("2", "John", "Doe", 20, "With Threshold", 21);

            // Act
            actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001);

            // Arrange 
            //3rd bracket
            grossPay = 500;
            expectedTax = 32.8058;

            payCalculator = new PayCalculator();
            employee = new Employee("3", "Mickey", "Mouse", 25, "With Threshold", 20);

            // Act
            actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001);

            // Arrange 
            //4th bracket
            grossPay = 700;
            expectedTax = 78.6535;

            payCalculator = new PayCalculator();
            employee = new Employee("4", "Mike", "Wazowski", 35, "With Threshold", 20);

            // Act
            actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001);


            // Arrange 
            //5th bracket
            grossPay = 850;
            expectedTax = 111.3131;

            payCalculator = new PayCalculator();
            employee = new Employee("5", "John", "Cena", 25, "With Threshold", 34);

            // Act
            actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001);


            // Arrange 
            //6th bracket
            grossPay = 1250;
            expectedTax = 248.4131;

            payCalculator = new PayCalculator();
            employee = new Employee("6", "Ankara", "Messi", 125, "With Threshold", 10);

            // Act
            actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001);

            // Arrange 
            //7th bracket
            grossPay = 2300;
            expectedTax = 610.7496;

            payCalculator = new PayCalculator();
            employee = new Employee("7", "Leo", "Baha", 57.5, "With Threshold", 40);

            // Act
            actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001);

            // Arrange 
            //8th bracket
            grossPay = 3460;
            expectedTax = 1062.8035;

            payCalculator = new PayCalculator();
            employee = new Employee("8", "Abe", "Donald", 86.5, "With Threshold", 40);

            // Act
            actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001);

            // Arrange 
            //9th bracket
            grossPay = 4000;
            expectedTax = 1316.4804;

            payCalculator = new PayCalculator();
            employee = new Employee("9", "Bill", "Gates", 100, "With Threshold", 40);

            // Act
            actualTax = payCalculator.CalculateTax(grossPay, employee.TaxThreshold);

            // Assert
            Assert.AreEqual(expectedTax, actualTax, 0.0001);


        }
       
      

                [TestMethod]
        public void CalculateTax_NoThreshold_ReturnsCorrectTax()
        {
            //Testing that all tax brackets in the noThreshold method return correct.
            // Arrange
            PayCalculator payCalculator = new PayCalculator();
            double grossPay = 80; //1st bracket
            string taxThreshold = "No Threshold";

            // Act
            double tax = payCalculator.CalculateTax(grossPay, taxThreshold);

            // Assert
            Assert.AreEqual(15.01, tax);


            // Arrange
            payCalculator = new PayCalculator();
            grossPay = 370; //2nd bracket
            taxThreshold = "No Threshold";

            // Act
            tax = payCalculator.CalculateTax(grossPay, taxThreshold);

            // Assert
            Assert.AreEqual(82.9121, tax, 0.0001);

            // Arrange
            payCalculator = new PayCalculator();
            grossPay = 500; //3rd bracket
            taxThreshold = "No Threshold";

            // Act
            tax = payCalculator.CalculateTax(grossPay, taxThreshold);

            // Assert
            Assert.AreEqual(107.5997, tax, 0.0001);

            // Arrange
            payCalculator = new PayCalculator();
            grossPay = 900; //4th bracket
            taxThreshold = "No Threshold";

            // Act
            tax = payCalculator.CalculateTax(grossPay, taxThreshold);

            // Assert
            Assert.AreEqual(248.5003, tax, 0.0001);

            // Arrange
            payCalculator = new PayCalculator();
            grossPay = 1800; //5th bracket
            taxThreshold = "No Threshold";

            // Act
            tax = payCalculator.CalculateTax(grossPay, taxThreshold);

            // Assert
            Assert.AreEqual(559.0868, tax, 0.0001);

            // Arrange
            payCalculator = new PayCalculator();
            grossPay = 2700; //6th bracket
            taxThreshold = "No Threshold";

            // Act
            tax = payCalculator.CalculateTax(grossPay, taxThreshold);

            // Assert
            Assert.AreEqual(902.9907, tax, 0.0001);

            // Arrange
            payCalculator = new PayCalculator();
            grossPay = 3200; //7th bracket
            taxThreshold = "No Threshold";

            // Act
            tax = payCalculator.CalculateTax(grossPay, taxThreshold);

            // Assert
            Assert.AreEqual(1105.0676, tax, 0.0001);

        }

        
        

    }
}

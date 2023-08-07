using EmployeeLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee()
            {
                Id = 101,
                FirstName = "Paildar",
                LastName = "Shankar",
                Salary = 60000
            };
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream("C:\\Users\\basan\\OneDrive\\Desktop\\Assignment24of C#\\employee.bin", FileMode.Create))
            {
                binaryFormatter.Serialize(file, emp);
            }
            Console.WriteLine("Binary File Serialized");
            Employee DeEmp;
            using (FileStream file = new FileStream("C:\\Users\\basan\\OneDrive\\Desktop\\Assignment24of C#\\employee.bin", FileMode.Open))
            {
                DeEmp = (Employee)binaryFormatter.Deserialize(file);
            }
            Console.WriteLine("Binary File Deserialized\n");
            Console.WriteLine($"Id : {DeEmp.Id}\nFirst Name : {DeEmp.FirstName}\nLast Name : {DeEmp.LastName}\nSalary : {DeEmp.Salary}");
            Console.WriteLine("\n\n======================================================================================================================\n\n");
            Employee employee = new Employee()
            {
                Id = 102,
                FirstName = "Virat",
                LastName = "Kohli",
                Salary = 30000
            };
            XmlSerializer xml = new XmlSerializer(typeof(Employee));
            using (FileStream file = new FileStream("C:\\Users\\basan\\OneDrive\\Desktop\\Assignment24of C#\\employee.xml", FileMode.Create))
            {
                xml.Serialize(file, employee);
            }
            Console.WriteLine("XMl File Serialized");
            Employee DeEmployee;
            using (FileStream file = new FileStream("C:\\Users\\basan\\OneDrive\\Desktop\\Assignment24of C#\\employee.xml", FileMode.Open))
            {
                DeEmployee = (Employee)xml.Deserialize(file);
            }
            Console.WriteLine("XML File Deserialized");
            Console.WriteLine($"\nId : {DeEmployee.Id}\nFirst Name : {DeEmployee.FirstName}\nLast Name : {DeEmployee.LastName}\nSalary : {DeEmployee.Salary}\n");
        }
    }
}

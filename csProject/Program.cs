using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MainProgram {
    class Program {
        public static void Main(string[] args) {
            List<StaffSpace.Staff> myStaff = new List<StaffSpace.Staff>();
            FileReaderSpace.FileReader fr = new FileReaderSpace.FileReader();
            int month = 0;
            int year = 0;

            while (year == 0) {
                System.Console.Write("\nPleas enter the year : ");
                try {
                    year = Convert.ToInt32(System.Console.ReadLine());
                } catch (Exception e) {
                    System.Console.Write(e.Message + "Pleas try again!");
                }
            }
            
            while (month == 0) {
                System.Console.Write("\n Pleas enter the month : ");
                try {
                    month = Convert.ToInt32(System.Console.ReadLine());
                    if (month < 1 || month > 12) {
                        System.Console.Write("Month must be less than 12 and greater than 1");
                        month = 0;
                    }
                } catch (Exception e) {
                    System.Console.WriteLine(e.Message + "Pleas try again!");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; ++i) {
                try {
                    System.Console.Write("Enter hours of work for {0} ", myStaff[i].NameOfStaff + " ");
                    myStaff[i].HoursWorked = Convert.ToInt32(System.Console.ReadLine());
                    myStaff[i].CalculatePay();
                    System.Console.WriteLine(myStaff[i].ToString());
                } catch (Exception e) {
                    System.Console.WriteLine(e.Message);
                    --i;
                }
            }
            PaySlipSpace.PaySlip ps = new PaySlipSpace.PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenereateSummary(myStaff);
        }
    }
}
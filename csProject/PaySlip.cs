using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PaySlipSpace {

    public class PaySlip {
        private int month;
        private int year;

        enum MonthOfYear {
            JAN = 1,
            FAB,
            MART,
            APRIL,
            MAY,
            JUN,
            JULY,
            OGUST,
            SEP,
            OCT,
            NOV,
            DEC
        };

        public PaySlip(int m, int y) {
            month = m;
            year = y;
        }

        public void GeneratePaySlip(List<StaffSpace.Staff> myStaff) {
            string path = "";
            foreach (StaffSpace.Staff f in myStaff) {
                path += f.NameOfStaff + ".txt";
                
                using (StreamWriter sw = new StreamWriter(path)) {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthOfYear)month, year);
                    sw.WriteLine("====================");
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                    if (f.GetType() == typeof(ManagerSpace.Manager)) {
                        sw.WriteLine("Allowance: {0:C}", ((ManagerSpace.Manager)f).Allowance);
                    }
                    else if (f.GetType() == typeof(AdminSpace.Admin)) {
                        sw.WriteLine("Overtime: {0:C}", ((AdminSpace.Admin)f).Overtime);
                    }
                    sw.WriteLine("");
                    sw.WriteLine("====================");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("====================");
                    path = "";
                    sw.Close();
                }
            }
        }

        public void GenereateSummary(List<StaffSpace.Staff> myStaff) {
            var result =
                from f in myStaff
                where f.HoursWorked < 10
                orderby f.NameOfStaff ascending
                select new { f.NameOfStaff, f.HoursWorked };

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path)) {
                foreach (var f in result) {
                    sw.WriteLine("Name of Staff : {0} \n Hours Worked : {1} ", f.NameOfStaff, f.HoursWorked);
                }
                sw.Close();
            }            
        }

        public override string ToString() {
            return " Mothe : " + this.month + '\n' + " Year : " + this.year + '\n'; 
        }
    }
}
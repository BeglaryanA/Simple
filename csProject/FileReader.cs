using System.Security.AccessControl;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileReaderSpace {
    public class FileReader {

        public List<StaffSpace.Staff> ReadFile() {
            List<StaffSpace.Staff> myStaff = new List<StaffSpace.Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string separator = ", ";
            if (File.Exists(path)) {
                using (StreamReader sr = new StreamReader(path)) {
                    while (!sr.EndOfStream) {
                        result = sr.ReadLine().Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                        if (result[1] == "Manager") {
                            myStaff.Add(new ManagerSpace.Manager(result[0]));
                        } else if (result[1] == "Admin") {
                            myStaff.Add(new AdminSpace.Admin(result[0]));
                        } 
                    }
                    sr.Close();
                }
            }
            return myStaff;
            
        }
    }
}
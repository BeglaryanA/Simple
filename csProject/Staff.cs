namespace StaffSpace
{
    public class Staff {

        private float hourlyRate;
        private int hWorked;
        

        public float TotalPay {get; protected set; }
        public float BasicPay {get; private set; }
        public string NameOfStaff {get; private set; }

        public int HoursWorked {
            get {
                return hWorked;
            } 
            set {
                if (value > 0) {
                    hWorked = value;
                } else {
                    hWorked = 0;
                }
            }
        }

        public Staff(string name, float rate) {
            this.NameOfStaff = name;
            this.hourlyRate = rate;
        }

        public virtual void CalculatePay() {
            System.Console.WriteLine("Caculating Pay ...");
            this.BasicPay = hWorked * hourlyRate;
            this.TotalPay = this.BasicPay;
        }

        public override string ToString() {
            return " Name : " + this.NameOfStaff + '\n' 
                    + "Hours Worked : " + this.HoursWorked + '\n'
                    + "Hourly Rate : " + this.hourlyRate + '\n'
                    + "Total Pay : " + this.TotalPay + '\n'
                    + "Basic Pay : " + this.BasicPay; 
        }
    };
}
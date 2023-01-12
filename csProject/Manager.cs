namespace ManagerSpace {
    public class Manager : StaffSpace.Staff {
        private const float managerHourlyRate = 50;

        public int Allowance {get; private set; }

        public Manager(string name) 
        : base(name, managerHourlyRate)
        {}

        public override void CalculatePay() {
            base.CalculatePay();
            this.Allowance = 1000;
            if (HoursWorked > 160) {
                TotalPay = BasicPay + Allowance;
            }   
        }

        public override string ToString() {
             return "Name : " + base.NameOfStaff + '\n' 
                    + "Hours Worked : " + base.HoursWorked + '\n'
                    + "Total Pay : " + base.TotalPay + '\n'
                    + "Basic Pay : " + base.BasicPay + '\n'
                    + "Allownace : " + this.Allowance;
        }
    }
}
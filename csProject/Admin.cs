namespace AdminSpace {
    public class Admin : StaffSpace.Staff {
        private float overtimeRate = 15.5f;
        private static float adminHourlyRate = 30f;

        public float Overtime {get; private set; }
    
        public Admin(string name) 
        : base(name, adminHourlyRate)
        {}

        public override void CalculatePay() {
            base.CalculatePay();

            if (HoursWorked > 160) {
                Overtime = overtimeRate * (HoursWorked - 160);
            }
        }
    }
}
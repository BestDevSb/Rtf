namespace RtfWebApp.Models
{
    public class SolutionRecomendedEmployees
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int SolutionId { get; set; }
        public double RateSum { get; set; }
        public double WeightSum { get; set; }
    }
}

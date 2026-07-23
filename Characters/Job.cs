public class Job
{
    public string Name { get; set; } = "Unknown";
    public string Category { get; set; } = "General";

    public string Title { get; set; } = "";
    public string PayTier { get; set; } = "Low"; // Low, Mid, High, SuperHigh, Unemployed

    public decimal WeeklyIncome { get; set; }

    public int BaseStress { get; set; }          // general stress of job
    public int PhysicalFatigue { get; set; }     // body drain
    public int MentalFatigue { get; set; }       // mind drain

    public string Workplace { get; set; } = "";

    public List<JobShift> Shifts { get; set; } = new(); // multiple shifts
}
public class JobShift
{
    public int StartHour { get; set; }
    public int EndHour { get; set; }
}


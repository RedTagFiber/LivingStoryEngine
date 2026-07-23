using System.Text.Json;

namespace LivingStoryEngine.Characters
{
    /// <summary>
    /// Loads jobs from jobs.json and provides safe access to them.
    /// Prevents crashes if the job list is empty or fails to load.
    /// </summary>
    public static class JobDatabase
    {
        private static readonly Random rng = new();

        // This is where all jobs will be stored after loading.
        public static List<Job> Jobs { get; private set; } = new();

        // ============================================================
        //  LOAD JOBS FROM JSON
        // ============================================================
        public static void LoadJobs()
        {
            try
            {
                // Path to your jobs.json file
                string path = "Characters/jobs.json";

                if (!File.Exists(path))
                {
                    Console.WriteLine("WARNING: jobs.json not found. Using fallback job.");
                    AddFallbackJob();
                    return;
                }

                string json = File.ReadAllText(path);

                // Deserialize JSON into job list
                Jobs = JsonSerializer.Deserialize<List<Job>>(json);

                // If JSON loads but contains zero jobs
                if (Jobs == null || Jobs.Count == 0)
                {
                    Console.WriteLine("WARNING: jobs.json is empty. Using fallback job.");
                    AddFallbackJob();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR loading jobs.json: " + ex.Message);
                AddFallbackJob();
            }
        }

        // ============================================================
        //  GET RANDOM JOB (SAFE)
        // ============================================================
        public static Job GetRandomJob()
        {
            // If jobs failed to load, use fallback
            if (Jobs == null || Jobs.Count == 0)
            {
                AddFallbackJob();
            }

            // Pick a random job safely
            int index = rng.Next(Jobs.Count);
            return Jobs[index];
        }

        // ============================================================
        //  FALLBACK JOB (PREVENTS CRASH)
        // ============================================================
        private static void AddFallbackJob()
        {
            Jobs = new List<Job>
            {
                new Job
                {
                    Name = "Unemployed",
                    BaseStress = 5,
                    PhysicalFatigue = 2,
                    MentalFatigue = 3,
                    Shifts = new List<JobShift>
                    {
                        // No working hours
                        new JobShift { StartHour = 0, EndHour = 0 }
                    }
                }
            };

            Console.WriteLine("Fallback job added: Unemployed");
        }
    }
}

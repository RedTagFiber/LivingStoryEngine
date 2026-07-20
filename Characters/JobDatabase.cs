using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LivingStoryEngine.Systems
{
    public static class JobDatabase
    {
        public static List<Job> Jobs { get; private set; } = new();

        public static void LoadJobs()
        {
            string json = File.ReadAllText("jobs.json");
            Jobs = JsonSerializer.Deserialize<List<Job>>(json) ?? new List<Job>();

        }

        public static Job GetRandomJob()
        {
            Random r = new Random();
            return Jobs[r.Next(Jobs.Count)];
        }
    }
}

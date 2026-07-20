using LivingStoryEngine.Characters;
using LivingStoryEngine.Systems;
using System.Linq;

namespace LivingStoryEngine.Systems
{
    public static class SleepSystem
    {
        public static bool ShouldSleep(Character c, int hour)
        {
            bool isNight = hour >= 0 && hour <= 6;
            bool exhausted = c.Energy < 30;

            bool workingNow = c.Job?.Shifts.Any(s => IsWorkingHour(c.Job, hour)) ?? false;

            return (isNight || exhausted) && !workingNow;
        }

        public static void ApplySleep(Character c)
        {
            c.Energy += 8;
            c.Stress.Value -= 3;

            c.Energy = Math.Clamp(c.Energy, 0, 100);
            c.Stress.Value = Math.Clamp(c.Stress.Value, 0, 100);
        }

        public static bool IsWorkingHour(Job job, int hour)
        {
            foreach (var shift in job.Shifts)
            {
                if (shift.StartHour < shift.EndHour)
                {
                    if (hour >= shift.StartHour && hour < shift.EndHour)
                        return true;
                }
                else
                {
                    if (hour >= shift.StartHour || hour < shift.EndHour)
                        return true;
                }
            }

            return false;
        }
    }
}

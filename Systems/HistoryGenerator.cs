using LivingStoryEngine.Managers;
using LivingStoryEngine.Models;

namespace LivingStoryEngine.Systems;

public static class HistoryGenerator
{
    private static readonly Random Random =
        new();

    public static List<HistoryRecord>
        Generate(int currentAge)
    {
        var history =
            new List<HistoryRecord>();

        Console.WriteLine(
            $"History Events Available: {HistoryEventManager.Events.Count}"
        );

        if (HistoryEventManager.Events.Count == 0)
        {
            Console.WriteLine(
                "WARNING: No history events loaded."
            );

            return history;
        }

        int eventCount =
     Math.Max(8, currentAge / 3);

        var usedEvents =
            new HashSet<string>();

        for (int i = 0; i < eventCount; i++)
        {
            int age =
                Random.Next(
                    5,
                    currentAge + 1
                );

            var selectedEvent =
                HistoryEventManager
                    .GetRandomEventForAge(age);

            if (selectedEvent == null)
            {
                continue;
            }

            if (usedEvents.Contains(
                    selectedEvent.Name))
            {
                continue;
            }

            usedEvents.Add(
                selectedEvent.Name);

            history.Add(
                new HistoryRecord
                {
                    Age = age,

                    Category =
                        selectedEvent.Category,

                    Event =
                        selectedEvent.Name,

                    Description =
                        $"{selectedEvent.Category} event.",

                    GrantedTraits =
    selectedEvent.Polarity == "Neutral"
        ? new List<string>()
        : selectedEvent.Traits.ToList()
                });
        }

        // =====================================================
        // WILDCARD EVENT ROLL
        // =====================================================

        int wildcardRoll =
            Random.Next(1000);

        if (wildcardRoll < 5) // 0.5% chance
        {
            var wildcardEvent =
                HistoryEventManager
                    .GetRandomWildcardEvent();

            if (wildcardEvent != null)
            {
                history.Add(
                    new HistoryRecord
                    {
                        Age = Random.Next(
                            5,
                            currentAge + 1
                        ),

                        Category =
                            wildcardEvent.Category,

                        Event =
                            wildcardEvent.Name,

                        Description =
                            wildcardEvent.Description,

                        GrantedTraits =
                            wildcardEvent.Traits
                                .ToList()
                    });

                Console.WriteLine(
                    $"WILDCARD GENERATED: {wildcardEvent.Name}"
                );
            }
        }

        Console.WriteLine(
            $"Generated History Records: {history.Count}"
        );

        return history
            .OrderBy(h => h.Age)
            .ToList();

    }
}
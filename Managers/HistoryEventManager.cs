using System.Text.Json;
using LivingStoryEngine.Models;

namespace LivingStoryEngine.Managers;

public static class HistoryEventManager
{
    private static readonly List<HistoryEventDefinition>
        _events = new();

    public static IReadOnlyList<HistoryEventDefinition>
        Events => _events;

    // =====================================================
    // LOAD EVENTS
    // =====================================================

    public static void Load()
    {
        string filePath =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "HistoryEvents.json"
            );

        if (!File.Exists(filePath))
        {
            Console.WriteLine(
                $"History file not found: {filePath}"
            );

            return;
        }

        string json =
            File.ReadAllText(filePath);

        var loadedEvents =
    JsonSerializer.Deserialize<
    List<HistoryEventDefinition>
>(
    json,
    new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling =
            JsonCommentHandling.Skip
    }

    );

        _events.Clear();

        if (loadedEvents != null)
        {
            _events.AddRange(loadedEvents);
        }

        Console.WriteLine(
            $"Loaded {_events.Count} history events."
        );
    }

    // =====================================================
    // RANDOM EVENT FOR AGE
    // =====================================================

    public static HistoryEventDefinition?
        GetRandomEventForAge(int age)
    {
        var validEvents =
            _events
                .Where(e =>
                    age >= e.MinAge &&
                    age <= e.MaxAge)
                .ToList();

        if (validEvents.Count == 0)
        {
            return null;
        }

        return validEvents[
            Random.Shared.Next(
                validEvents.Count
            )
        ];
    }

    // =====================================================
    // ALL EVENTS FOR AGE
    // =====================================================

    public static List<HistoryEventDefinition>
        GetEventsForAge(int age)
    {
        return _events
            .Where(e =>
                age >= e.MinAge &&
                age <= e.MaxAge)
            .ToList();
    }

    // =====================================================
    // DEBUG
    // =====================================================

    public static void PrintAll()
    {
        Console.WriteLine();
        Console.WriteLine(
            "===== HISTORY EVENTS ====="
        );

        foreach (var historyEvent in _events)
        {
            Console.WriteLine(
                $"{historyEvent.Name} " +
                $"({historyEvent.Category})"
            );
        }

        Console.WriteLine();
        Console.WriteLine(
            $"Total Events: {_events.Count}"
        ); 
    }
        public static HistoryEventDefinition?
    GetRandomWildcardEvent()
    {
        var wildcardEvents =
            _events
                .Where(e =>
                    e.Category == "Wildcard")
                .ToList();

        if (wildcardEvents.Count == 0)
        {
            return null;
        }

        return wildcardEvents[
            Random.Shared.Next(
                wildcardEvents.Count)
        ];
    }
}

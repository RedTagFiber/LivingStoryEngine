using LivingStoryEngine.Characters;
using LivingStoryEngine.Managers;
using LivingStoryEngine.Systems;

internal class Program
{
    private static void Main(string[] args)
    {
        HistoryEventManager.Load();
        Console.WriteLine();
        Console.WriteLine("===== HISTORY EVENTS DEBUG =====");

        Console.WriteLine(
            $"Events Loaded: {HistoryEventManager.Events.Count}"
        );

        foreach (var e in HistoryEventManager.Events)
        {
            Console.WriteLine(
                $"{e.Name} | {e.Category} | {e.MinAge}-{e.MaxAge}"
            );
        }

        Console.WriteLine();
        // =====================================================
        // INITIALIZATION
        // =====================================================

        SpecialTraitManager.LoadAll();

        int day = 1;
        decimal money = 500;

        var eve = CharacterFactory.CreateEve();

        // =====================================================
        // MAIN GAME LOOP
        // =====================================================

        while (true)
        {
            eve.UpdateRelationshipStatus();

            Console.Clear();

            // =====================================================
            // HEADER
            // =====================================================

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("================================================");
            Console.WriteLine("         LIVING STORY ENGINE DEBUG");
            Console.WriteLine("================================================");

            Console.ResetColor();

            // =====================================================
            // RELATIONSHIP SECTION
            // =====================================================

            Console.ForegroundColor = GetRelationshipColor(
                eve.RelationshipStatus);

            Console.WriteLine(
                $"Relationship: {eve.RelationshipStatus}");

            Console.ResetColor();

            Console.WriteLine(
                $"Dates Together: {eve.DatesCompleted}");

            Console.WriteLine(
                $"Mood: {GetEveMood(eve)}");

            Console.WriteLine(
                $"Next Stage: {GetNextStage(eve)}");

            Console.WriteLine(
                $"Love Until Next Stage: {GetLoveRequired(eve)}");

            Console.WriteLine();

            // =====================================================
            // THOUGHTS
            // =====================================================

            Console.WriteLine("Eve's Thoughts");
            Console.WriteLine("--------------");

            Console.WriteLine(
                GetThought(eve));

            Console.WriteLine();

            // =====================================================
            // METERS
            // =====================================================

            Console.WriteLine(
                $"Love       {MakeMeter(eve.Love)}");

            Console.WriteLine(
                $"Trust      {MakeMeter(eve.TrustLevel)}");

            Console.WriteLine(
                $"Happiness  {MakeMeter(eve.Happiness)}");

            Console.WriteLine(
                $"Energy     {MakeMeter(eve.Energy)}");

            Console.WriteLine();

            // =====================================================
            // DAY / MONEY
            // =====================================================

            Console.WriteLine($"Day: {day}");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Wallet: ${money}");

            Console.ResetColor();

            Console.WriteLine();

            // =====================================================
            // CHARACTER INFO
            // =====================================================

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("EVE STATUS");

            Console.ResetColor();

            Console.WriteLine($"Name: {eve.Name}");
            Console.WriteLine($"Location: {eve.Location}");

            Console.WriteLine();

            // =====================================================
            // PERSONALITY
            // =====================================================

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("PERSONALITY PROFILE");

            Console.ResetColor();

            if (eve.GetModifier("Romanticism") > 0.30)
                Console.WriteLine("✓ Highly Romantic");

            if (eve.GetModifier("Commitment") > 0.40)
                Console.WriteLine("✓ Long-Term Relationship Focused");

            if (eve.GetModifier("Trust") > 0.20)
                Console.WriteLine("✓ Trusting Personality");

            if (eve.GetModifier("Loyalty") > 0.40)
                Console.WriteLine("✓ Extremely Loyal");

            Console.WriteLine();

            // =====================================================
            // DECISION ENGINE
            // =====================================================

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("CURRENT DECISION");

            Console.ResetColor();

            Console.WriteLine(
                DecisionEngine.DecideRelationshipAction(eve));

            Console.WriteLine();

            // =====================================================
            // MENU
            // =====================================================

            Console.WriteLine("1. Ryan Helps Eve");
            Console.WriteLine("2. Ryan Ignores Eve");
            Console.WriteLine("3. Buy Flowers ($25)");
            Console.WriteLine("4. Buy Chocolate ($50)");
            Console.WriteLine("5. Go On Date ($100)");
            Console.WriteLine("6. Character Information");
            Console.WriteLine("7. Debug Trait Effects");
            Console.WriteLine("8. Sleep");
            Console.WriteLine("9. Exit");
            Console.WriteLine("10. View Life History");
            Console.WriteLine("11. Personality Report");
            Console.WriteLine();

            Console.Write("Choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    eve.Love += 5;
                    eve.TrustLevel += 10;
                    eve.Happiness += 5;

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine();
                    Console.WriteLine("Ryan helped Eve.");

                    Console.WriteLine(
                        "\"I knew I could count on you.\"");

                    Console.ResetColor();

                    break;

                case "2":

                    eve.Love -= 3;
                    eve.TrustLevel -= 5;
                    eve.Happiness -= 5;

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine();
                    Console.WriteLine("Ryan ignored Eve.");

                    Console.WriteLine(
                        "\"...Okay.\"");

                    Console.ResetColor();

                    break;

                case "3":

                    if (money >= 25)
                    {
                        money -= 25;

                        eve.Love += 5;
                        eve.Happiness += 10;

                        Console.ForegroundColor =
                            ConsoleColor.Magenta;

                        Console.WriteLine();
                        Console.WriteLine(
                            "Ryan gave Eve flowers.");

                        Console.WriteLine(
                            GetFlowerReaction(eve));

                        Console.WriteLine();
                        Console.WriteLine(
                            $"Money Left: ${money}");

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(
                            "Not enough money.");
                    }

                    break;

                case "4":

                    if (money >= 50)
                    {
                        money -= 50;

                        eve.Love += 8;
                        eve.Happiness += 12;

                        Console.WriteLine();
                        Console.WriteLine(
                            "Ryan gave Eve chocolates.");

                        Console.WriteLine(
                            $"Money Left: ${money}");
                    }
                    else
                    {
                        Console.WriteLine(
                            "Not enough money.");
                    }

                    break;

                case "5":

                    if (money >= 100)
                    {
                        money -= 100;

                        eve.Love += 15;
                        eve.TrustLevel += 5;
                        eve.Happiness += 15;

                        eve.DatesCompleted++;

                        Console.ForegroundColor =
                            ConsoleColor.Magenta;

                        Console.WriteLine();
                        Console.WriteLine(
                            "Ryan took Eve on a date.");

                        Console.WriteLine(
                            "\"I had a wonderful time with you today.\"");

                        Console.WriteLine();

                        Console.WriteLine(
                            $"Love: {eve.Love}");

                        Console.WriteLine(
                            $"Trust: {eve.TrustLevel}");

                        Console.WriteLine(
                            $"Happiness: {eve.Happiness}");

                        Console.WriteLine(
                            $"Money Left: ${money}");

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(
                            "Not enough money.");
                    }

                    break;

                case "6":

                    Console.Clear();

                    Console.WriteLine(
                        "CHARACTER INFORMATION");

                    Console.WriteLine();

                    Console.WriteLine(
                        $"Name: {eve.Name}");

                    Console.WriteLine(
                        $"Goal: {eve.Goal}");

                    Console.WriteLine(
                        $"Need: {eve.Need}");

                    Console.WriteLine(
                        $"Fear: {eve.Fear}");

                    Console.WriteLine(
                        $"Want: {eve.Want}");

                    Console.WriteLine();

                    foreach (var trait in eve.SpecialTraits)
                    {
                        Console.WriteLine($"- {trait}");
                    }

                    Console.ReadKey();

                    break;

                case "7":

                    Console.Clear();

                    Console.WriteLine(
                        "DEBUG TRAIT EFFECTS");

                    Console.WriteLine();

                    foreach (var modifier in eve.TraitModifiers)
                    {
                        Console.WriteLine(
                            $"{modifier.Key}: {modifier.Value:+0.00;-0.00}");
                    }

                    Console.ReadKey();

                    break;

                case "8":

                    day++;

                    eve.Energy = 100;

                    money += 75;

                    Console.WriteLine();
                    Console.WriteLine(
                        "Sleep Complete");

                    Console.WriteLine(
                        "+$75 Salary Earned");

                    break;

                case "9":

                    return;

                case "10":

                    Console.Clear();

                    Console.WriteLine("LIFE HISTORY");
                    Console.WriteLine("------------");

                    foreach (var record in eve.History)
                    {
                        Console.WriteLine(
                            $"Age {record.Age} - [{record.Category}] {record.Event}");

                        Console.WriteLine(
                            $"    {record.Description}");

                        Console.WriteLine();
                    }

                    Console.ReadKey();

                    break;

                default:

                    Console.WriteLine(
                        "Invalid choice.");

                    break;
                case "11":

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("================================");
                    Console.WriteLine("PERSONALITY REPORT");
                    Console.WriteLine("================================");
                    Console.ResetColor();

                    Console.WriteLine();
                    Console.WriteLine($"Name: {eve.Name}");

                    Console.WriteLine();
                    Console.WriteLine("HISTORY");
                    Console.WriteLine("-------");

                    foreach (var record in eve.History)
                    {
                        Console.WriteLine(
                            $"Age {record.Age} - {record.Event}"
                        );
                    }

                    Console.WriteLine();
                  


                    Console.WriteLine("SPECIAL TRAITS");
                    Console.WriteLine("--------------");

                    foreach (var trait in eve.SpecialTraits)
                    {
                        Console.WriteLine($"- {trait}");
                    }

                    Console.WriteLine();

                    Console.WriteLine("TRAIT MODIFIERS");
                    Console.WriteLine("---------------");

                    foreach (var modifier in eve.TraitModifiers)
                    {
                        Console.WriteLine(
                            $"{modifier.Key}: {modifier.Value:+0.00;-0.00}"
                        );
                    }

                    Console.WriteLine();

                    Console.WriteLine("CURRENT DECISION");
                    Console.WriteLine("----------------");

                    Console.WriteLine(
                        DecisionEngine.DecideRelationshipAction(eve)
                    );
                    Console.WriteLine();
                    Console.WriteLine("LIFE EVENT DETAILS");
                    Console.WriteLine("------------------");

                    foreach (var record in eve.History)
                    {
                        Console.WriteLine(
                            $"Age {record.Age} - {record.Event}"
                        );

                        Console.WriteLine(
                            $"    {record.Description}"
                        );

                        foreach (var trait in record.GrantedTraits)
                        {
                            Console.WriteLine(
                                $"    + {trait}"
                            );
                        }

                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();

                    break;
            }

            // =====================================================
            // CLAMP STATS
            // =====================================================

            eve.Love =
                Math.Clamp(eve.Love, 0, 100);

            eve.TrustLevel =
                Math.Clamp(eve.TrustLevel, 0, 100);

            eve.Happiness =
                Math.Clamp(eve.Happiness, 0, 100);

            eve.Energy =
                Math.Clamp(eve.Energy, 0, 100);

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }

    // =====================================================
    // HELPER METHODS
    // =====================================================

    static string GetEveMood(Character eve)
    {
        if (eve.Happiness >= 80)
            return "Very Happy";

        if (eve.Happiness >= 60)
            return "Happy";

        if (eve.Happiness >= 40)
            return "Neutral";

        if (eve.Happiness >= 20)
            return "Upset";

        return "Very Upset";
    }

    static int GetLoveRequired(Character eve)
    {
        if (eve.Love < 25)
            return 25 - eve.Love;

        if (eve.Love < 50)
            return 50 - eve.Love;

        if (eve.Love < 75)
            return 75 - eve.Love;

        if (eve.Love < 90)
            return 90 - eve.Love;

        return 0;
    }

    static string GetNextStage(Character eve)
    {
        if (eve.Love < 25)
            return "Friends";

        if (eve.Love < 50)
            return "Interested";

        if (eve.Love < 75)
            return "Dating";

        if (eve.Love < 90)
            return "Soulmates";

        return "Maximum";
    }

    static string GetFlowerReaction(Character eve)
    {
        if (eve.Love >= 75)
            return "\"You always know how to make me smile.\"";

        if (eve.Love >= 50)
            return "\"These are beautiful.\"";

        if (eve.Love >= 25)
            return "\"Aww, thank you!\"";

        return "\"That's very thoughtful.\"";
    }

    static string GetThought(Character eve)
    {
        if (eve.Love >= 90)
            return "Ryan means everything to me.";

        if (eve.Love >= 75)
            return "I can't wait to see Ryan again.";

        if (eve.Love >= 50)
            return "I'm starting to develop real feelings.";

        if (eve.Love >= 25)
            return "Ryan is becoming important to me.";

        return "I barely know Ryan.";
    }

    static ConsoleColor GetRelationshipColor(
        string relationship)
    {
        return relationship switch
        {
            "Soulmates" => ConsoleColor.Magenta,
            "Dating" => ConsoleColor.Green,
            "Interested" => ConsoleColor.Yellow,
            "Friends" => ConsoleColor.Cyan,
            _ => ConsoleColor.Gray
        };
    }

    static string MakeMeter(int value)
    {
        int bars = value / 10;

        return
            "[" +
            new string('#', bars) +
            new string('-', 10 - bars) +
            $"] {value}";
    }
}
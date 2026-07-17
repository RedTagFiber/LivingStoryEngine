using LivingStoryEngine.Characters;
using LivingStoryEngine.Managers;
using LivingStoryEngine.Systems;

SpecialTraitManager.LoadAll();

int day = 1;
decimal money = 500;

var eve = CharacterFactory.CreateEve();
eve.DatesCompleted++;
while (true)
{
    eve.UpdateRelationshipStatus();

    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("================================================");
    Console.WriteLine("           LIVING STORY ENGINE DEBUG");
    Console.WriteLine("================================================");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(
        $"Relationship: {eve.RelationshipStatus}"
    );
    Console.WriteLine(
    $"Dates Together: {eve.DatesCompleted}"
);
    Console.ResetColor();
    Console.WriteLine($"Mood: {GetEveMood(eve)}");

    Console.WriteLine(
        $"Love Until Next Stage: {GetLoveRequired(eve)}"
    );

    Console.WriteLine();
    Console.WriteLine($"Love      {MakeMeter(eve.Love)}");
    Console.WriteLine($"Trust     {MakeMeter(eve.TrustLevel)}");
    Console.WriteLine($"Happiness {MakeMeter(eve.Happiness)}");
    Console.WriteLine($"Energy    {MakeMeter(eve.Energy)}");
    Console.WriteLine($"Day: {day}");
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine($"Wallet: ${money}");

    Console.ResetColor();
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("EVE STATUS");
    Console.ResetColor();

    Console.WriteLine($"Name: {eve.Name}");
    Console.WriteLine($"Location: {eve.Location}");
    Console.WriteLine($"Relationship: {eve.RelationshipStatus}");
    Console.WriteLine();
    Console.ForegroundColor = eve.RelationshipStatus switch
    {
        "Soulmates" => ConsoleColor.Magenta,
        "Dating" => ConsoleColor.Green,
        "Interested" => ConsoleColor.Yellow,
        "Friends" => ConsoleColor.Cyan,
        _ => ConsoleColor.Gray,
    };
    Console.WriteLine();
    Console.WriteLine("Relationship Progress");

    Console.WriteLine(
        MakeMeter(eve.Love)
    );

    Console.ResetColor();
    Console.WriteLine($"Love       {MakeMeter(eve.Love)}");
    Console.WriteLine($"Trust      {MakeMeter(eve.TrustLevel)}");
    Console.WriteLine($"Happiness  {MakeMeter(eve.Happiness)}");
    Console.WriteLine($"Energy     {MakeMeter(eve.Energy)}");

    Console.WriteLine();

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

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("CURRENT DECISION");
    Console.ResetColor();

    Console.WriteLine(
        DecisionEngine.DecideRelationshipAction(eve)
    );

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("ACTIONS");
    Console.ResetColor();

    Console.WriteLine("1. Ryan Helps Eve");
    Console.WriteLine("2. Ryan Ignores Eve");
    Console.WriteLine("3. Buy Flowers ($25)");
    Console.WriteLine("4. Buy Chocolate ($50)");
    Console.WriteLine("5. Go On Date ($100)");
    Console.WriteLine("6. Character Information");
    Console.WriteLine("7. Debug Trait Effects");
    Console.WriteLine("8. Sleep");
    Console.WriteLine("9. Exit");

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

            Console.WriteLine("Ryan helped Eve.");
            Console.WriteLine();

            Console.WriteLine("Eve Reaction:");
            Console.WriteLine("\"I knew I could count on you.\"");

            Console.WriteLine();

            Console.WriteLine("+5 Love");
            Console.WriteLine("+10 Trust");
            Console.WriteLine("+5 Happiness");

            Console.WriteLine();

            Console.WriteLine($"Love: {eve.Love}");
            Console.WriteLine($"Trust: {eve.TrustLevel}");
            Console.WriteLine($"Happiness: {eve.Happiness}");

            Console.ResetColor();

            break;

        case "2":

            eve.Love -= 3;
            eve.TrustLevel -= 5;
            eve.Happiness -= 5;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Ryan ignored Eve.");
            Console.WriteLine();

            Console.WriteLine("Eve Reaction:");
            Console.WriteLine("\"...Okay.\"");

            Console.WriteLine();

            Console.WriteLine("-3 Love");
            Console.WriteLine("-5 Trust");
            Console.WriteLine("-5 Happiness");

            Console.WriteLine();

            Console.WriteLine($"Love: {eve.Love}");
            Console.WriteLine($"Trust: {eve.TrustLevel}");
            Console.WriteLine($"Happiness: {eve.Happiness}");

            Console.ResetColor();

            break;

        case "3":

            if (money >= 25)
            {
                money -= 25;

                eve.Love += 5;
                eve.Happiness += 10;
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("Ryan gave Eve flowers.");
                Console.WriteLine();

                Console.WriteLine("Eve Reaction:");
                Console.WriteLine("\"These are beautiful! Thank you Ryan.\"");

                Console.WriteLine();
                Console.WriteLine("Stat Changes");

                Console.WriteLine("+5 Love");
                Console.WriteLine("+10 Happiness");

                Console.WriteLine();

                Console.WriteLine($"Love: {eve.Love}");
                Console.WriteLine($"Happiness: {eve.Happiness}");
                Console.WriteLine($"Money Left: ${money}");

                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Not enough money.");
            }

            break;

        case "4":

            if (money >= 50)
            {
                money -= 50;

                eve.Love += 8;
                eve.Happiness += 12;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Ryan gave Eve chocolates.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Not enough money.");
            }

            break;

        case "5":

            if (money >= 100)
            {
                money -= 100;

                eve.Love += 15;
                eve.TrustLevel += 5;
                eve.Happiness += 15;

                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("Ryan took Eve on a date.");
                Console.WriteLine();

                Console.WriteLine("Eve Reaction:");
                Console.WriteLine("\"I had a wonderful time with you today.\"");

                Console.WriteLine();
                Console.WriteLine("Stat Changes");

                Console.WriteLine("+15 Love");
                Console.WriteLine("+15 Happiness");
                Console.WriteLine("+5 Trust");

                Console.WriteLine();

                Console.WriteLine($"Love: {eve.Love}");
                Console.WriteLine($"Trust: {eve.TrustLevel}");
                Console.WriteLine($"Happiness: {eve.Happiness}");
                Console.WriteLine($"Money Left: ${money}");

                Console.ResetColor();
                eve.DatesCompleted++;

            }
            else
            {
                Console.WriteLine("Not enough money.");
            }

            break;

        case "6":

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CHARACTER INFORMATION");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine($"Name: {eve.Name}");
            Console.WriteLine($"Goal: {eve.Goal}");
            Console.WriteLine($"Need: {eve.Need}");
            Console.WriteLine($"Fear: {eve.Fear}");
            Console.WriteLine($"Want: {eve.Want}");

            Console.WriteLine();

            Console.WriteLine("Special Traits");

            foreach (var trait in eve.SpecialTraits)
            {
                Console.WriteLine($"- {trait}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            break;

        case "7":

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("DEBUG TRAIT EFFECTS");
            Console.ResetColor();

            Console.WriteLine();

            foreach (var traitName in eve.SpecialTraits)
            {
                var trait =
                    SpecialTraitManager.GetTrait(traitName);

                if (trait == null)
                    continue;

                Console.WriteLine(
                    $"Trait: {trait.Name}"
                );

                Console.WriteLine(
                    $"Category: {trait.Category}"
                );

                Console.WriteLine(
                    $"Description: {trait.Description}"
                );

                Console.WriteLine("Effects:");

                foreach (var effect in trait.Effects)
                {
                    Console.WriteLine(
                        $"  {effect.Key}: {effect.Value:+0.00;-0.00}"
                    );
                }

                Console.WriteLine();
            }

            Console.WriteLine("Combined Modifiers");
            Console.WriteLine("------------------");

            foreach (var modifier in eve.TraitModifiers)
            {
                Console.WriteLine(
                    $"{modifier.Key}: {modifier.Value:+0.00;-0.00}"
                );
            }

            Console.WriteLine();
            Console.WriteLine(
                $"Romanticism = {eve.GetModifier("Romanticism")}"
            );

            Console.WriteLine(
                $"Commitment = {eve.GetModifier("Commitment")}"
            );

            Console.WriteLine(
                $"Trust = {eve.GetModifier("Trust")}"
            );

            Console.WriteLine(
                $"Loyalty = {eve.GetModifier("Loyalty")}"
            );

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            break;

        case "8":

            day++;

            eve.Energy = 100;

            money += 75;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("A new day begins...");
            Console.ResetColor();

            break;

        case "9":

            return;

        default:

            Console.WriteLine("Invalid choice.");
            break;

    }
    Console.WriteLine(GetFlowerReaction(eve));

    Console.WriteLine(
    $"Next Stage: {GetNextStage(eve)}"
);
    eve.Love = Math.Clamp(eve.Love, 0, 100);
    eve.TrustLevel = Math.Clamp(eve.TrustLevel, 0, 100);
    eve.Happiness = Math.Clamp(eve.Happiness, 0, 100);
    eve.Energy = Math.Clamp(eve.Energy, 0, 100);
    Console.WriteLine($"Mood: {GetEveMood(eve)}");
    Console.WriteLine();
    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
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
static string MakeMeter(int value)
{
    int bars = value / 10;

    return
        "[" +
        new string('#', bars) +
        new string('-', 10 - bars) +
        $"] {value}";
}
using LivingStoryEngine;

// Create Eve
var eve = new Character();

eve.Name = "Eve";
// Eve's memories6
List<string> memories = new();
bool running = true;

while (running)
{
    Console.Clear();

    Console.WriteLine("================================");
    Console.WriteLine("      Living Story Engine");
    Console.WriteLine("================================");
    Console.WriteLine();

    Console.WriteLine("1 - Help Eve");
    Console.WriteLine("2 - Ignore Eve");
    Console.WriteLine("3 - Show Relationship");
    Console.WriteLine("4 - Exit");
    Console.WriteLine();

    Console.Write("Choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            eve.Trust += 5;
            eve.Comfort += 3;

            memories.Add("Ryan helped Eve.");

            Console.WriteLine();
            Console.WriteLine("You helped Eve.");
            Console.WriteLine("Trust +5");
            Console.WriteLine("Comfort +3");
            break;

        case "2":

            eve.Resentment += 5;
            eve.Affection -= 3;

            Console.WriteLine();
            Console.WriteLine("You ignored Eve.");
            Console.WriteLine("Resentment +5");
            Console.WriteLine("Affection -3");
            break;

        case "3":

            Console.WriteLine();
            Console.WriteLine("Relationship Stats");
            Console.WriteLine("------------------");

            Console.WriteLine($"Trust:      {eve.Trust}");
            Console.WriteLine($"Comfort:    {eve.Comfort}");
            Console.WriteLine($"Respect:    {eve.Respect}");
            Console.WriteLine($"Affection:  {eve.Affection}");
            Console.WriteLine($"Resentment: {eve.Resentment}");
            break;

        case "4":

            running = false;
            continue;

        default:

            Console.WriteLine();
            Console.WriteLine("Invalid choice.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
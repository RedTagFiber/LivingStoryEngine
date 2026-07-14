using LivingStoryEngine;

                                       // Create Eve
var eve = new Character();

eve.Name = "Eve";
                                     // Eve's memories6

eve.Goal = "Spend time with Ryan";

eve.Need = "Keep her job";

eve.Fear = "Losing people she cares about";

eve.Want = "Go on a date with Ryan";

eve.CurrentDecision = "Thinking";

eve.Thought = "I wonder what today will bring.";



int currentDay = 1;


List<string> memories = new();
                                     
                                      // Eve's timeline
List<string> timeline = new();



bool running = true;

while (running)
{
    Console.Clear();

    Console.WriteLine("================================");
    Console.WriteLine("      Living Story Engine");
    Console.WriteLine("================================");
    Console.WriteLine();
    Console.WriteLine($"Current Day: {currentDay}");
    Console.WriteLine();
    Console.WriteLine("1 - Help Eve");
    Console.WriteLine("2 - Ignore Eve");
    Console.WriteLine("3 - Show Relationship");
    Console.WriteLine("4 - Show Memories");
    Console.WriteLine("5 - Show Timeline");
    Console.WriteLine("6- Debug Info");
    Console.WriteLine("7- Exit");
    
    Console.Write("Choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            eve.Trust += 5;
            eve.Comfort += 3;

            if (eve.Trust >= 70)
            {
                eve.Mood = "Happy";
            }
            else if (eve.Resentment >= 20)
            {
                eve.Mood = "Annoyed";
            }
            else
            {
                eve.Mood = "Neutral";
            }
            if (eve.Trust >= 60)
            {
                eve.Goal = "Spend more time with Ryan";
            }

            eve.CurrentDecision = "Spend time with Ryan";
            eve.Thought = "Ryan has been really supportive lately.";


            memories.Add($"Day {currentDay}: Ryan helped Eve.");

            timeline.Add($"Day {currentDay}: Ryan helped Eve.");

            currentDay++;

            Console.WriteLine();
            Console.WriteLine("You helped Eve.");

            break;

        case "2":

            eve.Resentment += 5;
            eve.Affection -= 3;

            if (eve.Trust >= 70)
            {
                eve.Mood = "Happy";
            }
            else if (eve.Resentment >= 20)
            {
                eve.Mood = "Annoyed";
            }
            else
            {
                eve.Mood = "Neutral";
            }
            if (eve.Resentment >= 20)
            {
                eve.Goal = "Figure out why Ryan is ignoring me";
            }

            eve.CurrentDecision = "Give Ryan some space";
            eve.Thought = "Why has Ryan been ignoring me?";
            memories.Add($"Day {currentDay}: Ryan ignored Eve.");

            timeline.Add($"Day {currentDay}: Ryan ignored Eve.");

            currentDay++;

            Console.WriteLine();
            Console.WriteLine("You ignored Eve.");

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
            Console.WriteLine($"Mood:       {eve.Mood}");
            break;

        case "4":

            Console.WriteLine();
            Console.WriteLine("Memories");
            Console.WriteLine("--------");

            if (memories.Count == 0)
            {
                Console.WriteLine("No memories yet.");
            }
            else
            {
                foreach (var memory in memories)
                {
                    Console.WriteLine(memory);
                }
            }

            break;

        case "5":

            Console.WriteLine();
            Console.WriteLine("Timeline");
            Console.WriteLine("--------");

            foreach (var item in timeline)
            {
                Console.WriteLine(item);
            }

            break;
        case "6":

            Console.WriteLine();
            Console.WriteLine("========== EVE DEBUG ==========");
            Console.WriteLine();

            Console.WriteLine($"Name: {eve.Name}");
            Console.WriteLine($"Mood: {eve.Mood}");
            Console.WriteLine();

            Console.WriteLine($"Current Day: {currentDay}");
            Console.WriteLine();

            Console.WriteLine($"Trust: {eve.Trust}");
            Console.WriteLine($"Comfort: {eve.Comfort}");
            Console.WriteLine($"Respect: {eve.Respect}");
            Console.WriteLine($"Affection: {eve.Affection}");
            Console.WriteLine($"Resentment: {eve.Resentment}");
            Console.WriteLine();

            Console.WriteLine($"Memory Count: {memories.Count}");
            Console.WriteLine($"Timeline Count: {timeline.Count}");
            Console.WriteLine($"Goal: {eve.Goal}");
            Console.WriteLine($"Need: {eve.Need}");
            Console.WriteLine($"Fear: {eve.Fear}");
            Console.WriteLine($"Want: {eve.Want}");
            Console.WriteLine($"Decision: {eve.CurrentDecision}");
            Console.WriteLine($"Thought: {eve.Thought}");


            break;
        case "7":

            Console.WriteLine("Goodbye !");

            running = false;

            continue;
    }

    Console.WriteLine();
    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
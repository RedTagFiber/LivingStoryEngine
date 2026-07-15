using LivingStoryEngine.Characters;
using LivingStoryEngine.NPCs;
internal class Program
{
    private static void Main(string[] args)
    {
        // Create Eve
        var eve = Eve.Create();
        var amber = Amber.Create();
        var steve = Steve.Create();
        var jake = Jake.Create();




        int currentDay = 1;



        List<Character> npcs = new()
{
    eve,
    amber,
    steve,
    jake
};


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
            Console.WriteLine("8- Sleep");
            Console.WriteLine("9- NPCs");

            Console.Write("Choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    eve.Trust += 5;

                    if (eve.Trust > 100)
                    {
                        eve.Trust = 100;
                    }

                    eve.UpdateRelationshipStatus();

                    eve.Comfort += 3;

                    if (eve.Comfort > 100)
                    {
                        eve.Comfort = 100;
                    }

                    eve.Happiness += 5;

                    if (eve.Happiness > 100)
                    {
                        eve.Happiness = 100;
                    }

                    eve.Stress -= 2;

                    if (eve.Stress < 0)
                    {
                        eve.Stress = 0;
                    }

                    eve.Energy -= 2;

                    if (eve.Energy < 0)
                    {
                        eve.Energy = 0;
                    }

                    if (eve.Trust >= 70)
                    //trust increases when helped


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
                    //curiosity decreases when helped

                    eve.Curiosity -= 1;

                    if (eve.Curiosity < 0)
                    {
                        eve.Curiosity = 0;
                    }
                    if (eve.Curiosity >= 80)
                    {
                        eve.CurrentDecision = "Try to find out what's wrong";
                    }
                    else
                    {
                        eve.CurrentDecision = "Give Ryan some space";
                    }
                    eve.CurrentDecision = "Spend time with Ryan";

                    eve.Thought = "Ryan has been really supportive lately.";

                    eve.JournalEntry = "Ryan was kind to me today. I enjoyed spending time together.";

                    memories.Add($"Day {currentDay}: Ryan helped Eve.");

                    timeline.Add($"Day {currentDay}: Ryan helped Eve.");

                    currentDay++;

                    Console.WriteLine();
                    Console.WriteLine("You helped Eve.");

                    break;

                case "2":

                    eve.Affection -= 3;

                    if (eve.Affection < 0)
                    {
                        eve.Affection = 0;
                    }

                    eve.Resentment += 5;

                    if (eve.Resentment > 100)
                    {
                        eve.Resentment = 100;
                    }

                    eve.Happiness -= 5;

                    if (eve.Happiness < 0)
                    {
                        eve.Happiness = 0;
                    }

                    eve.Stress += 5;

                    if (eve.Stress > 100)
                    {
                        eve.Stress = 100;
                    }

                    eve.Energy -= 1;

                    if (eve.Energy < 0)
                    {
                        eve.Energy = 0;
                    }

                    eve.UpdateRelationshipStatus();

                    if (eve.Resentment >= 20)
                    {
                        eve.Mood = "Annoyed";
                        eve.Goal = "Figure out why Ryan is ignoring me";
                    }
                    else
                    {
                        eve.Mood = "Neutral";
                    }
                    //curisity increases when ignored
                    eve.Curiosity += 5;

                    if (eve.Curiosity >= 80)
                    {
                        eve.CurrentDecision = "Try to find out what's wrong";

                        eve.Thought = "Something feels wrong. I need answers.";

                        eve.JournalEntry =
                            "Ryan has been acting differently. I want to understand what's happening.";
                    }
                    else
                    {
                        eve.CurrentDecision = "Give Ryan some space";

                        eve.Thought = "Why has Ryan been ignoring me?";

                        eve.JournalEntry =
                            "Ryan seemed distant today. I'm not sure why.";
                    }

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
                    Console.WriteLine("========================================");
                    Console.WriteLine("              EVE DEBUG");
                    Console.WriteLine("========================================");

                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Name:          {eve.Name}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Relationship: ");

                    if (eve.RelationshipStatus == "Best Friend")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (eve.RelationshipStatus == "Close Friend")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(eve.RelationshipStatus);
                    Console.ResetColor();
                    Console.ResetColor();

                    Console.WriteLine($"Location:      {eve.Location}");
                    Console.Write("Mood:          ");

                    if (eve.Mood == "Happy")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (eve.Mood == "Annoyed")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(eve.Mood);
                    Console.ResetColor();


                    Console.WriteLine();
                    Console.WriteLine($"Current Day:   {currentDay}");

                    Console.WriteLine();
                    Console.WriteLine("------------ STATS ------------");

                    Console.WriteLine($"Trust:         {eve.Trust}");
                    Console.WriteLine($"Comfort:       {eve.Comfort}");
                    Console.WriteLine($"Respect:       {eve.Respect}");
                    Console.WriteLine($"Affection:     {eve.Affection}");
                    Console.WriteLine($"Resentment:    {eve.Resentment}");
                    Console.Write("Curiosity:     ");

                    if (eve.Curiosity >= 70)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (eve.Curiosity >= 40)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(eve.Curiosity);
                    Console.ResetColor(); ;
                    Console.WriteLine();
                    Console.Write("Happiness:     ");

                    if (eve.Happiness >= 70)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (eve.Happiness >= 40)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine(eve.Happiness);
                    Console.ResetColor();

                    Console.Write("Energy:        ");

                    if (eve.Energy >= 70)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (eve.Energy >= 30)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine(eve.Energy);
                    Console.ResetColor();
                    Console.Write("Stress:        ");

                    if (eve.Stress >= 70)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (eve.Stress >= 40)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(eve.Stress);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("---------- TRAITS ----------");

                    foreach (var trait in eve.Traits)
                    {
                        Console.WriteLine($"{trait.Name} ({trait.Strength})");
                    }
                    Console.WriteLine();
                    Console.WriteLine("---------- MEMORIES ----------");

                    Console.WriteLine($"Memory Count:  {memories.Count}");
                    Console.WriteLine($"Timeline:      {timeline.Count}");

                    Console.WriteLine();
                    Console.WriteLine("------- INTERNAL STATE -------");

                    Console.WriteLine($"Goal:      {eve.Goal}");
                    Console.WriteLine($"Need:      {eve.Need}");
                    Console.WriteLine($"Fear:      {eve.Fear}");
                    Console.WriteLine($"Want:      {eve.Want}");
                    Console.WriteLine();
                    Console.WriteLine("Journal:");
                    Console.WriteLine($"  {eve.JournalEntry}");
                    Console.WriteLine();

                    Console.WriteLine($"Decision:  {eve.CurrentDecision}");

                    Console.WriteLine();

                    Console.WriteLine("Thought:");
                    Console.WriteLine($"  {eve.Thought}");
                    Console.WriteLine();
                    Console.WriteLine("--------- ALERTS ---------");

                    if (eve.Happiness <= 20)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("CRITICAL HAPPINESS");
                        Console.ResetColor();
                    }

                    if (eve.Curiosity >= 80)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("HIGH CURIOSITY");
                        Console.ResetColor();
                    }

                    if (eve.Stress >= 40)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("MODERATE STRESS");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                    Console.WriteLine("========================================");




                    break;
                case "7":

                    Console.WriteLine("Goodbye !");

                    running = false;

                    continue;
                case "8":

                    eve.Energy += 20;

                    if (eve.Energy > 100)
                    {
                        eve.Energy = 100;
                    }

                    eve.Thought = "I feel more rested.";

                    currentDay++;

                    Console.WriteLine();
                    Console.WriteLine("Eve got some sleep.");

                    break;




                case "9":

                    Console.WriteLine();
                    Console.WriteLine("NPCs");
                    Console.WriteLine("----");

                    foreach (var npc in npcs)
                    {
                        Console.WriteLine($"{npc.Name} - {npc.Location}");
                        Console.WriteLine($"  Mood: {npc.Mood}");
                        Console.WriteLine($"  Love Status: {npc.LoveStatus}");
                        Console.WriteLine();
                    }

                    break;
            }
                   
                    Console.WriteLine();
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();


            }
        }
    }

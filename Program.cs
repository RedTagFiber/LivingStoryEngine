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

eve.Location = "Home";

eve.Energy = 100;



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
    Console.WriteLine("8-Sleep");
    
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

            Console.WriteLine($"Decision:  {eve.CurrentDecision}");

            Console.WriteLine();

            Console.WriteLine("Thought:");
            Console.WriteLine($"  {eve.Thought}");

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
    }

    Console.WriteLine();
    Console.WriteLine("Press any key...");
    Console.ReadKey();
}
using System;
using System.Collections.Generic;
using System.Text;

namespace LivingStoryEngine.Characters
{
    internal class CharacterFactory
    {

   
    
        public static Character CreateEve()
        {
            var eve = new Character();

            eve.Name = "Eve";
            eve.Location = "Home";
            eve.Energy = 100;

            eve.Goal = "Spend time with Ryan";
            eve.Need = "Keep her job";
            eve.Fear = "Losing people she cares about";
            eve.Want = "Go on a date with Ryan";
           
            // Eve's memories6

            
            eve.CurrentDecision = "Thinking";

            eve.Thought = "I wonder what today will bring.";
            eve.JournalEntry = "Today feels like a normal day.";
            eve.Location = "Home";

            eve.Energy = 100;
            eve.Curiosity = 50;
            eve.Curiosity -= 1;

            if (eve.Curiosity < 0)
            {
                eve.Curiosity = 0;

            }
            eve.Questions.Add("Why is Ryan acting different?");
            eve.Traits.Add(new Trait
            {
                Name = "Curious",
                Description = "Wants answers and investigates things.",
                Strength = 90
            });

            eve.Traits.Add(new Trait
            {
                Name = "Supportive",
                Description = "Likes helping people she cares about.",
                Strength = 80
            });

            eve.Traits.Add(new Trait
            {
                Name = "Overthinks",
                Description = "Can become trapped in her own thoughts.",
                Strength = 75
            });

            return eve;
        }

        public static Character CreateAmber()
        {
            var amber = new Character();

            amber.Name = "Amber";
            amber.Location = "Home";

            amber.Goal = "Spend time with Steve";
            amber.Need = "Keep her apartment";
            amber.Name = "Amber";
            amber.Location = "Home";
            amber.Energy = 100;

            
            amber.CurrentDecision = "Thinking";
            amber.Thought = "I wonder if Steve will call today.";
            amber.Traits.Add(new Trait
            {
                Name = "Romantic",
                Description = "Values emotional connections.",
                Strength = 85
            });

            amber.Traits.Add(new Trait
            {
                Name = "Social",
                Description = "Enjoys being around people.",
                Strength = 75
            });

            amber.Traits.Add(new Trait
            {
                Name = "Impulsive",
                Description = "Sometimes acts before thinking.",
                Strength = 65
            });
            return amber;
        }
    }
    }



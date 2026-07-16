using LivingStoryEngine.Characters;
using LivingStoryEngine.Managers;
using LivingStoryEngine.Systems;

SpecialTraitManager.LoadAll();

var eve = CharacterFactory.CreateEve();

Console.WriteLine();
Console.WriteLine("Decision");
Console.WriteLine("--------");

Console.WriteLine(
    $"Romanticism = {eve.GetModifier("Romanticism")}"
);

Console.WriteLine(
    DecisionEngine.DecideRelationshipAction(eve)
);
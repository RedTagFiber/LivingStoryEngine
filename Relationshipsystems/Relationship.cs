namespace LivingStoryEngine.Relationshipsystems;

public class Relationship
{
    public string TargetName { get; set; } = "";

    public int Trust { get; set; } = 50;

    public int Respect { get; set; } = 50;

    public int Affection { get; set; } = 50;

    public int Attraction { get; set; } = 50;

    public int Love { get; set; } = 0;
    public int Resentment { get; set; } = 0;


    public string Status { get; set; } = "Stranger";


    // Udated method to update the relationship status based on Love and Trust levels
    public void UpdateStatus()
    {
        if (Love >= 80)
        {
            Status = "In Love";
        }
        else if (Love >= 60)
        {
            Status = "Dating";
        }
        else if (Trust >= 60)
        {
            Status = "Friend";
        }
        else
        {
            Status = "Stranger";
        }
    }
}
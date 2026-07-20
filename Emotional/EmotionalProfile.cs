using LivingStoryEngine.Emotional;
using LivingStoryEngine.MemorySystem;
using System.Net.Mail;

namespace LivingStoryEngine.Emotional;

public class EmotionalProfile
{
    // =======================================
    // EMOTIONAL PROFILE CORE FIELDS
    // =======================================

    // Personality type (Warm, Guarded, Outgoing, etc.)
    public PersonalityType Personality { get; set; } = PersonalityType.Warm;

    // Attachment style (Secure, Avoidant, Anxious, Disorganized)
    public AttachmentStyle Attachment { get; set; } = AttachmentStyle.Secure;

    // Emotional armor level (Low, Medium, High, Extreme)
    public ArmorLevel EmotionalArmor { get; set; } = ArmorLevel.Low;


    // =======================================
    // CORE EMOTIONAL STATE VARIABLES
    // =======================================

    public int Mood { get; private set; } = 50;
    public int Stress { get; private set; } = 50;
    public int Comfort { get; private set; } = 50;
    public int Trust { get; private set; } = 50;
    public int Affection { get; private set; } = 50;
    public int Respect { get; private set; } = 50;


    // =======================================
    // MEMORY SYSTEM
    // =======================================

    public List<Memory> Memories { get; set; } = new();

    public void AddMemory(string summary, int importance)
    {
        Memories.Add(new Memory
        {
            Summary = summary,
            Importance = importance,
            DateCreated = DateTime.Now
        });
    }

    public void ProcessEvent(string eventDescription)
{
    // ============================
    // PERSONALITY-BASED REACTIONS
    // ============================
    switch (Personality)
    {
        case PersonalityType.Warm:
            if (eventDescription.Contains("kind"))
                Affection += 5;

            if (eventDescription.Contains("conflict"))
                Stress += 5;
            break;

        case PersonalityType.Guarded:
            if (eventDescription.Contains("kind"))
                Trust += 2; // small gain

            if (eventDescription.Contains("lie"))
                Stress += 15;
            break;

        case PersonalityType.Outgoing:
            if (eventDescription.Contains("social"))
                Mood += 10;

            if (eventDescription.Contains("ignore"))
                Stress += 5;
            break;

        case PersonalityType.LoneWolf:
            if (eventDescription.Contains("alone"))
                Comfort += 10;

            if (eventDescription.Contains("crowd"))
                Stress += 10;
            break;

        case PersonalityType.Anxious:
            Stress += 5; // baseline sensitivity

            if (eventDescription.Contains("uncertain"))
                Stress += 10;
            break;

        case PersonalityType.Stoic:
            Stress -= 5; // baseline calm

            if (eventDescription.Contains("emotional"))
                Comfort -= 5;
            break;

        case PersonalityType.Chaotic:
            Mood += 5;
            Stress += 5;
            break;

        case PersonalityType.Empathic:
            if (eventDescription.Contains("sad"))
                Mood -= 5;

            if (eventDescription.Contains("happy"))
                Mood += 5;
            break;
    }

    // ============================
    // ATTACHMENT-BASED REACTIONS
    // ============================
    switch (Attachment)
    {
        case AttachmentStyle.Secure:
            if (eventDescription.Contains("support"))
                Comfort += 10;
            break;

        case AttachmentStyle.Avoidant:
            if (eventDescription.Contains("cling"))
                Stress += 10;
            break;

        case AttachmentStyle.Anxious:
            if (eventDescription.Contains("delay"))
                Stress += 15;
            break;

        case AttachmentStyle.Disorganized:
            Stress += 5; // baseline instability
            break;
    }

    // ============================
    // ARMOR-LEVEL REACTIONS
    // ============================
    switch (EmotionalArmor)
    {
        case ArmorLevel.Low:
            if (eventDescription.Contains("harsh"))
                Stress += 10;
            break;

        case ArmorLevel.Medium:
            if (eventDescription.Contains("harsh"))
                Stress += 5;
            break;

        case ArmorLevel.High:
            if (eventDescription.Contains("harsh"))
                Stress += 2;

            if (eventDescription.Contains("vulnerable"))
                Comfort -= 10;
            break;

        case ArmorLevel.Extreme:
            if (eventDescription.Contains("harsh"))
                Stress += 1;

            if (eventDescription.Contains("vulnerable"))
                Comfort -= 20;
            break;
    }

    // ============================
    // MEMORY CREATION
    // ============================
    AddMemory($"Event processed: {eventDescription}", 3);
}

    internal void ApplyAllModifiers()
    {
        throw new NotImplementedException();
    }
}
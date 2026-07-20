using LivingStoryEngine.Characters;
using System;
using System.Collections.Generic;
using System.Text;
using LivingStoryEngine.MemorySystem;

namespace LivingStoryEngine;

public class StoryEngine
{
    public List<Character> Characters { get; set; } = new();

    public List<MemorySystem.Memory> Memories { get; set; } = new();


    public List<TimelineEvent> Timeline { get; set; } = new();

    public List<GameEvent> Events { get; set; } = new();


    public void AddCharacter(Character character)
    {
        Characters.Add(character);
    }

    public void AddMemory(Memory memory)
    {
        Memories.Add(memory);
    }

    public void AddTimelineEvent(TimelineEvent timelineEvent)
    {
        Timeline.Add(timelineEvent);
    }

    public void AddEvent(GameEvent gameEvent)
    {
        Events.Add(gameEvent);
    }

    public void ShowTimeline()
    {
        Console.WriteLine();
        Console.WriteLine("===== TIMELINE =====");

        foreach (var item in Timeline)
        {
            Console.WriteLine(
                $"{item.EventDate.ToShortDateString()} - {item.Title}");
        }
    }

    public void ShowCharacters()
    {
        Console.WriteLine();
        Console.WriteLine("===== CHARACTERS =====");

        foreach (var character in Characters)
        {
            Console.WriteLine(character.Name);
        }
    }
}
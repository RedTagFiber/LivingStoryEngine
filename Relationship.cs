using System;
using System.Collections.Generic;
using System.Text;

namespace LivingStoryEngine;

public class Relationship
{
    public int Trust { get; set; } = 50;

    public int Comfort { get; set; } = 50;

    public int Respect { get; set; } = 50;

    public int Affection { get; set; } = 50;

    public int Resentment { get; set; } = 0;
}
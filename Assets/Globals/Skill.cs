using UnityEngine;

public class Skill
{
    private float max;
    private float temp;

    public Skill (float max)
    {
        this.max = max;
        this.temp = max;
    }
    public float Max { get => max; }
    public float Temp { get => temp; set => temp = value; }
}

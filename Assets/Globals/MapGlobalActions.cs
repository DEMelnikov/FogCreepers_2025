using UnityEngine;

public class MapGlobalActions
{
    private int map_width = 400;
    private int map_height = 200;
    private int borderIndent = 50;

    public  MapGlobalActions (int map_width, int map_height, int borderIndent)
    {
        this.map_width = map_width;
        this.map_height = map_height;
        this.borderIndent = borderIndent;
    }

    public int GetMaxWidth() { return map_width; }
    public int GetMaxHeight() { return map_height; }
    public int GetBorderIndent() { return borderIndent; }

    public Vector2 GetRandomPointWithIndent (bool needIndent)
    {
        int indent = 0;
        if (needIndent) indent = 1;

        Vector2 RandomPoint = new Vector2(
            Random.Range(GetMaxWidth() / 2 * -1 + GetBorderIndent()* indent, GetMaxWidth() / 2 - GetBorderIndent() * indent),
            Random.Range(GetMaxHeight() / 2 * -1 + GetBorderIndent() * indent, GetMaxHeight() / 2 - GetBorderIndent() * indent));

        //print($"Random x {RandomPoint.x} and {RandomPoint.y}");

        return RandomPoint;
    }
}

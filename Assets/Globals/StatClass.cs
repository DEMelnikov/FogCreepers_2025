public class StatClass
{
    private float min, max, actual, tempmax;

    public StatClass (float min, float max, float actual, float tempMax)
    {
        this.min = min;
        this.max = max;
        this.actual = actual;
        this.tempmax= tempMax;
    }

    public float Min { get => min; }
    public float Max { get => max;  }
    public float Actual { get => actual; }
    public float TempMax { get => tempmax; }

    public bool ChangeActual (float value)
    {
        bool SuccessChange = false;
        
        if ((actual += value)>=min && (actual += value) >= max) 
            { SuccessChange = true;
              actual += value;
            }
        return SuccessChange;
    }

    public void ChangeTempMax (float value)
    {
        tempmax += value;
        if (tempmax < min) { tempmax = min; };
        if (tempmax > max) { tempmax = max; };
    }

    public void PowerChangeActual (float value)
    {
        actual += value;
    }
}
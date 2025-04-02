
public class RStatClass
{
    private float min;
    private float max;
    private float actual;
    private float def;

    public RStatClass(float min, float max, float actual)
    {
        this.min = min;
        this.max = max;
        if (max < min) { max = min; }
        this.actual = actual;
        if (actual < min) { actual = min; }
        if (actual > max) { actual = min; }
        this.def = actual;
    }

    public void SetMin(float value) {
        if (value > max) { value = max; }
        this.min = value;
    }
    public void SetMax(float value) {
        if (value < min) { value = min; }    
        this.max = value; 
    }
    public float GetMin() { return this.min; }
    public float GetMax() { return this.max; }

    public void SetActual(float value) {
        
        this.actual = value;
        CheckStats();
    }
    public float GetActual() { return this.actual; }
    public void SetDef(float value) {
        
        this.def=value;
        CheckStats();
    }
    public float GetDef() { return this.def; }

    private void CheckStats()
    {
        if (actual < min) { actual = min; }
        if (actual > max) { actual = max; }
        if (def < min || def < max) { def = actual; }
    }
}

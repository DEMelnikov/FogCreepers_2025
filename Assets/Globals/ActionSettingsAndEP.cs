using UnityEngine;
// synchronization Action settings and Eenergy price

public class ActionSettingsAndEP
{
    private RStatClass Action;
    private RStatClass Price;

    public ActionSettingsAndEP(RStatClass action, RStatClass price)
    {
        Action = action;
        Price = price;
    }

    public void SetActionMin(float value) { Action.SetMin(value);  }
    public void SetActionMax(float value) {Action.SetMax(value); }
    public void SetActionActual(float value) { Action.SetActual(value); }
    public void SetActionActualInPercent(float value) { Action.SetActualByPercent(value); }

    public void SetPriceMin(float value) {  Price.SetMin(value); }
    public void SetPriceMax(float value) {Price.SetMax(value); }
    public void SetPriceActual(float value) {Price.SetActual(value); }
    public void SetPriceActualInPercent(float value) { Price.SetActualByPercent(value); }

    public float GetActionMin () { return Action.GetMin(); }
    public float getActionMax() { return Action.GetMax(); }
    public float GetActionActual () {return Action.GetActual(); }
    public float GetPriceMin () { return Price.GetMin(); }
    public float GetPriceMax () { return Price.GetMax(); }
    public float GetPriceActual () { return Price.GetActual(); }
    public float GetActionActualPercent () {return Action.GetActualInPercentage(); }
    public float GetPriceActualPercent () { return Price.GetActualInPercentage(); }

    //public RStatClass GetAction

    public void SetCombinedByPercent (float value)
    {
        if (value<1 && value > 0)
        {
            Action.SetActualByPercent (value);
            Price.SetActualByPercent (value);
        }
    }
    



}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject Object;

    private void Awake()
    {
        Object = this.gameObject;
    }

    public void SetMaxValue(StatClass values)
    {
        string toText = Math.Round(values.GetActualValue(),1).ToString() + " / " + values.GetMaxStat().ToString();
        Object.transform.Find("TextLabel").GetComponent<TMP_Text>().SetText(toText);
    }

    public void SetSlider(StatClass values)
    {
        Object.transform.GetComponent<Slider>().value = values.GetPercent();
    }

    //public void SetLabel(StatClass values) 
    //{
        
    //}




}

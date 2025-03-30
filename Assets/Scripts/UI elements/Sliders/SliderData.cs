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
        //this.find("Text (TMP)").Get
        //Object.GetComponent<TMP_Text>().SetText();
        //Debug.Log("QQQ" + Object.name);
        string toText = values.GetActualValue().ToString() + " / " + values.GetMaxStat().ToString();
        Object.transform.Find("TextLabel").GetComponent<TMP_Text>().SetText(toText);
    }

    public void SetSlider(StatClass values)
    {
        Object.transform.GetComponent<Slider>().value = values.GetPercent();
    }


}

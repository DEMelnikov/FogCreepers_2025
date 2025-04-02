using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TempText : MonoBehaviour
{
    [SerializeField] GameObject slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        
        this.GetComponent<TMP_Text>().SetText(slider.GetComponent<Slider>().value.ToString()) ;
    }
}

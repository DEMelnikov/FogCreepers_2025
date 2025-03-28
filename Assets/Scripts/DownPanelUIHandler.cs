using UnityEngine;

public class DownPanelUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject HeroUIPanel;

    public void Awake()
    {
        HeroUIPanel.SetActive(false);
    }
}

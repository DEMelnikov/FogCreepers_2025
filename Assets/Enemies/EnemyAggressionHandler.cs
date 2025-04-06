using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggressionHandler : MonoBehaviour
{

    private List<GameObject> HeroesInVisualContact = new List<GameObject>();
    [SerializeField] private float RadiusVisualSearch = 15f;
    private bool isReadyToAttackPortal = true;

    public bool IsReadyToAttackPortal { get => isReadyToAttackPortal; set => isReadyToAttackPortal = value; }

    public float GetRaiusVisualSearch() {  return RadiusVisualSearch; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHeroesInVisualContact(1);
        //Debug.Log(this.CountHeroesInVisualContact().ToString());
    }

    public void UpdateHeroesInVisualContact(float multiplier)
    {
        HeroesInVisualContact.Clear();
        var colliders = Physics2D.OverlapCircleAll(this.transform.position, RadiusVisualSearch*multiplier, 5); // убрать константу
        foreach (var collider in colliders)
        {
            Debug.Log($"{collider.gameObject.name} is nearby");
            HeroesInVisualContact.Add(collider.gameObject);
        }
    }

    public int CountHeroesInVisualContact()
    {
        return HeroesInVisualContact.Count;
    }
    // реализовать проверку визуального контроля при смене хода!
}

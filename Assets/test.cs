using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] private Transform targetPoint;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.destination = targetPoint.position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        
    }
}

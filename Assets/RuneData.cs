using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RuneData : MonoBehaviour
{
    [SerializeField] public int RunePower = 100;
    public int RuneSkillCheckDelay = 10;
    private int RuneDC = 10;

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetRuneDC()
    {
        return RuneDC;
    }

    public int GetDelayCounter()
    {
        return RuneSkillCheckDelay;
    }
}

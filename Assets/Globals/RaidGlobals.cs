using UnityEngine;

public static class RaidGlobals
{
    private static GameObject SelectedObject;
    private static float defRoll = 20;

    private static GameObject fightPanel;
    private static GameObject movePanel;

    static  RaidGlobals()
    {
        fightPanel = GameObject.Find("FightPanel");
        movePanel  = GameObject.Find("MoveSettings");
        DisableHeroPannels();
    }

    public static void SetSelectedObject(GameObject newObject) 
    { 
        SelectedObject = newObject;
        if (SelectedObjectIsEnemy())
        {
            DisableHeroPannels();
            //movePanel.SetActive(false); 
            //GameObject.Find("FightPanel").SetActive(false);
            //GameObject.Find("MoveSettings").SetActive(false);
        }
    }
    public static GameObject GetSelectedObject() { return SelectedObject; }
    public static bool SelectedObjectIsHero()
    {
        if (SelectedObject != null)
        {
            if (SelectedObject.tag == "Hero")
            {
                return true;
            }
        }
        return false;
    }

    public static bool SelectedObjectIsEnemy()
    {
        if (SelectedObject != null)
        {
            if (SelectedObject.tag == "Monster")
            {
                return true;
            }
        }
        return false;
    }

    public static float RollDefaultDicePlusX(float x)
    {
        return Random.Range(0,defRoll+x);
    }

    public static void DisableHeroPannels()
    {
        if (fightPanel.activeSelf) { fightPanel.SetActive(false); }
        if (movePanel.activeSelf) { movePanel.SetActive(false); }
    }
    
}

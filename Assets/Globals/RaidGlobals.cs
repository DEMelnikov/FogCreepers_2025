using UnityEngine;

public static class RaidGlobals
{
    private static GameObject SelectedObject;

    public static void SetSelectedObject(GameObject newObject) {  SelectedObject = newObject; }
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
    
}

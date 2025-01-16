using UnityEngine;

public abstract class ObjectsChanger : MonoBehaviour
{
    protected void EnabledObject(GameObject gameObjectPanel)
    {
        gameObjectPanel.SetActive(true);
    }

    protected void DisableObject(GameObject gameObjectPanel)
    {
        gameObjectPanel.SetActive(false);
    }
}

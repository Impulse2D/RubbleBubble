using UnityEngine;

public class ObjectsChangerService : MonoBehaviour
{
    public void EnableObject(GameObject gameObjectPanel)
    {
        gameObjectPanel.SetActive(true);
    }

    public void DisableObject(GameObject gameObjectPanel)
    {
        gameObjectPanel.SetActive(false);
    }
}

using UnityEngine;

public class StagesTeachingService : MonoBehaviour
{
    private int _numberStage;

    public int NumberStage => _numberStage;

    public void Init()
    {
        _numberStage = 1;
    }

    public void IncreaseNumberStage()
    {
        _numberStage++;
    }
}

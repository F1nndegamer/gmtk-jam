using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    public static LevelManagement Instance;

    public System.Action OnVictory;
    public System.Action OnDeath;

    void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}

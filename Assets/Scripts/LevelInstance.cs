using UnityEngine;

public class LevelInstance : MonoBehaviour
{
    public static LevelInstance Instance;

    public int levelInstanceID;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}

using UnityEngine;

/// <summary>
/// Singleton manager of the level. Makes access to certain objects easier.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Specifications")]
    public int levelID;

    private void Awake()
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

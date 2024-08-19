using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Button[] levelSelectButtons;

    void Start()
    {
        for (int i = levelSelectButtons.Length - 1; i > PersistentManagement.Instance.currentLevel - 1; i--)
        {
            levelSelectButtons[i].interactable = false;
        }
    }
}

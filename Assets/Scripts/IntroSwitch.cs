using UnityEngine;

public class IntroSwitch : MonoBehaviour
{
    [SerializeField] bool on;

    void Start()
    {
        if (on) gameObject.SetActive(PersistentManagement.Instance.introDone);
        else gameObject.SetActive(!PersistentManagement.Instance.introDone);
    }
}

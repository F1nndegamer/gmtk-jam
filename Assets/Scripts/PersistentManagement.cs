using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Carries data between scenes and handles presistent processes.
/// </summary>
public class PersistentManagement : MonoBehaviour
{
    public static PersistentManagement Instance;

    [Header("Specifications")]
    [SerializeField] float sceneTransitionTime;
    [Header("References")]
    [SerializeField] Animator sceneTransitionAnim; 
    [Header("Data")]
    public int currentLevel;

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

    // only here for testing purposes, I'll remove it when we have a proper main menu
    private void Start()
    {
        SceneManager.activeSceneChanged += SceneLoaded;

        LoadScene("SampleScene");
    }

    public void LoadScene(int sceneID)
    {
        sceneTransitionAnim.SetBool("On", true);

        StartCoroutine(LoadSceneDelayed(sceneID, sceneTransitionTime));
    }

    public void LoadScene(string sceneID)
    {
        sceneTransitionAnim.SetBool("On", true);

        StartCoroutine(LoadSceneDelayed(sceneID, sceneTransitionTime));
    }

    IEnumerator LoadSceneDelayed(int sceneID, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneID);
    }

    IEnumerator LoadSceneDelayed(string sceneID, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneID);
    }

    void SceneLoaded(Scene scene1, Scene scene2)
    {
        sceneTransitionAnim.SetBool("On", false);
    }
}

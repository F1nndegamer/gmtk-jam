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
    [SerializeField] int levelManagerID;
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

    private void Start()
    {
        SceneManager.activeSceneChanged += SceneLoaded;

        LoadScene(1);
    }

    public void LoadScene(int sceneID)
    {
        sceneTransitionAnim.SetBool("On", true);

        StartCoroutine(LoadSceneDelayed(sceneID, sceneTransitionTime));
    }

    public void LoadLevel(int levelID)
    {
        sceneTransitionAnim.SetBool("On", true);

        StartCoroutine(LoadSceneDelayed(levelManagerID, levelID, sceneTransitionTime));
    }

    IEnumerator LoadSceneDelayed(int sceneID, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneID);
    }

    IEnumerator LoadSceneDelayed(int sceneID, int additiveRequest, float delay)
    {
        yield return new WaitForSeconds(delay);

        AsyncOperation mainSceneLoad = SceneManager.LoadSceneAsync(sceneID);

        while (!mainSceneLoad.isDone)
        {
            yield return null;
        }

        LoadAdditiveScene(additiveRequest);
    }

    void LoadAdditiveScene(int sceneID)
    {
        SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);
    }

    void SceneLoaded(Scene scene1, Scene scene2)
    {
        sceneTransitionAnim.SetBool("On", false);
    }
}

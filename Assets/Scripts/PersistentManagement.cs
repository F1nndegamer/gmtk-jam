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
}

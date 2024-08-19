using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    public void PlayGames()
    {
        StartCoroutine(Starts());
    }
    IEnumerator Starts()
    {
        yield return new WaitForSeconds(1f);

        camera.GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene(2);
    }
}

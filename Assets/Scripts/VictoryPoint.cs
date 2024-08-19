using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The script controling the victory point's behaviour.
/// </summary>
public class VictoryPoint : MonoBehaviour
{
    public event System.Action OnVictory; //this could be used if another script wants to do something on victory (like enemies stop attacking the player, the player stops listening to inputs, etc).

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            StartCoroutine(CallVictory(2));
        }
    }

    /// <summary>
    /// Gets called when the player gets to the victory point.
    /// </summary>
    void CallVictorya()
    {
        PersistentManagement.Instance.currentLevel++;

        OnVictory?.Invoke();
    }

    IEnumerator CallVictory(int x)
    {
        yield return new WaitForSeconds(x);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

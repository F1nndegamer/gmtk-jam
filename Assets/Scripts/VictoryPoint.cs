using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The script controling the victory point's behaviour.
/// </summary>
public class VictoryPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            coll.gameObject.SetActive(false);
            LevelManagement.Instance.OnVictory?.Invoke();
        }
    }
}
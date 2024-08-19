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
            coll.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            coll.gameObject.GetComponent<PlayerMovement>().enabled = false;

            if (PersistentManagement.Instance.currentLevel == LevelInstance.Instance.levelInstanceID) PersistentManagement.Instance.currentLevel++;

            LevelManagement.Instance.OnVictory?.Invoke();
        }
    }
}
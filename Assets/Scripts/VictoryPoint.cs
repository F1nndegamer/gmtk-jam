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
    [SerializeField] Animator victoryScreenAnim;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            coll.gameObject.SetActive(false);
            victoryScreenAnim.SetBool("On", true);
        }
    }
}

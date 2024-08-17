using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script controling the victory point's behaviour.
/// </summary>
public class VictoryPoint : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator victoryScreenAnim;

    public event System.Action OnVictory; //this could be used if another script wants to do something on victory (like enemies stop attacking the player, the player stops listening to inputs, etc).

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            CallVictory();
        }
    }

    /// <summary>
    /// Gets called when the player gets to the victory point.
    /// </summary>
    void CallVictory()
    {
        victoryScreenAnim.SetBool("On", true);

        OnVictory?.Invoke();
    }
}

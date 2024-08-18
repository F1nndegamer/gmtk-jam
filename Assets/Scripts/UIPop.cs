using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPop : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void StartAnim()
    {
        anim.SetBool("On", true);
    }
}

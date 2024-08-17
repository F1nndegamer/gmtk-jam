using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<float> gravityWorlds;
    public float activiteGravityScale;
    int i = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            i++;
            if (i >= gravityWorlds.Count)
            {
                i = 0;
            }
            activiteGravityScale = gravityWorlds[i];
        }
    }
}

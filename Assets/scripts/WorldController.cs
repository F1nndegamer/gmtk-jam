using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<float> gravityWorlds;
    public GameObject player;
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
            player.GetComponent<Rigidbody2D>().gravityScale = gravityWorlds[i];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousPlatform : MonoBehaviour
{
    public float saveTime;
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider;
    bool playerHere;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHere)
            saveTime -= Time.deltaTime;
        if(saveTime <= 0)
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.gravityScale = 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerHere = true;
    }
}

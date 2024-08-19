using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    [SerializeField] Animator deathScreenAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            StartCoroutine(CallDeath(2));
        }
    }
    IEnumerator CallDeath(int x)
    {
        deathScreenAnim.SetBool("On", true);
        yield return new WaitForSeconds(x);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

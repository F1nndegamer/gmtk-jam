using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            LevelManagement.Instance.OnDeath?.Invoke();
            SoundManager.Instance.PlaySpikeDeath();
        }
    }
}

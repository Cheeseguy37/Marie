using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Trigger());
    }

    IEnumerator Trigger() // Loads the game over screen after a 4.5 second delay
    {
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene("GameOver");
    }
}

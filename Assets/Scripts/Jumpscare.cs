using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscare;
    public GameObject sceneTrigger;
    public GameObject bgm;

    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster") // If the monster collides with the player, a jumpscare will take place
        {
            sceneTrigger.SetActive(true); // Activates an object that will change scenes after 4.5 seconds
            bgm.SetActive(false); // BGM is muted
            Debug.Log("Jumpscare detected");
            GameObject e = Instantiate(jumpscare) as GameObject;
            e.transform.position = transform.position;
            this.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            audioSource.Play();
        }
    }
}

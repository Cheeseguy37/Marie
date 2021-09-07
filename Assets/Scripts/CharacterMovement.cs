using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody2D rb;

    Vector2 movement;

    public bool hasKey = false;

    private AudioSource lockSound;

    // Update is called once per frame
    private void Start()
    {
        lockSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            if (hasKey == true)
            {
                SceneManager.LoadScene("Victory Scene");
                Debug.Log("Door Open");
            }
            else
            {
                lockSound.Play();
            }
            
        }
    }
}

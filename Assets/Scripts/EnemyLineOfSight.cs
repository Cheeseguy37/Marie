using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSight : MonoBehaviour
{
    public float rotationSpeed;
    public float distance;

    public float speed;
    private Transform target;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false; // The enemy's collider is undetected by the line of sight

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // The enemy will try to find the player
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red); // Draws a line that is only visible in the scene view

            if (hitInfo.collider.CompareTag("Player")) // Enemy will trigger an action if it comes into contact with the player
            {
                transform.Rotate(0, 0, -120f * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Enemy will chase the player
                audioSource.Play(); // Audio will start playing to indicate chase sequence
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green); // Changes the line color to green if in contact with a wall or player
        }
    }
}

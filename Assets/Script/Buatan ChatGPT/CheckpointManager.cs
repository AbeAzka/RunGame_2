using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private bool activated = false;  // a flag to indicate if the checkpoint has been activated
    private SpriteRenderer spriteRenderer;  // a reference to the sprite renderer component

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // get the sprite renderer component
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnTriggerEnter2D is called when the player enters the checkpoint trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activated)  // check if the player enters the checkpoint and it hasn't been activated yet
        {
            activated = true;  // set the activated flag to true
            spriteRenderer.color = Color.green;  // change the checkpoint sprite color to green to indicate that it has been activated
            Debug.Log("Checkpoint activated!");  // print a message to the console
        }
    }
}

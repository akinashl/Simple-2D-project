using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]         //Tell Unity to add theses components to the gameobject this code is attached to.
[RequireComponent(typeof(BoxCollider2D))]       //We will still need to tweak some of the settings.
public class RigidbodyMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    float moveSpeed = 5f;
    public float initialSpeed = 5f;
    public float runMiltiplier;

    private CameraShake cameraShakeScript;
    public GameObject cameraShakeObject;

    void Start()
    {
        cameraShakeObject = GameObject.FindGameObjectWithTag ("Shake");
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveSpeed = Input.GetKey(KeyCode.LeftShift)? initialSpeed * runMiltiplier : initialSpeed;
        float moveInputX = Input.GetAxisRaw("Horizontal"); // For horizontal movement (left/right)
        float moveInputY = Input.GetAxisRaw("Vertical");   // For vertical movement (up/down)


        // Normalise the vector so that we don't move faster when moving diagonally.
        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();

        // Assign velocity directly to the Rigidbody
        rb2d.velocity = moveDirection * moveSpeed;

    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            cameraShakeScript.shakeTimer = 5f;
            
        }
    }
}

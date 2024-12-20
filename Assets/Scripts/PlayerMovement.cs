using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float HP;
    Animator animator;

    void Start()
    {
        cameraShakeObject = GameObject.FindGameObjectWithTag ("Shake");
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveSpeed = Input.GetKey(KeyCode.LeftShift)? initialSpeed * runMiltiplier : initialSpeed;
        float moveInputX = Input.GetAxisRaw("Horizontal"); // For horizontal movement (left/right)
        float moveInputY = Input.GetAxisRaw("Vertical");   // For vertical movement (up/down)

        animator.SetFloat("InputX", moveInputX);
        animator.SetFloat("InputY", moveInputY);

        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();
        
        // Assign velocity directly to the Rigidbody
        rb2d.velocity = moveDirection * moveSpeed;
        if (HP <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            cameraShakeScript.shakeTimer = 5f;
            
        }
        if (collision.gameObject.tag == "Enemy")
        {
            HP -= 10;
        }
    }
}

using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]         //Tell Unity to add theses components to the gameobject this code is attached to.
[RequireComponent(typeof(BoxCollider2D))]       //We will still need to tweak some of the settings.

public class PlayerMovement : MonoBehaviour
{
    public bool is_paused = false;
    public Image healthbar;

    Rigidbody2D rb;
    Animator animator;
    CameraShake cameraShakeScript;

    [Header("Values")]
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField]  float _initialSpeed = 5f;
    [SerializeField]  float _runMiltiplier;

    [Header("Parameters")]
    [SerializeField] int _maxHealth;
    public int health;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        health = _maxHealth;

        Debug.Log("Player have been spawned");
        Debug.Log("Rigidbody velocity" + _moveSpeed);
    }

    public void Update()
    {
        if (!is_paused)
        {
            _moveSpeed = Input.GetKey(KeyCode.LeftShift)? _initialSpeed * _runMiltiplier : _initialSpeed;
            float moveInputX = Input.GetAxisRaw("Horizontal"); // For horizontal movement (left/right)
            float moveInputY = Input.GetAxisRaw("Vertical");   // For vertical movement (up/down)

            animator.SetFloat("InputX", moveInputX);
            animator.SetFloat("InputY", moveInputY);

            Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
            moveDirection.Normalize();
        
            // Assign velocity directly to the Rigidbody
            rb.velocity = moveDirection * _moveSpeed;

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void UpdateHealth()
    {
        healthbar.fillAmount = (float)health / (float)_maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health -= 10;
            UpdateHealth();
        }
        if(other.gameObject.CompareTag("HealPotion"))
        {
            health += 10;
            UpdateHealth();
        }
        if(other.gameObject.CompareTag("Portal"))
        {
            CinemachineVirtualCamera cmvCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            cmvCamera.enabled = false;
            transform.position = new Vector2 (34f, 175f);
            Camera.main.transform.position = new Vector3 (34f, 175f, Camera.main.transform.position.z);  
            cmvCamera.enabled = true;
        }
    }
}

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
    public Renderer playerRenderer;

    Rigidbody2D rb;
    Animator animator;

    [Header("Values")]
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField]  float _initialSpeed = 5f;
    [SerializeField]  float _runMiltiplier;

    [Header("Parameters")]
    [SerializeField] float _maxHealth;
    public float health;
    public CoinManager cm;
    public Death wall;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        health = _maxHealth;

        Debug.Log("Player have been spawned");
        Debug.Log("Rigidbody velocity" + _moveSpeed);
        playerRenderer = GetComponent<Renderer>();
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
        healthbar.fillAmount = health / _maxHealth;
        Debug.Log("_MaxHealth: " + _maxHealth );
        Debug.Log("Current Health: " + health );
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        HealthScriptForOthers hp =  other.GetComponent<HealthScriptForOthers>();
        if (other.gameObject.tag == "Enemy")
        {
            health -= hp.damage;
            Debug.Log("DAMAGE TAKEN");
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
        if(other.gameObject.CompareTag("Coin"))
        {
            cm.coinCoint++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            wall.hp --;
        }
    }
}

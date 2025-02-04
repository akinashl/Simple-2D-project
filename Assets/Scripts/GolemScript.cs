using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemScript : MonoBehaviour
{
    Animator animator;
    
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Inputx", moveInputX);
        animator.SetFloat("InputY", moveInputY);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Rigidbody2D rb;
    private Animator anim;
    public float MovementSpeed;
    private Vector2 MovementInput;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    // }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }


    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        MovementInput = new Vector2(Horizontal, Vertical);
        rb.velocity = MovementInput * speed;
        
    }
    private void Move() {
    }
    private void Animate() {
        Debug.Log(MovementInput.x);
        if (MovementInput != Vector2.zero) {
            anim.SetFloat("MovementX", MovementInput.x);
            anim.SetFloat("MovementY", MovementInput.y);
            anim.SetBool("Idle", false);
        }
        else {
            anim.SetBool("Idle", true);
        }
    }
}

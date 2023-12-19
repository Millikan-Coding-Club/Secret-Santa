using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Rigidbody2D rb;
    private Animator anim;
    private Vector2 MovementInput;
    public Shotgun Weapon;


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
        if (Mouse.current.leftButton.wasPressedThisFrame){
            
            Weapon.Fire();
       }
    }


    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        MovementInput = new Vector2(Horizontal, Vertical).normalized;
        rb.velocity = MovementInput * speed;
        
    }
    private void Move() {
    }
    private void Animate() {
        if (MovementInput != Vector2.zero) {
            anim.SetFloat("MovementX", MovementInput.x);
            anim.SetFloat("MovementY", MovementInput.y);
            anim.SetBool("Idle", false);
            if (MovementInput.y == 0) { // left and right
                Weapon.transform.localPosition = new Vector3(0, -0.165f, 1);
                Vector2 scale = Weapon.transform.localScale;
                // Weapon.transform.rotation = Quaternion.identity;

                if (MovementInput.x == -1) {

                    scale.y = -.35f;
                }
                else {

                    scale.y = .35f;
                }
                Weapon.transform.localScale = scale;

            }
            else 
             {
                int z = 0;
                if (MovementInput.y == -1) { // 
                    z = 1;
                }
                Weapon.transform.localPosition = new Vector3(0.23f, -.165f, z);
            }
        }
        else {
            anim.SetBool("Idle", true);
        }
    }
}

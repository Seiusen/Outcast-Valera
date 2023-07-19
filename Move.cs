using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] public AudioSource moveSound;
    [SerializeField] public AudioSource mainThemeSound;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingLeft = true;
    private Animator anim;

    public Transform PlayerTransform;
    public static float playerPosX = 0;
    public static float playerPosY = 1.74489f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start() {
        if(PlayerPrefs.HasKey("musicVol"))
        {
            mainThemeSound.volume = PlayerPrefs.GetFloat("musicVol");
            mainThemeSound.Play();
        }
        else
        {
            mainThemeSound.volume = 1f;
            mainThemeSound.Play();
        }
    }   

    private void Update()
    {
        playerPosX = PlayerTransform.position.x;
        playerPosY = PlayerTransform.position.y;

        if(Input.GetKeyUp("9") && (SaveSystem.loadCheck == 1))
        {
            PlayerTransform.position = (new Vector2(SaveSystem.x, SaveSystem.y));
        }


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingLeft == false && moveInput < 0)
        {
            Flip();
        }
        else if (facingLeft == true && moveInput > 0)
        {
            Flip();
        }

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);

            if(PlayerPrefs.HasKey("soundsVol"))
            {
                moveSound.volume = PlayerPrefs.GetFloat("soundsVol");
                moveSound.Play();
            }
            else
            {
                moveSound.volume = 1f;
                moveSound.Play();
            }
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

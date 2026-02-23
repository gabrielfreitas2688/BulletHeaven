using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    EntittyAtributes playerAtributes;
    Rigidbody2D rb;
    SpriteRenderer spritePlayer;
    Animator anim;

    void Start()
    {
        playerAtributes = GetComponent<EntittyAtributes>();
        rb = GetComponent<Rigidbody2D>();
        spritePlayer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Flip();
    }
    void Movement()
    {
        
        float direcaoX = Input.GetAxisRaw("Horizontal");
        float direcaoY = Input.GetAxisRaw("Vertical");

        Vector2 direcao = new Vector2(direcaoX, direcaoY);

        //  Se o vetor for maior que 1 (diagonal) ele mantem em 1 para não somas as velocidade quando ex: A + W
        if (direcao.magnitude > 1)
        {
            direcao = direcao.normalized;
        }

        rb.linearVelocity = direcao * playerAtributes.mooveSpeed;
        if(direcaoX != 0 || direcaoY != 0)
        {
            anim.SetBool("isRun", true);
        }
        else { anim.SetBool("isRun", false); }
            

    }

    void Flip()
    {
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            spritePlayer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spritePlayer.flipX = false;
        }
    }
}

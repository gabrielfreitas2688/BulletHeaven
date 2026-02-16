using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    EntittyAtributes playerAtributes;
    Rigidbody2D rb;

    void Start()
    {
        playerAtributes = GetComponent<EntittyAtributes>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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

    }
}

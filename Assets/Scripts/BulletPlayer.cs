using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 direcao, float velocity)
    {
        rb.linearVelocity = direcao * velocity;
        Destroy(gameObject, 2f);
    }
}

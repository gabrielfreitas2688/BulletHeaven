using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    public GameObject player;
    public float minX, maxX, minY, maxY;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 posicaoAlvo = player.transform.position;
        posicaoAlvo.z = -10;
        posicaoAlvo.x = Mathf.Clamp(posicaoAlvo.x, minX, maxX);
        posicaoAlvo.y = Mathf.Clamp(posicaoAlvo.y, minY, maxY);

        transform.position = Vector3.Lerp(this.transform.position, new Vector3(posicaoAlvo.x, posicaoAlvo.y, -10), 1f * Time.fixedDeltaTime);
    }


}

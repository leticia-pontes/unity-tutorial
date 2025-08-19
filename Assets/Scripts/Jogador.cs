using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float forceMultiplier = 12f; // Força aplicada no movimento
    public float velocidadeMaxima = 10f; // Velocidade máxima de movimento

    private Rigidbody rb; // cache

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        if (rb.linearVelocity.magnitude <= velocidadeMaxima)
        {
            rb.AddForce(new Vector3(horizontalInput * forceMultiplier, 0, 0));    
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Perigo"))
        {
            Destroy(gameObject);
        }
    }
}
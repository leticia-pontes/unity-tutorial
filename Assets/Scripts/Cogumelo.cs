using UnityEngine;

public class Cogumelo : MonoBehaviour
{
    public Vector3 rotation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var yRotation = UnityEngine.Random.Range(0.4f, 1f);
        rotation = new Vector3(yRotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation);    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ilha"))
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Jogador"))
        {
            collision.gameObject.GetComponent<Jogador>().AtivarCrescimentoTemporario(10f);
            Destroy(gameObject);
        }
    }
}

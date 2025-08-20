using UnityEngine;

public class Perigo : MonoBehaviour
{
    public Vector3 rotation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var xRotation = UnityEngine.Random.Range(0.4f, 1f);
        rotation = new Vector3(-xRotation, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // gameObject = self
        if (collision.gameObject.CompareTag("Ilha"))
        {
            Destroy(gameObject);
        }
    }
}

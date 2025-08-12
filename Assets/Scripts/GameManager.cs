using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject perigoPrefab;
    private const int MAX_X_POSITION = 18;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPerigo());
    }

    private IEnumerator SpawnPerigo()
    {
        var x = UnityEngine.Random.Range(-MAX_X_POSITION, MAX_X_POSITION);
        Instantiate(perigoPrefab, new Vector3(x, 20, 20), Quaternion.identity);
        yield return new WaitForSeconds(1);
        yield return SpawnPerigo();
    }

    // Update is called once per frame
    void Update()
    {}
}

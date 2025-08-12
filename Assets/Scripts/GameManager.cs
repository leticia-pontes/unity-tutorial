using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject perigoPrefab;
    
	private const int MAX_X_SPAWN_POSITION = 18;
	private const int PERIGO_SPAWN_HEIGHT = 30;
	private const int PLATFORM_Z_POSITION = 20;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPerigo());
    }

    private IEnumerator SpawnPerigo()
    {
        var spawnXPosition = UnityEngine.Random.Range(-MAX_X_SPAWN_POSITION, MAX_X_SPAWN_POSITION);
        Instantiate(perigoPrefab, new Vector3(spawnXPosition, PERIGO_SPAWN_HEIGHT, PLATFORM_Z_POSITION), Quaternion.identity);
        yield return new WaitForSeconds(1);
        yield return SpawnPerigo();
    }

    // Update is called once per frame
    void Update()
    {}
}

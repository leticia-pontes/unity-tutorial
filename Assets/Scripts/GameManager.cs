using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject perigoPrefab;

    private const float MinXSpawnPosition = -22f;
	private const float MaxXSpawnPosition = 20f;
	private const int PerigoSpawnHeight = 30;
	private const int PlatformZPosition = 20;
    private const float MinLinearDampingSpeed = 0f;
    private const float MaxLinearDampingSpeed = 2f;
    private const int MinPerigosToSpawn = 1;
    private const int MaxPerigosToSpawn = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPerigo());
    }

    private IEnumerator SpawnPerigo()
    {
        var perigosToSpawn = UnityEngine.Random.Range(MinPerigosToSpawn, MaxPerigosToSpawn);

        for (int i = 0; i < perigosToSpawn; i++)
        {
            var spawnXPosition = UnityEngine.Random.Range(MinXSpawnPosition, MaxXSpawnPosition);
            var linearDamping = UnityEngine.Random.Range(MinLinearDampingSpeed, MaxLinearDampingSpeed);
        
            var perigo = Instantiate(perigoPrefab, new Vector3(spawnXPosition, PerigoSpawnHeight, PlatformZPosition), Quaternion.identity);

            perigo.GetComponent<Rigidbody>().linearDamping = linearDamping;    
        }
        
        yield return new WaitForSeconds(1f);
        yield return SpawnPerigo();
    }

    // Update is called once per frame
    void Update()
    {}
}

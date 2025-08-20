using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject perigoPrefab;
    public GameObject cogumeloPrefab;
    public GameObject estrelaPrefab;

    private const float MinXSpawnPosition = -22f;
	private const float MaxXSpawnPosition = 20f;
	private const int PerigoSpawnHeight = 30;
	private const int PlatformZPosition = 20;
    private const float MinLinearDampingSpeed = 1f;
    private const float MaxLinearDampingSpeed = 1.8f;
    private const int MinPerigosToSpawn = 1;
    private const int MaxPerigosToSpawn = 3;
    private const int CogumelosToSpawn = 2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPerigo());
        StartCoroutine(SpawnCogumelo());
        StartCoroutine(SpawnEstrela());
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
        
        yield return new WaitForSeconds(2f);
        yield return SpawnPerigo();
    }

    private IEnumerator SpawnCogumelo()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);

            for (int i = 0; i < CogumelosToSpawn; i++)
            {
                var spawnXPosition = UnityEngine.Random.Range(MinXSpawnPosition, MaxXSpawnPosition);
                var linearDamping = UnityEngine.Random.Range(MinLinearDampingSpeed, MaxLinearDampingSpeed);
            
                var cogumelo = Instantiate(cogumeloPrefab, new Vector3(spawnXPosition, PerigoSpawnHeight, PlatformZPosition), Quaternion.identity);
            
                cogumelo.GetComponent<Rigidbody>().linearDamping = linearDamping;  
            }
        }
    }

    private IEnumerator SpawnEstrela()
    {
        yield return new WaitForSeconds(5f);
        
        while (true)
        {
            yield return new WaitForSeconds(10f);

            var spawnXPosition = UnityEngine.Random.Range(MinXSpawnPosition, MaxXSpawnPosition);
            var linearDamping = UnityEngine.Random.Range(1.5f, 1.5f);
            
            var estrela = Instantiate(estrelaPrefab, new Vector3(spawnXPosition, PerigoSpawnHeight, PlatformZPosition), Quaternion.identity);
            
            estrela.GetComponent<Rigidbody>().linearDamping = linearDamping;
        }
    }

    // Update is called once per frame
    void Update()
    {}
}

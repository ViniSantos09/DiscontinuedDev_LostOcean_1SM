using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    private Vector3 lastPlatformPosition;
    private float spawnInterval = 3.0f; // Intervalo de tempo entre os spawns das plataformas
    private float timer = 1.0f;
    private Vector3 platformDistance = new Vector3(28f, -6.157012f, 2200f); // Dist�ncia entre plataformas
    private float destroyDistance = 60f; // Dist�ncia em que a plataforma deve ser destru�da
    public float initialPlatformDistanceZ = 30f; // Dist�ncia inicial entre as plataformas

    private void Start()
    {
        // Posi��o inicial da primeira plataforma
        lastPlatformPosition = new Vector3(0f, 0f, 2190f);

        // Spawn das plataformas iniciais
        for (int i = 0; i < 3; i++)
        {
            SpawnInitialPlatform(i * initialPlatformDistanceZ);
        }
    }

    private void Update()
    {
        // Incrementa o cron�metro
        timer += Time.deltaTime;

        // Verifica se o intervalo de tempo foi alcan�ado
        if (timer >= spawnInterval)
        {
            SpawnPlatform();
            timer = 0.0f; // Reseta o cron�metro
        }

        // Verifica se alguma plataforma precisa ser destru�da
        DestroyOldPlatforms();
    }

    private void SpawnInitialPlatform(float distanceZ)
    {
        // Define a nova posi��o da plataforma na dire��o Z com a dist�ncia inicial
        Vector3 spawnPosition = lastPlatformPosition + new Vector3(0f, 0f, distanceZ);
        Quaternion spawnRotation = Quaternion.Euler(0f, -90f, 0f); // Rota��o de Y: -90 graus

        Instantiate(platformPrefab, spawnPosition, spawnRotation);
        lastPlatformPosition = spawnPosition;
    }

    private void SpawnPlatform()
    {
        // Define a nova posi��o da plataforma com as dist�ncias X, Y e Z especificadas
        Vector3 spawnPosition = lastPlatformPosition + platformDistance;
        Quaternion spawnRotation = Quaternion.Euler(0f, -90f, 0f); // Rota��o de Y: -90 graus

        Instantiate(platformPrefab, spawnPosition, spawnRotation);
        lastPlatformPosition = spawnPosition;
    }

    private void DestroyOldPlatforms()
    {
        // Encontra todas as plataformas na cena
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        // Itera sobre as plataformas
        foreach (GameObject platform in platforms)
        {
            // Calcula a dist�ncia entre a plataforma e o jogador
            float distanceToPlayer = Vector3.Distance(platform.transform.position, transform.position);

            // Se a plataforma estiver a uma dist�ncia maior que a dist�ncia de destrui��o, ela � destru�da
            if (distanceToPlayer > destroyDistance)
            {
                Destroy(platform);
            }
        }
    }
}
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    private Vector3 lastPlatformPosition;
    private float spawnInterval = 3.0f; // Intervalo de tempo entre os spawns das plataformas
    private float timer = 1.0f;
    private Vector3 platformDistance = new Vector3(28f, -6.157012f, 2200f); // Distância entre plataformas
    private float destroyDistance = 60f; // Distância em que a plataforma deve ser destruída
    public float initialPlatformDistanceZ = 30f; // Distância inicial entre as plataformas

    private void Start()
    {
        // Posição inicial da primeira plataforma
        lastPlatformPosition = new Vector3(0f, 0f, 2190f);

        // Spawn das plataformas iniciais
        for (int i = 0; i < 3; i++)
        {
            SpawnInitialPlatform(i * initialPlatformDistanceZ);
        }
    }

    private void Update()
    {
        // Incrementa o cronômetro
        timer += Time.deltaTime;

        // Verifica se o intervalo de tempo foi alcançado
        if (timer >= spawnInterval)
        {
            SpawnPlatform();
            timer = 0.0f; // Reseta o cronômetro
        }

        // Verifica se alguma plataforma precisa ser destruída
        DestroyOldPlatforms();
    }

    private void SpawnInitialPlatform(float distanceZ)
    {
        // Define a nova posição da plataforma na direção Z com a distância inicial
        Vector3 spawnPosition = lastPlatformPosition + new Vector3(0f, 0f, distanceZ);
        Quaternion spawnRotation = Quaternion.Euler(0f, -90f, 0f); // Rotação de Y: -90 graus

        Instantiate(platformPrefab, spawnPosition, spawnRotation);
        lastPlatformPosition = spawnPosition;
    }

    private void SpawnPlatform()
    {
        // Define a nova posição da plataforma com as distâncias X, Y e Z especificadas
        Vector3 spawnPosition = lastPlatformPosition + platformDistance;
        Quaternion spawnRotation = Quaternion.Euler(0f, -90f, 0f); // Rotação de Y: -90 graus

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
            // Calcula a distância entre a plataforma e o jogador
            float distanceToPlayer = Vector3.Distance(platform.transform.position, transform.position);

            // Se a plataforma estiver a uma distância maior que a distância de destruição, ela é destruída
            if (distanceToPlayer > destroyDistance)
            {
                Destroy(platform);
            }
        }
    }
}
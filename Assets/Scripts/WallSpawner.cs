using System.Collections;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] walls;
    [SerializeField] private Transform[] spawnPoses;
    public bool canSpawn = true;
    private void Start() => StartCoroutine(SpawnWall());
    private IEnumerator SpawnWall()
    {
        if(GameManager.instance.gameSpeed < 2) yield return new WaitForSeconds(Random.Range(1.8f, 3.4f));
        else yield return new WaitForSeconds(Random.Range(1f, 2.6f));
        var wallToSpawn = walls[Random.Range(0, walls.Length)];
        var randPos = spawnPoses[Random.Range(0, spawnPoses.Length)];
        var spawnPos = new Vector3(randPos.position.x, wallToSpawn.transform.position.y, randPos.position.z);
        if(canSpawn) Instantiate(wallToSpawn, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnWall());
    }
}

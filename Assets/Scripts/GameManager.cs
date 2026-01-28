using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public float spawnTerm = 5;
    public float fasterEverySpawn = 0.05f;
    public float minSpawnTerm = 1;
    public TextMeshProUGUI scoreText;
    float timeAfterLastSpawn;
    float score;
    void Start()
    {
        timeAfterLastSpawn = 0;
    }

    void Update()
    {
        timeAfterLastSpawn += Time.deltaTime;
        score += Time.deltaTime;

        if(timeAfterLastSpawn > spawnTerm)
        {
            timeAfterLastSpawn -= spawnTerm;

            SpawnEnemy();

            spawnTerm -= fasterEverySpawn;
            if (spawnTerm < minSpawnTerm)
            {
                spawnTerm = minSpawnTerm;
            }
        }
        scoreText.text = ((int)score).ToString();
    }

    void SpawnEnemy()
    {
        float x = Random.Range(-13f,15f);
        float y = Random.Range(-6.5f, 5.5f);

        GameObject obj = GetComponent<ObjectPool>().Get();
        obj.transform.position=new Vector3(x,y,0);
        obj.GetComponent<EnemyController>().Spawn(Player);
    }
}

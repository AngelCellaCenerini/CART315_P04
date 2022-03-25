using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source code: https://youtu.be/E7gmylDS1C4

public class Spawn : MonoBehaviour
{

    public GameObject writersBlockPrefab;
    public float respawnTime = 3.0f;
    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minY = 13.0f;
    public float maxY = 15.0f;
    public float minZ = -5.0f;
    public float maxZ = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(blockWave());
    }

    private void spawnBlock()
    {
        GameObject a = Instantiate(writersBlockPrefab) as GameObject;
        a.transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }
    IEnumerator blockWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnBlock();
        }
    }
}

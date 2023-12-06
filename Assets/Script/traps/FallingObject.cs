using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float minX = -5f; // X �� �ּҰ�
    public float maxX = 5f;  // X �� �ִ밪
    public float minY = -5f; // Y �� �ּҰ�
    public float maxY = 5f;  // Y �� �ִ밪
    public float spawnInterval = 5f;// �����Ǵ� �ֱ�(��)

    void Start()
    {
        InvokeRepeating("SpawnfallingObject", 5f, spawnInterval);
    }
    void SpawnfallingObject()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        GameObject fallingObject = Instantiate(fallingObjectPrefab, randomPosition, Quaternion.identity);
    }
}

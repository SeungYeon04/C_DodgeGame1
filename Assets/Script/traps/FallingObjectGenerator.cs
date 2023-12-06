using UnityEngine;

public class FallingObjectGenerator : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float minX = -5f; // X �� �ּҰ�
    public float maxX = 5f;  // X �� �ִ밪
    public float minY = -5f; // Y �� �ּҰ�
    public float maxY = 5f;  // Y �� �ִ밪
    // Start is called before the first frame update
    void Start()
    {
        GenerateFallingObject();
    }

    // Update is called once per frame
    void GenerateFallingObject()
    {
        // ������ ��ġ ����
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        GameObject fallingObject = Instantiate(fallingObjectPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);

        FallingObject fallingObjectScript = fallingObject.AddComponent<FallingObject>();
        fallingObjectScript.minX = minX;
        fallingObjectScript.maxX = maxX;
        fallingObjectScript.minY = minY;
        fallingObjectScript.maxY = maxY;
    }
}

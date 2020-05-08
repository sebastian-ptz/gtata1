using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectToSpawn;
    [SerializeField] private int density; 
    
    

    private void Start()
    {
        float edgeX = transform.position.x;
        float edgeZ = transform.position.z;
        float transformScaleX = transform.lossyScale.x * 5;
        float transformScaleY = transform.lossyScale.y * 5;
        int objectCount = 0;
        while (objectCount <= density)
        {
            spawnPrefab(edgeX, edgeZ, transformScaleX, transformScaleY);
            objectCount++;
        }
    }

    private void spawnPrefab(float edgeX, float edgeZ, float transformScaleX, float transformScaleY)
    {
        int RandomObject = UnityEngine.Random.Range(0, ObjectToSpawn.Length);
        GameObject a = Instantiate(ObjectToSpawn[RandomObject]) as GameObject;
        a.transform.position = new Vector3(UnityEngine.Random.Range(edgeX - transformScaleX, edgeX + transformScaleX), transform.position.y, UnityEngine.Random.Range(edgeZ - transformScaleY, edgeZ + transformScaleY));
    }
}
    

using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectToSpawn;
    [SerializeField] private int density;

    Terrain rend;

    private void Start()
    {
        rend = GetComponent<Terrain>();
        
        float terrainWidth = rend.terrainData.size.x / 2;
        float terrainHeight = rend.terrainData.size.z / 2;

        float edgeX = transform.position.x + terrainWidth;
        float edgeZ = transform.position.z + terrainHeight;
        float transformScaleX = terrainWidth * transform.lossyScale.x;
        float transformScaleY = terrainHeight * transform.lossyScale.y;
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

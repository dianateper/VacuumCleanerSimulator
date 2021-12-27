using UnityEngine;

public class GarbageController : MonoBehaviour
{
    [SerializeField] GameObject[] map;
    [SerializeField] Color garbageColor;
    [SerializeField] Color mapColor;

    float repeatTime = 0.2f;

    private void Start()
    {
        InvokeRepeating("SpawnGarbage", 1, repeatTime);
    }

    void SpawnGarbage()
    {
        int randomIndex = Random.Range(0, map.Length);
        map[randomIndex].GetComponent<Renderer>().material.color = garbageColor;
    }

    public void RemoveGarbage(int index)
    {
        map[index].GetComponent<Renderer>().material.color = mapColor;
    }

    public int CheckGarbage(Vector3 robotPos)
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i].transform.position.x == robotPos.x && map[i].transform.position.z == robotPos.z)
            {
                return i;
            }
        }

        return -1;
    }

    public int GetNumberOfGarbage()
    {
        int numberOfGarbage = 0;

        for(int i = 0; i<map.Length; i++)
        {
            if(map[i].GetComponent<Renderer>().material.color == garbageColor)
            {
                numberOfGarbage++;
            }
        }
        return numberOfGarbage;
    }
}

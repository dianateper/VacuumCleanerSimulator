using UnityEngine;

public class VacumCleaner : MonoBehaviour
{
    [SerializeField] GarbageController garbageController;

    int mapLength = 5;

    private void Start()
    {
        SpawnRobot();
    }

    private void Update()
    {
        CheckGarbageOnCurrentPosition();
        CheckGarbage();
        RandomMove();
    }

    void SpawnRobot()
    {
        transform.position = new Vector3(Random.Range(0, mapLength), transform.position.y, Random.Range(0, mapLength));
    }

    void CheckBounds()
    {
        if(transform.position.x < 0)
        {
            MoveBottom();
        }
        else if(transform.position.x >= mapLength)
        {
            MoveTop();
        }

        if (transform.position.z < 0)
        {
            MoveRight();
        }
        else if (transform.position.z >= mapLength)
        {
            MoveLeft();
        }
    }

    void RandomMove()
    {
        int randomMove = Random.Range(0, 4);
        switch (randomMove)
        {
            case 0: MoveLeft(); break;
            case 1: MoveRight(); break;
            case 2: MoveBottom(); break;
            case 3: MoveTop(); break;
        }

        CheckBounds();
    }

    void CheckGarbageOnCurrentPosition()
    {
        int index = garbageController.CheckGarbage(transform.position);

        if(index != -1)
        {
            garbageController.RemoveGarbage(index);
        }
    }

    void CheckGarbage()
    {
        if(garbageController.CheckGarbage(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z)) != -1)
        {
            MoveBottom();
        }
        if (garbageController.CheckGarbage(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z)) != -1)
        {
            MoveTop();
        }
        if (garbageController.CheckGarbage(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1)) != -1)
        {
            MoveRight();
        }
        if (garbageController.CheckGarbage(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1)) != -1)
        {
            MoveLeft();
        }
    }

    void MoveLeft()
    {
        transform.Translate(0, 0, -1);
    }

    void MoveRight()
    {
        transform.Translate(0, 0, 1);
    }

    void MoveBottom()
    {
        transform.Translate(1, 0, 0);
    }

    void MoveTop()
    {
        transform.Translate(-1, 0, 0);
    }
}

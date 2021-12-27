using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float RangeX = 25f;

    void Update()
    {
        transform.Translate(0.001f, 0, 0);

        if(transform.position.x > RangeX)
        {
            transform.position = new Vector3(-RangeX, transform.position.y, transform.position.z);
        }
    }
}

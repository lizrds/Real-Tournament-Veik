using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
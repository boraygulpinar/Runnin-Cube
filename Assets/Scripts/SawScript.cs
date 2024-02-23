using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public float speed;
    public float distance;
    public float rotationSpeed;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPos + new Vector3(movement, 0, 0);
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }
}

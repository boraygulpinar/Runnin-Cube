using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}

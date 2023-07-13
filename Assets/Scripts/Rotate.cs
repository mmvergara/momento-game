using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    void Update()
    {
        transform.Rotate(0f, 0f ,-(360 * speed * Time.deltaTime));
    }
}

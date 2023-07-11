using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFallPlatform : MonoBehaviour
{
    public GameObject fallingPlatform;
    [SerializeField] float spawnRate = 2f;
    [SerializeField] float timer = 0;
    private GameObject platform;
    // Start is called before the first frame update

    private void Start()
    {
        platform = Instantiate(fallingPlatform, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) 
        {
            timer += Time.deltaTime;
        } 
        else
        {
            if (platform == null)
            {
                platform = Instantiate(fallingPlatform, transform.position, transform.rotation);
            }

            timer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private bool isFinished = false;
    private AudioSource finishSound;
    private void Start() {
        finishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFinished) {
            isFinished = true;
            finishSound.Play();
            Invoke("TriggerNextLevel", 2f);  
            Debug.Log("Level Finished");
        }
    }

    private void TriggerNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

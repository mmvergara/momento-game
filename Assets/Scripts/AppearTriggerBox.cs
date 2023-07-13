using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearTriggerBox : MonoBehaviour
{
    [SerializeField] public GameObject[] objectsToActivate;
    private void Start() {
        foreach (GameObject obj in objectsToActivate) {
            obj.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
           if (other.gameObject.CompareTag("Player")) {
            Debug.Log("TRIGGER");
            foreach (GameObject obj in objectsToActivate) {
                obj.SetActive(true);
            }
        }
    }
}

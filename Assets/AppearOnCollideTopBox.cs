using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnCollideTopBox : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite sprite16x16;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        spriteRenderer.sprite = sprite16x16;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            spriteRenderer.enabled = false;
        }
    }
}

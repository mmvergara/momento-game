using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 respawnPoint;
    GameLogic gameLogic;
    private void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string[] TriggerDeathTags = { "FireTrap","Void","Spike" };
        for (int i = 0; i < TriggerDeathTags.Length; i++) {
            if (collision.gameObject.CompareTag(TriggerDeathTags[i])) Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string[] CollisionDeathTags = { "Spike","Saw" };
        for (int i = 0; i < CollisionDeathTags.Length; i++) {
            if (collision.gameObject.CompareTag(CollisionDeathTags[i]))Die();
        }
    }

    private void Die() {
        anim.SetTrigger("DeathTrigger");
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void Respawn(){
         gameLogic.restartLevel(); 
    }

}

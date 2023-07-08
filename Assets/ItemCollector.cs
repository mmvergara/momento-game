using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemCollector : MonoBehaviour
{
    public int appleCount = 0;
    [SerializeField] private Text appleCounterText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            appleCount++;
            Debug.Log("total apples = "+ appleCount.ToString());
            appleCounterText.text = "Apples: "+ appleCount.ToString();
        }

    }
}

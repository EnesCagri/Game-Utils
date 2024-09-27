using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameManager gameManager;

    // Tetikleyiciden geçince çalýþacak
    private void OnTriggerEnter(Collider other)
    {
        // girdiði trigger'ýn cinsini kontrol ediyor
        if (other.CompareTag("Finish"))
        {
            gameManager.LoadNextLevel();
        }
    }

    // Çarpýþma durumunda çalýþacak
    private void OnCollisionEnter(Collision collision)
    {
        // çarptýðý collider'ýn cinsini kontrol ediyor
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("We Hit obstacle");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameManager gameManager;

    // Tetikleyiciden ge�ince �al��acak
    private void OnTriggerEnter(Collider other)
    {
        // girdi�i trigger'�n cinsini kontrol ediyor
        if (other.CompareTag("Finish"))
        {
            gameManager.LoadNextLevel();
        }
    }

    // �arp��ma durumunda �al��acak
    private void OnCollisionEnter(Collision collision)
    {
        // �arpt��� collider'�n cinsini kontrol ediyor
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("We Hit obstacle");
        }
    }
}

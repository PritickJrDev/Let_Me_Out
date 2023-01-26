using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                FindObjectOfType<AudioManager>().Play("monsterFar");

                Destroy(gameObject);

            }
        }
}   

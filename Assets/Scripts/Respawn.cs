using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    string playerone = "Player1";
    string playertwo = "Player2";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(playerone))
        {
            collision.transform.position = spawnPoint[0].position;
        }
        else if(collision.transform.CompareTag(playertwo))
        {
            collision.transform.position = spawnPoint[1].position;
        }
    }
}

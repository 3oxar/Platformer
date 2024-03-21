using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseBonus : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private int point;
    
    private PointsPlayer playerPosition;

    private void Awake()
    {
        playerPosition = player.GetComponent<PointsPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPosition.pointPlayer += point;
            Destroy(this.gameObject);
        }
    }
}

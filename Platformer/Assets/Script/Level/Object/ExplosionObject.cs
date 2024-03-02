using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{
    [SerializeField] private GameObject explosionObject;
    [SerializeField] private GameObject explosionSite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Instantiate(explosionObject, explosionSite.transform);
    }

    
}

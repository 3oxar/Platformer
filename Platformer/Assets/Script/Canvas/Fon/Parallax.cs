using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform[] backgroundTransform;

    [SerializeField] private float[] backgroundCoeff;

    private int backgroundTransformLength;

    private void Awake()
    {
        backgroundTransformLength = backgroundTransform.Length;
    }
   
    void Update()
    {
        for (int i = 0; i < backgroundTransformLength; i++)
        {
            backgroundTransform[i].position = new Vector3(transform.position.x * backgroundCoeff[i], backgroundTransform[i].position.y, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class Elevate : MonoBehaviour
{
    [SerializeField] private float Speedmove;

    void Update()
    {
        transform.Translate(Vector3.up * Speedmove * Time.deltaTime);
    }
}

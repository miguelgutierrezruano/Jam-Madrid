using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed;
  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up  * moveSpeed * Time.deltaTime);
    }
}

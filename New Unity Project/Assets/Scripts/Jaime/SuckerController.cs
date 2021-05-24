using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerController : MonoBehaviour
{


    private void Update()
    {

        transform.right = GetComponent<Rigidbody2D>().velocity;


    }


}

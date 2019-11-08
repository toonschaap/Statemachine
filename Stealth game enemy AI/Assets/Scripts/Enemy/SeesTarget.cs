using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == target)
        {

        }
    }
}

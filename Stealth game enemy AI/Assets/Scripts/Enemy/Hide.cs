using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform[] moveSpots;

    public GameObject target;

    private int randomSpot;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == target)
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
    }
   
}

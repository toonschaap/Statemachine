using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

public class AI : MonoBehaviour
{
    public bool switchState = false;
    public StateMachine<AI> stateMachine { get; set; }

    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform[] moveSpots;
    [SerializeField]
    private Transform[] hideSpots;

    public GameObject target;
    public float startWaitTime;

    private int randomSpot;
    private float waitTime;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
       
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0) {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
        }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == target)
            switchState = !switchState;
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            stateMachine.Update();
    }

}
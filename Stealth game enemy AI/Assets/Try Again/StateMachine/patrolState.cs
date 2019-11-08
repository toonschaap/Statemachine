using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

public class patrolState : State<AI>
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform[] moveSpots;
    
    public float startWaitTime;
    public GameObject host;

    private int randomSpot;
    private float waitTime;

    public override void EnterState(AI _owner)
    {
        {
            waitTime = startWaitTime;
            randomSpot = Random.Range(0, moveSpots.Length);
        }
    }

    public override void ExitState(AI _owner)
    {
        Debug.Log("exit");
    }

    public override void UpdateState(AI _owner)
    {
        host.transform.position = Vector2.MoveTowards(host.transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(host.transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

public class HideState : State<AI>
{
    [SerializeField]
    private Transform[] hideSpots;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject target;

    public float startWaitTime;
    public GameObject host;

    private int randomSpot;
    private float waitTime;

    Collider seeTarget;

    public override void EnterState(AI _owner)
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, hideSpots.Length);
    }

    public override void ExitState(AI _owner)
    {
        
    }

    public override void UpdateState(AI _owner)
    {
        if (seeTarget.gameObject == target)
        {
            host.transform.position = Vector2.MoveTowards(host.transform.position, hideSpots[randomSpot].position, speed * Time.deltaTime);
        }
    }
}

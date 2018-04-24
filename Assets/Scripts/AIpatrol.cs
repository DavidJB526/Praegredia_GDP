using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIpatrol : MonoBehaviour {

    //Checkpoints the creature will hit
    public Transform[] points;

    //Current checkpoint
    private int destinationPoint = 0;

    private NavMeshAgent agent;

    //Initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();

        //Disables autobreaking so the agent doesnt stop at each checkpoint
        agent.autoBraking = false;

        GotoNextPoint();
	}
	
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        //Go to currently selected point
        agent.destination = points[destinationPoint].position;
        //Choose the next point
        destinationPoint = (destinationPoint + 1) % points.Length;
    }


	void Update () {

        //choose next destination as agent approaches current one
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
		
	}
}

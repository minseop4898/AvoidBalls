using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class AvoidBallsAgent : Agent
{
    public GameObject ball;
    public GameObject user;
    ArrayList ballArray = new ArrayList();

    public override void InitializeAgent()
    {
    }

    public override void CollectObservations()
    {
    }

    public override void AgentAction(float[] vectorAction, string textAction)
	{
        Vector3 moveVector = new Vector3(0f,0f,0f);
        float moveScale = 0.1f;

        if (Input.GetKey(KeyCode.A)) {moveVector += new Vector3(-1f * moveScale,0f,0f);}
        if (Input.GetKey(KeyCode.S)) {moveVector += new Vector3(0f,0f,-1f * moveScale);}
        if (Input.GetKey(KeyCode.D)) {moveVector += new Vector3(1f * moveScale,0f,0f);}
        if (Input.GetKey(KeyCode.W)) {moveVector += new Vector3(0f,0f,1f * moveScale);}

        user.transform.position += moveVector;
        
        if (Input.GetKeyDown(KeyCode.Space) && moveVector != new Vector3(0f,0f,0f))
        {
            GameObject newBall = (GameObject)Instantiate(
                ball, user.transform.position + 2 * moveVector, Quaternion.identity
            );
            newBall.GetComponent<Rigidbody>().AddForce(moveVector * 3000f);
            ballArray.Add(newBall);
        }
    }

    public override void AgentReset()
    {
    }

    public override void AgentOnDone()
    {
    }
}
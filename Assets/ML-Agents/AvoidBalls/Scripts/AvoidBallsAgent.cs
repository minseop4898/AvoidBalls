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
        if (vectorAction[0] == 5)
        {
            Vector3 userVelo = user.GetComponent<Rigidbody>().velocity;
            Vector3 userPos = user.transform.position;
            GameObject newBall = (GameObject)Instantiate(ball, userPos + userVelo, Quaternion.identity);
            newBall.GetComponent<Rigidbody>().AddForce(userVelo);
        }
        else
        {
            Vector3 direction = new Vector3(0f, 0f, 0f);
            float velScale = 5f;
            switch (vectorAction[0])
            {
                case 1:
                    direction.x = -1f * velScale;
                    break;
                case 2:
                    direction.z = -1f * velScale;
                    break;
                case 3:
                    direction.x = 1f * velScale;
                    break;
                case 4:
                    direction.z = 1f * velScale;
                    break;
            }
            user.GetComponent<Rigidbody>().AddForce(direction);
        }
    }

    public override void AgentReset()
    {
    }

    public override void AgentOnDone()
    {
    }
}
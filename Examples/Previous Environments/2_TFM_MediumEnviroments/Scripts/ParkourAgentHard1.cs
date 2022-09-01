using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// import ML-Agents package 
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


// Delete Update() since we are not using it, but keep Start()
public class ParkourAgentHard : Agent {
    // reference to the Rigidbody component to reset the Agent's velocity and later to apply force to it 
    Rigidbody rBody;
    // public field of type Transform to the RollerAgent class for reseting it every new Episode
    public Transform Target;

    public Material winMaterial;
    public Material loseMaterial;
    public Material normalMaterial;
    public MeshRenderer floorMeshRenderer;

    public float GoalRange = 1.2f;

    public float moveSpeed = 10; // public class variable (can set the value from the Inspector window)
    public float turnSpeed = 2000;
    public float forceAmount = 1;

    Vector3 m_JumpStartingPos;
    public float jumpAmount = 1000;

    public float fallMultiplier = 2.5f;
    //public float lowJumpMultiplier = 2.5f;

    private bool isOnGround = false; 
    private bool isOnWall = false;
    //private float maxDistance = float.PositiveInfinity;
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        this.transform.localRotation = Quaternion.Euler(0, 0, 0);
        this.transform.localPosition = new Vector3(0, 3.0f, 0);

    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.CompareTag("goal") == true && !isOnGoal)
    //    {
    //        isOnGoal = true;
    //    }
    //}

    private void endEpisode(float reward)
    {
        AddReward(reward);
        EndEpisode();
    }
    // test if we are in contact with a collider (ground) to reset the jump
    private void OnCollisionEnter(Collision collision) { 
    
        if ((collision.gameObject.layer == 11 || collision.gameObject.layer == 6)  && !isOnGround)
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("goal") == true)
        {
            endEpisode(1.0f);
            StartCoroutine(
                GoalScoredSwapGroundMaterial(winMaterial, 2));
        }
        if (collision.gameObject.CompareTag("wall") == true)
        {
            isOnWall = true;
        }
    }

    // set-up the environment for a new episode
    public override void OnEpisodeBegin()
    {
        // maxDistance = float.PositiveInfinity;
        // Move the target to a new spot (moved to a new random location)
        Vector3 targetPosition = new Vector3(Random.Range(-10.0f, +10.0f), Random.Range(+0.75f, +2.4f), Random.Range(-10.0f, +10.0f));
        if (!IsInside(targetPosition))
        {
            Target.localPosition = targetPosition;
        }
        else
        {
            Target.localPosition = new Vector3(0, 0.75f, 0);
        }
        if (isOnWall || this.transform.localPosition.y < 0)
        {
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            this.transform.localPosition = new Vector3(Random.Range(-8.0f, +8.0f), 3.0f, Random.Range(-8.0f, +8.0f));
            isOnWall = false;
        }


    }

    bool IsInside(Vector3 point)
    {
        var collider = GetComponent<Collider>();

        Vector3 closest = collider.ClosestPoint(point);
        // Because closest=point if inside - not clear from docs I feel
        return closest == point;
    }


    // Taking Actions and Assigning Rewards
    // to move towards the target the agent needs 2 actions: determines the force applied along the x-axis and the z-axis
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;

        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;
        float forwardAmount = 0f;
        float sideAmount = 0f;


        var dirToGoForwardAction = actionBuffers.DiscreteActions[0];
        var dirToGoSideAction = actionBuffers.DiscreteActions[1];
        var jumpAction = actionBuffers.DiscreteActions[2];

        // Discrete Actions
        switch (dirToGoForwardAction) {
            case 0: forwardAmount = 0f; break;
            case 1: forwardAmount = +1f; break;
            case 2: forwardAmount = -1f; break;
        }

        switch (dirToGoSideAction) {
            case 0: sideAmount = 0f; break;
            case 1: sideAmount = +1f; break;
            case 2: sideAmount = -1f; break;
        }

        // Jump Action - if the agent is on contact with the floor
        if ((jumpAction == 1) && isOnGround) //(this.transform.position.y < maxJumpHeight))
        {
            rBody.velocity += (Vector3.up * jumpAmount * Time.deltaTime);
            isOnGround = false;
            //AddReward(-0.001f);

        }
        if (rBody.velocity.y < 0)
        { // si estamos cayendo, caer nas rapido
            rBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }    

        controlSignal.z = forwardAmount; // force applied along the x-axis, MoveX
        controlSignal.y = 0;
        controlSignal.x = sideAmount; // force applied along the z-axis, MoveZ
        controlSignal.Normalize();

       
        // Movemos el agente
        this.transform.position += (controlSignal * moveSpeed * Time.deltaTime);

        // Rotamos el agente
        if (controlSignal != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(controlSignal, Vector3.up);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }



        // RollerAgent applies the values from the action[] array to its Rigidbody component rBody, using Rigidbody.AddForce()
        rBody.AddForce(controlSignal * forceAmount * Time.deltaTime); //  * Time.deltaTime);

        // Rewards
        // calculates the distance to detect when it reaches the target
        //float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached target
        // the Agent is given a reward of 1.0 for reaching the Target cube
        //if (isOnGoal)
        //{
        //    AddReward(1.0f);
        //    EndEpisode();
        //    isOnGoal = false;
        //    StartCoroutine(
        //        GoalScoredSwapGroundMaterial(winMaterial, 2));

        //}

        //if (distanceToTarget < maxDistance)
        //{
        //    AddReward(1.0f / 400);
        //    maxDistance = distanceToTarget;
        //}
        //if (distanceToTarget >= maxDistance)
        //{
        //    AddReward(-1.0f / 4000);
        //}
        // Fell off platform
        // if the Agent falls off the platform, end the episode so that it can reset itself
         if (this.transform.localPosition.y < 0 || isOnWall == true)
        {
            endEpisode(-1.0f);
            StartCoroutine(
                GoalScoredSwapGroundMaterial(loseMaterial, 2));
        }

        // Penalty each Step
        //AddReward(-1f / 4000);

    }

    IEnumerator GoalScoredSwapGroundMaterial(Material mat, float time)
    {
        floorMeshRenderer.material = mat;
        yield return new WaitForSeconds(time); //wait for 2 sec
        floorMeshRenderer.material = normalMaterial;
    }

    // private void OnTriggerEnter(Collider other){
    // if (other.TryGetComponent<Goal>(out Goal goal)){ 
    // SetReward(1f);
    // EndEpisode();
    // }

    // if (other.TryGetComponent<Wall>(out Wall wall))
    //      {
    // SetReward(1f);
    // EndEpisode();
    // }
    // }

    // to first test your environment by controlling the Agent using the keyboard, extending the Heuristic() method
    // the heuristic will generate an action corresponding to the values of the "Horizontal" and "Vertical"
    // input axis (which correspond to the keyboard arrow keys)
    //public override void Heuristic(in ActionBuffers actionsOut)
    //{
    //    var continuousActionsOut = actionsOut.ContinuousActions;
    //    continuousActionsOut[0] = Input.GetAxis("Horizontal");
    //    continuousActionsOut[1] = Input.GetAxis("Vertical");
    //    continuousActionsOut[2] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    //}

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;

        //var directionCheat = Target.localPosition - this.transform.localPosition;
        //directionCheat /= directionCheat.magnitude;
        //if (directionCheat.z > 0) { discreteActionsOut[0] = 1; }
        //else if (directionCheat.z < 0) { discreteActionsOut[0] = 2; }

        //if (directionCheat.x > 0) { discreteActionsOut[1] = 1; }
        //else if (directionCheat.x < 0) { discreteActionsOut[1] = 2; }

        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            discreteActionsOut[0] = 1; // forward
        }
        if (Input.GetKey(KeyCode.S))
        {
            discreteActionsOut[0] = 2; // backwards
        }
        //Side 
        if (Input.GetKey(KeyCode.D))
        {
            discreteActionsOut[1] = 1; // right
        }
        if (Input.GetKey(KeyCode.A))
        {
            discreteActionsOut[1] = 2; // left
        }
        //Jump
        discreteActionsOut[2] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }

}

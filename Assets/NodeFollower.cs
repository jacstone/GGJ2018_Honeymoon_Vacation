using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class NodeFollower : MonoBehaviour {
    public List<GameObject> targetNodes;
    public float speed = 1f;
    public bool IsFollowing;
    public ThirdPersonCharacter controller;

    private void FixedUpdate()
    {
        if (IsFollowing)
        {
            var targetNode = targetNodes[0];

            //rigidBody.velocity = (targetNode.transform.position - transform.position).normalized * speed;
            //transform.LookAt(rigidBody.velocity);
            controller.Move((targetNode.transform.position - transform.position).normalized * speed, false, false);

            if ((transform.position - targetNode.transform.position).magnitude <= .1f)
            {
                //rigidBody.velocity = Vector3.zero;
                //transform.position = targetNode.transform.position;
                //transform.rotation = targetNode.transform.rotation;
                targetNodes.RemoveAt(0);

                if (targetNodes.Count == 0)
                {
                    IsFollowing = false;                    
                }
            } else
            {
                Debug.Log((transform.position - targetNode.transform.position).magnitude.ToString());
            }
        } else
        {
            controller.Move(Vector3.zero, false, false);            
        }
    }
}

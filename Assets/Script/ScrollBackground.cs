using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed;
    public float newPosX;
    public float posXTrigger;
    public Transform otherMap;
    bool isStuck = false;

    void FixedUpdate()
    {
        positionUpdate();
        checkPosition();
    }

    private void checkPosition()
    {
        if (transform.position.x <= posXTrigger && !isStuck)
        {
            isStuck = true;
            newPosition();
            isStuck = false;
        }
    }

    public void newPosition()
    {
        transform.position = new Vector3(otherMap.position.x + newPosX, transform.position.y, transform.position.z);
    }


    //menggeser background 
    private void positionUpdate()
    {
        var movement = Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
    }
}
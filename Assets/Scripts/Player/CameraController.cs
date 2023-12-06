using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float cOffset;
    public Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update() 
    {

        Vector3 newPos = new Vector3(target.position.x, target.position.y + cOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

}

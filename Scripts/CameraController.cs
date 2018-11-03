using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform camera;

    public Transform target;

    public Vector3 offset;

    private Vector3 offset1;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngle;

    public float minViewAngle;

    private bool objHit;

    float zoomDelay = 0;

	// Use this for initialization
	void Start ()
    {
        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;

        if(!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        Cursor.lockState = CursorLockMode.Locked;

        offset1 = offset;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        pivot.transform.position = target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x <180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle,0,0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < (360f + minViewAngle))
        {
           pivot.rotation = Quaternion.Euler((360f + minViewAngle), 0, 0);
        }

        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
        }

        transform.LookAt(target);

        RaycastHit hit;
        Vector3 forward = transform.forward * offset.magnitude;
        //Vector3 forward = transform.TransformDirection(target.forward) * offset.magnitude;
        Debug.DrawRay(transform.position, forward, Color.cyan);

        objHit = false;

        if (Physics.Raycast(transform.position,(forward),out hit))
        {
            if (hit.collider.gameObject.name != "Player")
            {
                objHit = true;
                print(hit.collider.gameObject.name);
                
            }
        }

        if(objHit == true)
        {
            offset = Vector3.Lerp(offset, offset * 0.5f, Time.deltaTime* 2);
            zoomDelay = Time.timeSinceLevelLoad;
           
        }
        if (objHit == false)
        {
            
            if(offset.magnitude < offset1.magnitude && Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0) //Time.timeSinceLevelLoad > 0.5f + zoomDelay )
            {
                offset = Vector3.Lerp(offset, offset * 2f, Time.deltaTime * 2);
            }
            
        }

	}
}

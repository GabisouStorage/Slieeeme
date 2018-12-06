using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    [Range(0,1)]
    private float detectorOffset;

    [SerializeField]
    private float detectorDirection;

    [SerializeField]
    [Range(0, 10)]
    private float detectorDistance;

    [SerializeField]
    private LayerMask detectorMask;


    private FloorDetector leftDetector;

    private FloorDetector rightDetector;

    private FloorDetector middleDetector;


    private Rigidbody2D rb;
   

	// Use this for initialization
	void Start () {
        InitializeDetectors();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        UpdateDetectors();

	}

    void FixedUpdate()
    {
        float inputDirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(inputDirection * speed, rb.velocity.y);

        if (leftDetector.Hit && rightDetector.Hit)
        {

            //print((leftDetector.Hit.point + rightDetector.Hit.point) / 2);

            rb.position = ((leftDetector.Hit.point + rightDetector.Hit.point)/2) + (Vector2.up * 0.5f);
        }
    }

    void OnDrawGizmos(){
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.yellow;

        InitializeDetectors();

        Gizmos.DrawLine(leftDetector.Origin, leftDetector.Target);

        Gizmos.DrawLine(rightDetector.Origin, rightDetector.Target);

        Gizmos.DrawLine(middleDetector.Origin, middleDetector.Target);
    }

    private void InitializeDetectors(){

        leftDetector = new FloorDetector(transform.TransformPoint(Vector3.left * detectorOffset), transform.localRotation * new Vector2(detectorDirection, -1), detectorDistance, detectorMask);

        rightDetector = new FloorDetector(transform.TransformPoint(Vector3.right * detectorOffset), transform.localRotation * new Vector2(-detectorDirection, -1), detectorDistance, detectorMask);

        middleDetector = new FloorDetector(transform.position, transform.localRotation * Vector2.down, detectorDistance, detectorMask);
    }

    private void UpdateDetectors(){
        middleDetector.Origin = transform.position;
        middleDetector.Direction = transform.localRotation * Vector2.down;

        leftDetector.Origin = transform.TransformPoint(Vector3.left * detectorOffset);
        leftDetector.Direction = transform.localRotation * new Vector2(detectorDirection, -1);

        rightDetector.Origin = transform.TransformPoint(Vector3.right * detectorOffset);
        rightDetector.Direction = transform.localRotation * new Vector2(-detectorDirection, -1);
    }

    /*bool doubleRaycastDown(TerrainMovementRayProperties movementRay, float rayLength, out RaycastHit leftHitInfo, out RaycastHit rightHitInfo){
        Vector3 transformUp = transform.up;
        Vector3 transformRight = transform.right;

        Ray leftRay = new Ray(transform.position + movementRay.originOffsetY * transformUp + movementRay.distanceFromCenter * transformRight, -transformUp);
        Ray rightRay = new Ray(transform.position + movementRay.originOffsetY * transformUp - movementRay.distanceFromCenter * transformRight, -transformUp);

        //Ray leftRay = new Ray(transform.position + leftOffset * transformUp + leftOffset * transformRight, -transformUp);
        //Ray rightRay = new Ray(transform.position + rightOffset * transformUp - rightOffset * transformRight, -transformUp);

        return Physics.Raycast(leftRay, out leftHitInfo, rayLength, DefaultTerrainLayerMask) && Physics.Raycast(rightRay, out rightHitInfo, rayLength, DefaultTerrainLayerMask);
    }*/

}

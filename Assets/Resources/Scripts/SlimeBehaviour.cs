using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour {


    [SerializeField]
    private float speed;

    #region Detectors Settings
    [SerializeField]
    private float floorOffset;

    [SerializeField]
    [Range(0, 1)]
    private float detectorOffset;

    [SerializeField]
    [Range(0, 1)]
    private float detectorTopOffset;

    [SerializeField]
    private float detectorDirection;

    [SerializeField]
    [Range(0, 10)]
    private float detectorDistance;

    [SerializeField]
    [Range(0, 10)]
    private float detectorTopDistance;

    [SerializeField]
    private LayerMask detectorMask;
    #endregion

    #region Detectors Variables
    private FloorDetector leftDetector;

    private FloorDetector leftTopDetector;

    private FloorDetector rightDetector;

    private FloorDetector rightTopDetector;

    private FloorDetector middleDetector;
    #endregion

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

        Vector2 moveDirection = Vector2.zero;

        Vector2 physicDirection = Vector2.zero;

        float moveDirectionCorrection = 0;

        if(middleDetector.Hit.normal != Vector2.zero){
            physicDirection = middleDetector.Hit.normal * rb.velocity;
            moveDirection = Vector2.one - new Vector2(Mathf.Abs(middleDetector.Hit.normal.x), Mathf.Abs(middleDetector.Hit.normal.y));
            moveDirectionCorrection = -middleDetector.Hit.normal.x + middleDetector.Hit.normal.y;
        }

        print(moveDirection);

        //if(Mathf.Abs(inputDirection) > 0){
            rb.velocity = (moveDirection * inputDirection * speed * moveDirectionCorrection) + physicDirection;
        //}


        RaycastHit2D leftHit, rightHit;

        if(leftTopDetector.Hit){
            leftHit = leftTopDetector.Hit;
            //print("Esquerda Cima");
        }else{
            leftHit = leftDetector.Hit;
            //print("Esquerda Baixo");
        }

        if (rightTopDetector.Hit)
        {
            rightHit = rightTopDetector.Hit;
            //print("Direita Cima");
        }
        else
        {
            rightHit = rightDetector.Hit;
            //print("Direita Baixo");
        }

        if(leftHit){
            //print("Foi!");
        }else{

            //print("meh!");

        }



    }

    void OnDrawGizmos(){
        Gizmos.color = Color.yellow;

        InitializeDetectors();

        Gizmos.DrawLine(leftDetector.Origin, leftDetector.Target);

        Gizmos.DrawLine(leftTopDetector.Origin, leftTopDetector.Target);


        Gizmos.DrawLine(rightDetector.Origin, rightDetector.Target);

        Gizmos.DrawLine(rightTopDetector.Origin, rightTopDetector.Target);


        Gizmos.DrawLine(middleDetector.Origin, middleDetector.Target);
    }

    private void InitializeDetectors(){

        middleDetector = new FloorDetector(transform.position, transform.localRotation * Vector2.down, detectorDistance, detectorMask);


        leftDetector = new FloorDetector(transform.TransformPoint(Vector3.left * detectorOffset), transform.localRotation * new Vector2(detectorDirection, -1), detectorDistance, detectorMask);

        leftTopDetector = new FloorDetector(transform.TransformPoint(Vector3.left * detectorTopOffset), transform.localRotation * Vector2.left, detectorTopDistance, detectorMask);


        rightDetector = new FloorDetector(transform.TransformPoint(Vector3.right * detectorOffset), transform.localRotation * new Vector2(-detectorDirection, -1), detectorDistance, detectorMask);

        rightTopDetector = new FloorDetector(transform.TransformPoint(Vector3.right * detectorTopOffset), transform.localRotation * Vector2.right, detectorTopDistance, detectorMask);
    }

    private void UpdateDetectors(){
        middleDetector.Origin = transform.position;
        middleDetector.Direction = transform.localRotation * Vector2.down;


        leftDetector.Origin = transform.TransformPoint(Vector3.left * detectorOffset);
        leftDetector.Direction = transform.localRotation * new Vector2(detectorDirection, -1);
        
        leftTopDetector.Origin = transform.TransformPoint(Vector3.left * detectorTopOffset);
        leftDetector.Direction = transform.localRotation * Vector2.left;


        rightDetector.Origin = transform.TransformPoint(Vector3.right * detectorOffset);
        rightDetector.Direction = transform.localRotation * new Vector2(-detectorDirection, -1);

        rightTopDetector.Origin = transform.TransformPoint(Vector3.right * detectorTopOffset);
        rightDetector.Direction = transform.localRotation *Vector2.right;
    }

}

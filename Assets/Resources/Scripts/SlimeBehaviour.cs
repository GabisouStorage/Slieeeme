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
    [Range(0, 10)]
    private float detectorMiddleDistance;

    [SerializeField]
    private LayerMask detectorMask;
    #endregion

    #region Detectors Variables
    private FloorDetector leftDetector;

    private FloorDetector leftTopDetector;

    private FloorDetector rightDetector;

    private FloorDetector rightTopDetector;

    private FloorDetector middleDownDetector;

    private FloorDetector middleTopLeftDetector;

    private FloorDetector middleTopRightDetector;
    #endregion

    private Rigidbody2D rb;


    #region Movement Variables
    private Vector2 lastNormal;
    private RaycastHit2D nextHit;
    #endregion

    private bool isActive;

    private bool esquerda = false;
    private bool directionSprite = false;

    public bool IsActive
    {
        set { this.isActive = value; }
    }

    private bool canChange;

    public bool CanChange
    {
        get { return this.canChange; }
    }
   
   private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        rend = GetComponentInChildren<SpriteRenderer>();
        InitializeDetectors();

        lastNormal = middleDownDetector.Hit.normal;
	}
	
	// Update is called once per frame
	void Update () {

        //UpdateDetectors();

	}

    void FixedUpdate()
    {
        UpdateDetectors();

        RaycastHit2D tempHit = new RaycastHit2D();

        bool bateu = false;

        if (middleDownDetector.Hit)
        {
            tempHit = middleDownDetector.Hit;
            bateu = true;
        }

        if (leftTopDetector.Hit)
        {
            tempHit = leftTopDetector.Hit;
            bateu = true;
        }

        if (rightTopDetector.Hit)
        {
            tempHit = rightTopDetector.Hit;
            bateu = true;
        }

        if (middleTopLeftDetector.Hit)
        {
            tempHit = middleTopLeftDetector.Hit;
            bateu = true;
        }

        if (middleTopRightDetector.Hit)
        {
            tempHit = middleTopRightDetector.Hit;
            bateu = true;
        }

        if (bateu){
            if(tempHit.collider.gameObject.tag == "Gosma"){
                canChange = true;
            }


        }else{
            canChange = false;
        }

        if(isActive){

            #region Simple Movement Logic

            Vector2 moveNormal = Vector2.zero;

            if (middleDownDetector.Hit) {
                moveNormal = middleDownDetector.Hit.normal;
            }else{
                moveNormal = lastNormal;
            }

            float inputDirection = CorrectInput(moveNormal);

            float spinDirection = CorrecSpintInput(moveNormal, true);

            Vector2 moveDirection = Vector2.zero;

            Vector2 physicDirection = Vector2.zero;

            float moveDirectionCorrection = 0;

            if (middleDownDetector.Hit.normal != Vector2.zero)
            {
                physicDirection = middleDownDetector.Hit.normal * rb.velocity;
                moveDirection = Vector2.one - new Vector2(Mathf.Abs(middleDownDetector.Hit.normal.x), Mathf.Abs(middleDownDetector.Hit.normal.y));
                moveDirectionCorrection = -middleDownDetector.Hit.normal.x + middleDownDetector.Hit.normal.y;
            }/*else{
                physicDirection = lastNormal * rb.velocity;
                moveDirection = Vector2.one - new Vector2(Mathf.Abs(lastNormal.x), Mathf.Abs(lastNormal.y));
                moveDirectionCorrection = -lastNormal.x + lastNormal.y;
            } */

            //rb.velocity = (moveDirection * inputDirection * speed * moveDirectionCorrection) + physicDirection;
            #endregion


            if(moveDirection == Vector2.left || moveDirection == Vector2.down){
                directionSprite = true;
            }else if(moveDirection == Vector2.right || moveDirection == Vector2.up){
                directionSprite = false;
            }

            if(inputDirection < 0){
                esquerda = true;
            }else if(inputDirection > 0){
                esquerda = false;
            }

            if((!directionSprite && esquerda) || (directionSprite && !esquerda)){
                rend.flipX = true;
            }else{
                rend.flipX = false;
            }



            #region Hit Detectors Logic
            RaycastHit2D leftHit, rightHit;

            bool topDetectors = false;

            if (leftTopDetector.Hit)
            {
                leftHit = leftTopDetector.Hit;
                topDetectors = true;
            }
            else
            {
                leftHit = leftDetector.Hit;
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
            #endregion




            Vector2 currentNormal = middleDownDetector.Hit.normal;
            RaycastHit2D otherHit;

            //nextHit = new RaycastHit2D();

            if (inputDirection < 0 && leftHit)
            {
                nextHit = leftHit;
                otherHit = rightHit;
            }
            if (inputDirection > 0 && rightHit)
            {
                nextHit = rightHit;
                otherHit = leftHit;
            }

            if (nextHit && nextHit.normal.magnitude > 0)
            {
                if (nextHit.collider.gameObject.tag == "Gosma" || nextHit.collider.gameObject.tag == "Spinning")
                {

                    if (nextHit.collider.gameObject.tag == "Spinning")
                    {

                        if(spinDirection != 0){

                            Vector2 spinNormal;


                            if(currentNormal == Vector2.zero){
                                spinNormal = lastNormal;
                            }else{
                                spinNormal = currentNormal;
                            }


                            rb.position +=( currentNormal *  (Vector2.one * (1.5f + floorOffset)) * -1);
                            
                            nextHit = new RaycastHit2D();

                            currentNormal = Vector2.zero;

                            rb.rotation += 180;
                        }
                    }
                    if (nextHit.normal != currentNormal)
                    {
                        rb.position = nextHit.point + (nextHit.normal * floorOffset);

                        float rot = Mathf.Rad2Deg * Mathf.Atan2(nextHit.normal.x * -1, nextHit.normal.y);

                        rb.rotation = rot;

                    }
                    else
                    {
                        rb.velocity = (moveDirection * inputDirection * speed * moveDirectionCorrection);
                    }
                }
                else
                {
                    //rb.velocity = (moveDirection * inputDirection * speed * moveDirectionCorrection);
                    rb.velocity = Vector2.zero;
                }
            }
            else
            {
                //rb.velocity = (moveDirection * inputDirection * speed * moveDirectionCorrection);
                rb.velocity = Vector2.zero;
            }


            /*if (Input.GetKeyDown(KeyCode.R))
            {
                rb.rotation += 90;
            } */

            if(middleDownDetector.Hit){
                lastNormal = currentNormal;
            }

            //rb.AddForce(middleDownDetector.Hit.normal * -1 * 1000, ForceMode2D.Force);
            Vector2 otherVelocity = Vector2.zero;
            if(middleDownDetector.Hit){
                if(middleDownDetector.Hit.collider.gameObject.GetComponent<Rigidbody2D>() != null){
                    otherVelocity = middleDownDetector.Hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity;
                }
            }

            if (rb.velocity.x * Mathf.Sign(otherVelocity.x) >= 0)
            {
                rb.velocity += new Vector2(otherVelocity.x, 0f);
            }

            if (rb.velocity.y * Mathf.Sign(otherVelocity.y) >= 0)
            {
                rb.velocity += new Vector2(0f, otherVelocity.y);
            }

        }
    }

    void OnDrawGizmos(){

        try{
            Gizmos.color = Color.yellow;

            //InitializeDetectors();

            Gizmos.DrawLine(leftDetector.Origin, leftDetector.Target);

            Gizmos.DrawLine(leftTopDetector.Origin, leftTopDetector.Target);

            Gizmos.DrawLine(middleTopLeftDetector.Origin, middleTopLeftDetector.Target);

            Gizmos.DrawLine(middleTopRightDetector.Origin, middleTopRightDetector.Target);


            Gizmos.DrawLine(rightDetector.Origin, rightDetector.Target);

            Gizmos.DrawLine(rightTopDetector.Origin, rightTopDetector.Target);


            Gizmos.DrawLine(middleDownDetector.Origin, middleDownDetector.Target);
        }catch{

        }
    }

    private void InitializeDetectors(){

        middleDownDetector = new FloorDetector(transform.position, transform.localRotation * Vector2.down, detectorMiddleDistance, detectorMask);

        middleTopLeftDetector = new FloorDetector(transform.position + Vector3.left * 0.4f, transform.localRotation * Vector2.up, detectorTopDistance * 2f + 0.5f, detectorMask);

        middleTopRightDetector = new FloorDetector(transform.position + Vector3.right * 0.4f, transform.localRotation * Vector2.up, detectorTopDistance * 2f + 0.5f, detectorMask);


        leftDetector = new FloorDetector(transform.TransformPoint(Vector3.left * detectorOffset), transform.localRotation * new Vector2(detectorDirection, -1), detectorDistance, detectorMask);

        leftTopDetector = new FloorDetector(transform.TransformPoint(Vector3.left * detectorTopOffset), transform.localRotation * Vector2.left, detectorTopDistance, detectorMask);


        rightDetector = new FloorDetector(transform.TransformPoint(Vector3.right * detectorOffset), transform.localRotation * new Vector2(-detectorDirection, -1), detectorDistance, detectorMask);

        rightTopDetector = new FloorDetector(transform.TransformPoint(Vector3.right * detectorTopOffset), transform.localRotation * Vector2.right, detectorTopDistance, detectorMask);
    }

    private void UpdateDetectors(){
        middleDownDetector.Origin = transform.position;
        middleDownDetector.Direction = transform.localRotation * Vector2.down;

        middleTopLeftDetector.Origin = transform.position + Vector3.left * 0.4f;
        middleTopLeftDetector.Direction = transform.localRotation * Vector2.up;

        middleTopRightDetector.Origin = transform.position + Vector3.right * 0.4f;
        middleTopRightDetector.Direction = transform.localRotation * Vector2.up;


        leftDetector.Origin = transform.TransformPoint(Vector3.left * detectorOffset);
        leftDetector.Direction = transform.localRotation * new Vector2(detectorDirection, -1);
        
        leftTopDetector.Origin = transform.TransformPoint(Vector3.left * detectorTopOffset);
        leftTopDetector.Direction = transform.localRotation * Vector2.left;


        rightDetector.Origin = transform.TransformPoint(Vector3.right * detectorOffset);
        rightDetector.Direction = transform.localRotation * new Vector2(-detectorDirection, -1);

        rightTopDetector.Origin = transform.TransformPoint(Vector3.right * detectorTopOffset);
        rightTopDetector.Direction = transform.localRotation *Vector2.right;
    }

    float CorrecSpintInput(Vector2 normalMove, bool defaultDirection) {

        KeyCode backKey, frontKey;
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");


        if (normalMove.y != 0)
        {
            if(defaultDirection){
                return inputVertical * normalMove.y * -1;
            }else{
                return inputHorizontal * normalMove.y;
            }
        }
        else if (normalMove.x != 0)
        {

            if (defaultDirection)
            {
                return inputHorizontal * normalMove.x;
            }
            else
            {
                return inputVertical * normalMove.x * -1;
            }
        }
        else {
            return 0;
        }
    }



    float CorrectInput(Vector2 normalMove)
    {

        KeyCode backKey, frontKey;
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        if (normalMove.y != 0)
        {
            return inputHorizontal * normalMove.y;
        }
        else if (normalMove.x != 0)
        {

            return inputVertical * normalMove.x * -1;
        }
        else
        {
            return 0;
        }
    }


    public void meHabilitar()
    {
        //ATENÇAO PODE PARECER IMBECIL ARMAZENAR A POSIÇAO ATUAL ANTES DE DAR O ENABLED = TRUE SOMENTE PARA 
        // COLOCAR A POSIÇAO DE VOLTA AO VALOR ARMAZENADO 
        // POREM CASO ISSO NAO SEJA FEITO , APOS O SEU SLIME IR PARA SOLIDO , CAIR E IR PARA OUTRO TILE , SE ELE VOLTAR A SER SLIME 
        // ELE VOLTA PARA O PONTO ONDE HAVIA DEIXADO DE SER SLIME


        Vector2 posicaoAtual = gameObject.transform.position;
        enabled = true;
        gameObject.transform.position = posicaoAtual;

        if(middleDownDetector.Hit){
            nextHit = middleDownDetector.Hit;
        }else if(leftTopDetector.Hit){
            nextHit = leftTopDetector.Hit;
        }else if(rightTopDetector.Hit){
            nextHit = rightTopDetector.Hit;
        }else if (middleTopLeftDetector.Hit)
        {
            nextHit = middleTopLeftDetector.Hit;
        }else if (middleTopRightDetector.Hit)
        {
            nextHit = middleTopLeftDetector.Hit;
        }

        isActive = true;

    }

    public void meDesabilitar()
    {
       isActive = false;
        //enabled = false;
    
    }












}

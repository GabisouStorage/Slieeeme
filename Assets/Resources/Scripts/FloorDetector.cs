using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorDetector {
	[SerializeField]
	private Vector2 origin;

	public Vector2 Origin{
		set{this.origin = value;}
		get{return this.origin;}
	}
	
	[SerializeField]
	private Vector2 direction; 

	public Vector2 Direction{
		set{this.direction = value;}
	}
	
	[SerializeField]
	private float distance;

	private bool layerControl;
	
	[SerializeField]
	private LayerMask layerMask;

	public LayerMask LayerMask{
		get{return this.layerMask;}
		set{
			this.layerControl = true;
			this.layerMask = value;
		}
	}
	

	public RaycastHit2D Hit {
		get{
			if(layerControl){
                return Physics2D.Raycast(origin, direction, distance, layerMask);
			}else{
                return Physics2D.Raycast(origin, direction, distance);
			}
		}
	}

	public Vector2 Target {
		get{return origin + (direction.normalized * distance);}
	}

    //private RaycastHit2D hit;


    public FloorDetector(Vector2 origin, Vector2 direction, float distance, LayerMask layerMask)
    {
        this.origin = origin;
        this.direction = direction;
        this.distance = distance;
        this.layerMask = layerMask;

		this.layerControl = true;
    }
    public FloorDetector(Vector2 origin, Vector2 direction, float distance)
    {
        this.origin = origin;
        this.direction = direction;
        this.distance = distance;

		this.layerControl = false;
    }
}

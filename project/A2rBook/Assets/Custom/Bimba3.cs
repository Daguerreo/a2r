using UnityEngine;
using System.Collections;



public class Bimba3 : MonoBehaviour {
	
	private Animator anim;
	private CharacterController controller;
	public float speed;
	public float turnSpeed;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity;
	public float cont_h;
	public float cont_v;
	public bool isWaiting;
	public int currState;
	public int frame2;
	public float secbyframe2;
	public Vector3 startPos;
	public Vector3 startRot;

	public void init(){
		speed = 40.0f;
		turnSpeed = 20.0f;
		moveDirection = Vector3.zero;
		gravity = 20.0f;
		cont_h  = 10.0f;
		cont_v = 1.0f;
		isWaiting = false;
		currState = 0;
		frame2 = 0;
		secbyframe2 = 0;
	}
	
	public IEnumerator aspetta(int seconds, int state){
		
		isWaiting = true;
		Debug.Log ("oooooooooooooooooooooooooo");
		Debug.Log("aspetto");
		yield return new WaitForSeconds (seconds);
		Debug.Log("ho finito d aspettare");
		currState = state;
		Debug.Log("ASPETTO---->state="+state);
		isWaiting = false;
	}
	
	// Use this for initialization
	void Start () {
		init ();
		anim = gameObject.GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController> ();
		startPos = transform.position;
		startRot = transform.eulerAngles;
	}
	
	void Reset()
	{
		init();
		transform.position = startPos;
		transform.eulerAngles = startRot;
		anim.SetBool("InizioPar", false);
		Debug.Log ("horesettato................");
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (anim.GetBool ("Reset")) {
//			Reset();
//		}

		if (anim.GetBool("InizioPar"))
		{	
			frame2++;
			secbyframe2 = frame2 / 30.0f;
			//Debug.Log ("frame="+frame2+"   secbyframe=" + secbyframe2)
			if (frame2 >= 170 && secbyframe2 < 10) {
				
				anim.SetInteger ("BimbaParameter", 1);//run
				float translation = cont_h*speed;
				float rotation = cont_v*turnSpeed;
				translation *= Time.deltaTime;
				rotation *= Time.deltaTime;
				if(secbyframe2 <=6){transform.Rotate(0,-rotation/2,0);}
				transform.Translate(0, 0, translation);
				//if(secbyframe2 >=7 && secbyframe2 < 9){transform.Rotate(0,-1.5f*rotation,0);}
				//if(secbyframe2>=9&&secbyframe2<=10)transform.Rotate(0,0,0);
			}


			if (secbyframe2 >= 10 && secbyframe2 < 11)
			{
				transform.Translate(0,0,0);
				anim.SetInteger ("BimbaParameter", 2);//inizio
				Reset();
			} //idle

;
		}
		
	}
}
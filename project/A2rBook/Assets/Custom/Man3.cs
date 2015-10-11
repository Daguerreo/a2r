using UnityEngine;
using System.Collections;


public class Man3 : MonoBehaviour {
	
	private Animator anim;
	private CharacterController controller;
	public float speed = 30.0f;
	public float turnSpeed = 5.0f;
	private Vector3 moveDirection = Vector3.zero;
	//public float Vector3 inizio;
	public float gravity = 20.0f;
	public float cont_h = 1.0f;
	public float cont_v =1.0f;
	public bool isWaiting;
	public int currState;
	public int frame;
	public float secbyframe;
	public Vector3 startPos;
	public Vector3 startRot;

	public void init(){
		speed = 40.0f;
		turnSpeed = 40.0f;
		moveDirection = Vector3.zero;
		gravity = 20.0f;
		cont_h = 10.0f;
		cont_v =1.8f;
		isWaiting = false;
		currState = 0;
		frame = 0;
		secbyframe = 0;
	}
	
	public IEnumerator aspetta(int seconds, int state){
		
		isWaiting = true;
		//Debug.Log ("oooooooooooooooooooooooooo");
		Debug.Log("aspetto");
		yield return new WaitForSeconds (seconds);
		Debug.Log("ho finito d aspettare");
		currState = state;
		//Debug.Log("ASPETTO---->state="+state);
		isWaiting = false;
	}
	
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
		if (anim.GetBool ("InizioPar")) {	
			frame++;
			secbyframe = frame / 30.0f;
			Debug.Log ("frame="+frame+"   secbyframe=" + secbyframe);

			if(frame<124){
				Debug.Log("sto fermissimo");
			}
			//if(secbyframe*30<5*30-40){	//frame 40 del salto ci deve essere il contatto
			if(frame>=124){
			anim.SetInteger ("AnimParMan", 1); //jump
			}
//			if(secbyframe>=5 && secbyframe<6){
//				anim.SetInteger ("AnimParMan", 2); //idle
//				float rotation = -cont_v * turnSpeed;
//				rotation *= Time.deltaTime;
//				transform.Rotate (0, rotation, 0);
//			}
			if(secbyframe>=5 && secbyframe<10){
				anim.SetInteger ("AnimParMan", 2); //run away
				float translation = cont_h * speed;
				float rotation = -cont_v * turnSpeed;
				translation *= Time.deltaTime;
				rotation *= Time.deltaTime;
				//transform.Translate (0, 0, 0);
				if(secbyframe<6){
				transform.Rotate (0, rotation, 0);
				}
			}
			if (secbyframe >= 10 && secbyframe<11)
			{
				transform.Translate(0,0,0);
				anim.SetInteger ("AnimParMan", 4);//iniizio
				Reset();
			} //idle


		}
		
	}
}
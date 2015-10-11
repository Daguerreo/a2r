using UnityEngine;
using System.Collections;



public class BimbaPlayer : MonoBehaviour {

	private Animator anim;
	public float speed;
	public float turnSpeed;
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
		speed = 15.0f;
		turnSpeed = 20.0f;
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
		yield return new WaitForSeconds (seconds);
		currState = state;
		isWaiting = false;
	}

	// Use this for initialization
	void Start () {
		init ();
		anim = gameObject.GetComponentInChildren<Animator>();
		startPos = transform.position;
		startRot = transform.eulerAngles;
	}

	void Reset()
	{
		init();
		transform.position = startPos;
		transform.eulerAngles = startRot;
		anim.SetBool("InizioPar", false);
		//Debug.Log ("horesettato................");
	}

	// Update is called once per frame
	void Update () {
;	

		if (anim.GetBool("InizioPar"))
		{	
			frame2++;
			secbyframe2 = frame2 / 30.0f;
			//		Debug.Log ("frame="+frame2+"   secbyframe=" + secbyframe2)

			if (secbyframe2 >= 3 && secbyframe2 < 8) {

			anim.SetInteger ("BimbaParameter", 1);//run
			float translation = cont_h*speed;
			float rotation = cont_v*turnSpeed;
			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate(0, 0, translation);
				if(secbyframe2 >=6 && secbyframe2 < 8){transform.Rotate(0,-1.7f*rotation,0);}
			}

			if (secbyframe2 >= 8 && secbyframe2 < 11.8) {
			anim.SetInteger ("BimbaParameter", 1);//run
			float translation = cont_h*speed;
			float rotation = 2*cont_v*turnSpeed;
			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate(0, 0, translation/1.4f);
				if(secbyframe2 >=10 && secbyframe2 <11.8){transform.Rotate(0,-0.9f*rotation,0);}
		}
			if(secbyframe2>=11.8 && secbyframe2<14){
				anim.SetInteger ("BimbaParameter", 3);
			}
			if (secbyframe2 >= 14 && secbyframe2<17)
			{
				transform.Translate(0,0,0);
				anim.SetInteger ("BimbaParameter", 4); 
			} //idle
			if (secbyframe2 >= 17 && secbyframe2<18)
			{
				transform.Translate(0,0,0);
				anim.SetInteger ("BimbaParameter", 5); 
				Reset();
			} //idle

		}
		
	}
}
using UnityEngine;
using System.Collections;

public class ButtonEvent : MonoBehaviour {

	protected PlayerController player = null;
	protected GameObject spinner = null;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public virtual void DoEvent(){
		// extends this in ButtonFunction
	}
	public virtual void DoEnter(){
		// extends this in ButtonFunction
	}
	public virtual void DoExit(){
		// extends this in ButtonFunction
	}
}

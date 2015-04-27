using UnityEngine;
using System.Collections;

public class SkillEvent : ButtonEvent {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void DoEvent(){
		if (player == null){
			player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
		}
		player.action_type = 3;
		player.button.SetActive(false);
		player.skills.SetActive(true);
	}
}

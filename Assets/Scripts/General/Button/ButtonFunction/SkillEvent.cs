using UnityEngine;
using System.Collections;

public class SkillEvent : ButtonEvent {

	public Skill[] skill;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void DoEvent(){
		if (player == null){
			player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
			player.skills.SetActive(true);
			skill = player.skills.GetComponentsInChildren<Skill>();
		}
		player.action_type = 3;
		player.button.SetActive(false);
		player.skills.SetActive(true);
		for (int i=0; i<skill.Length; i++){
			skill[i].ResetStars();
		}
	}
}

using UnityEngine;
using System.Collections;

public class TowerEvent : ButtonEvent {
	
	public int tower_num_id;
	
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
		if (player.action_type == 2){
		Debug.Log ("tower num : "+tower_num_id);
			player.HireCharacter(tower_num_id);
			player.RenderText();
		}
		player.button_selecttower.SetActive(false);
		player.button.SetActive(true);
	}
}

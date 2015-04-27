using UnityEngine;
using System.Collections;

public class CharEvent : ButtonEvent {
	
	public int num;
	
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
		if (player.action_type == 1){
			player.MoveCharacter((player.cur_player)*7+(num-1));
			player.RenderText();
		}
		player.button_selectchar.SetActive(false);
		player.button.SetActive(true);
	}
}

using UnityEngine;
using System.Collections;

public class BackEvent : ButtonEvent {

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
		if (num == 1){
			player.button_selectchar.SetActive(false);
			player.button.SetActive(true);
		} else if (num == 2){
			player.button_selecttower.SetActive(false);
			player.button.SetActive(true);
		} else if (num == 3){
			player.skills.SetActive(false);
			player.button.SetActive(true);
		}
	}
}

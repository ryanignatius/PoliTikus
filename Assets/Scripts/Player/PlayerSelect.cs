using UnityEngine;
using System.Collections;

public class PlayerSelect : MonoBehaviour {

	private PlayerController player;
	public SpriteRenderer rend;
	public Sprite[] pic;
	public int id;
	public int max_id;

	// Use this for initialization
	void Start () {
		id = 0;
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetID(int newid){
		if (player == null){
			player = GameObject.Find ("PlayerController").GetComponent<PlayerController>();
		}
		id = newid;
		while (id < 0) id = id+max_id;
		if (id >= max_id) id = id%max_id;
		rend.sprite = pic[id];
		for (int i=0; i<7; i++){
			player.button_chars[i].SetActive(player.chars[id*7+i].is_active);
		}
	}
}

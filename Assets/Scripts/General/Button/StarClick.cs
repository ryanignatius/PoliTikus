using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SpriteRenderer))]

public class StarClick : MonoBehaviour {
	
	private SpriteRenderer pic;
	
	public Sprite[] star_pic;
	public int cur;
	
	// Use this for initialization
	void Start () {
		cur = 0;
		pic = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		cur = 1-cur;
		pic.sprite = star_pic[cur];
	}
	
	public void ResetStar(){
		cur = 0;
		pic.sprite = star_pic[cur];
	}
}

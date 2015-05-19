using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	private float delayTime = 3.0f;
	private GameObject[] pics;
	private int cur;

	// Use this for initialization
	void Start () {
		pics = new GameObject[7];
		pics[0] = GameObject.Find ("load 1-01");
		pics[1] = GameObject.Find ("load 2-02");
		pics[2] = GameObject.Find ("load 2-03");
		pics[3] = GameObject.Find ("load 2-04");
		pics[4] = GameObject.Find ("load 2-05");
		pics[5] = GameObject.Find ("load 2-06");
		pics[6] = GameObject.Find ("load 2-07");
		cur = 0;
		for (int i=1; i<7; i++){
			pics[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartLoad(){
		StartCoroutine(NextPic());
	}
	
	IEnumerator NextPic(){
		while (true){
			yield return new WaitForSeconds(delayTime); // start at time X
			pics[cur].SetActive(false);
			cur++;
			cur %= 7;
			pics[cur].SetActive(true);
		}
	}
}

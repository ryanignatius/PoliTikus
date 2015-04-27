using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	private static float[,] x;
	private static float[,] y;
	private static float dx;
	private static float dy;
	private static bool[,] arr;
	
	// Use this for initialization
	void Awake () {
		Tower.x = new float[4,55];
		Tower.y = new float[4,55];
		Tower.dx = 0.55f;
		Tower.dy = 0.5f;
		Tower.x[0,0] = -5.3f;
		Tower.y[0,0] = -4.1f;
		Tower.x[1,0] = -2.65f;
		Tower.y[1,0] = -4.1f;
		Tower.x[2,0] = 0.05f;
		Tower.y[2,0] = -4.1f;
		Tower.arr = new bool[4,55];
		for (int i=0; i<4; i++){
			for (int j=0; j<55; j++){
				Tower.arr[i,j] = false;
			}
		}
		Tower.arr[0,40] = true;
		Tower.arr[0,41] = true;
		Tower.arr[1,50] = true;
		Tower.arr[1,51] = true;
		Tower.arr[2,40] = true;
		Tower.arr[2,41] = true;
		for (int j=43; j<55; j++){
			Tower.arr[0,j] = true;
			Tower.arr[2,j] = true;
		}
		for (int j=53; j<55; j++){
			Tower.arr[1,j] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static int GetMoneyIncome(int post){
		if (post < 10) return 2;
		if (post < 20) return 5;
		if (post < 30) return 11;
		if (post < 40) return 23;
		return 28;
	}
	public static int GetFame(int post){
		if (post < 10) return 0;
		if (post < 20) return 1;
		if (post < 30) return 2;
		if (post < 40) return 3;
		return 4;
	}
	
	public static float GetPostX(int tow, int post){
		return Tower.x[tow,post];
	}
	public static float GetPostY(int tow, int post){
		return Tower.y[tow,post];
	}
	
	public static int GetMovePost(int from_tow, int from_post, int to_tow, int to_post){
		Tower.arr[from_tow,from_post] = false;
		int cur = to_post;
		if (to_tow == 1){
			if (cur >= 50) cur+=2;
		} else {
			if (cur >= 40) cur+=2;
		}
		if (cur > 52) cur = 52;
		while (Tower.arr[to_tow,cur]){
			cur--;
		}
		Tower.arr[to_tow,cur] = true;
		return cur;
	}
	
	public static float GetDir(int tow, int post){
		if (((post / 5) %  2 == 0)){
			// kanan
			return 1f;
		} else {
			// kiri
			return -1f;
		}
	}
	public static float GetDistX(int tow, int post){
		if (post % 5 == 4){
			// vertical
			return 0f;
		} else {
			// horizontal
			return Tower.dx;
		}
	}
	public static float GetDistY(int tow, int post){
		if (post % 5 == 4){
			// vertical
			return Tower.dy;
		} else {
			// horizontal
			return 0f;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	private static float[,] x;
	private static float[,] y;
	private static float dx;
	private static float dy;
	private static bool[,] arr;
	
	private static float scl = 0.75f;
	
	// Use this for initialization
	void Awake () {
		Tower.x = new float[4,55];
		Tower.y = new float[4,55];
		Tower.dx = 0.5f * scl;
		Tower.dy = 1.15f * scl;
		Tower.x[0,0] = -8.625f * scl;
		Tower.y[0,0] = -5.5f * scl;
		Tower.x[1,0] = -3.4f * scl;
		Tower.y[1,0] = -4.725f * scl;
		Tower.x[2,0] = 1.225f * scl;
		Tower.y[2,0] = -5.45f * scl;
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
	
	public static bool GetChanceCard(int post){
		if (post % 10 >= 5) return true;
		return false;
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
		if (from_post < to_post){
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
		} else {
			Tower.arr[from_tow,from_post] = false;
			int cur = to_post;
			if (from_tow == 1){
				if (from_tow >= 50) cur-=2;
			} else {
				if (from_tow >= 40) cur-=2;
			}
			if (cur < 0) cur=0;
			while (Tower.arr[to_tow,cur]){
				cur++;
			}
			Tower.arr[to_tow,cur] = true;
			return cur;
		}
	}
	
	public static float GetDir(int tow, int post){
		if (tow == 1){
			if (((post / 7) %  2 == 0)){
				// kanan
				return 1f;
			} else {
				// kiri
				return -1f;
			}
		} else {
			if (((post / 8) %  2 == 0)){
				// kanan
				return 1f;
			} else {
				// kiri
				return -1f;
			}
		}
	}
	public static float GetDistX(int tow, int post){
		if (tow == 1){
			if (post % 7 == 6){
				// vertical
				return 0f;
			} else {
				// horizontal
				return Tower.dx;
			}
		} else {
			if (post % 8 == 7){
				// vertical
				return 0f;
			} else {
				// horizontal
				return Tower.dx;
			}
		}
	}
	public static float GetDistY(int tow, int post){
		if (tow == 1){
			if (post % 7 == 6){
				// vertical
				return Tower.dy;
			} else {
				// horizontal
				return 0f;
			}
		} else {
			if (post % 8 == 7){
				// vertical
				return Tower.dy;
			} else {
				// horizontal
				return 0f;
			}
		}
	}
	public static float GetDistX2(int tow, int post){
		if (post % 5 == 0){
			// vertical
			return 0f;
		} else {
			// horizontal
			return Tower.dx;
		}
	}
	public static float GetDistY2(int tow, int post){
		if (post % 5 == 0){
			// vertical
			return -Tower.dy;
		} else {
			// horizontal
			return 0f;
		}
	}
}

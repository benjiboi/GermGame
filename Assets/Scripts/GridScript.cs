using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {
	public GameObject Player;

	public static float CELL_SIZE;

	// Use this for initialization
	void Awake () {

		GridGenerator(64, 64);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GridGenerator (int gridWith, int gridHeight) {

		float PlayerSize = Player.transform.Find("Player Sprite").GetComponent<SpriteRenderer>().bounds.size.y;

		Vector3 topLeft = Camera.main.GetComponent<Camera>().ViewportToWorldPoint(Vector3.zero);
		Vector3 bottomRight = Camera.main.GetComponent<Camera>().ViewportToWorldPoint(Vector3.one);

		float screenWidth = bottomRight.x - topLeft.x;
		float screenHeight = bottomRight.y - topLeft.y;

		float minScreensize = Mathf.Min(screenWidth, screenHeight);

		float cellSize = minScreensize / gridHeight;

		GridScript.CELL_SIZE = cellSize;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float mitoseTime = 4f;
	public GameObject player;

	void Start () {
		transform.localScale = Vector3.one*GridScript.CELL_SIZE;

		GetComponent<BoxCollider2D>().enabled = false;
		if (GetComponent<BoxCollider2D>().Cast(Vector2.zero, null) != 0) {
			Debug.Log(GetComponent<BoxCollider2D>().Cast(Vector2.zero, null));
			Destroy(gameObject);
		}

		GetComponent<BoxCollider2D>().enabled = true;
	}

	bool formation;
	float mitoseTimer;
	void Update () {
		if (!formation)
			mitoseTimer += Time.deltaTime;

		if (mitoseTimer > mitoseTime) {
			mitoseTimer = 0;
			formation = true;

		}

		if (Input.GetButtonDown("Up")) {
			transform.position += new Vector3(0, 1, 0)*GridScript.CELL_SIZE;
		}
		if (Input.GetButtonDown("Down")) {
			transform.position += new Vector3(0, -1, 0) * GridScript.CELL_SIZE;
		}
		if (Input.GetButtonDown("Left")) {
			transform.position += new Vector3(-1, 0, 0) * GridScript.CELL_SIZE;
		}
		if (Input.GetButtonDown("Right")) {
			transform.position += new Vector3(1, 0, 0) * GridScript.CELL_SIZE;
		}

		if (Input.GetButtonDown("Mitose Up") && formation) {
			Instantiate(player, transform.position + new Vector3(0, 1, 0) * GridScript.CELL_SIZE, transform.rotation);
			formation = false;
		}
		if (Input.GetButtonDown("Mitose Down") && formation) {
			Instantiate(player, transform.position + new Vector3(0, -1, 0) * GridScript.CELL_SIZE, transform.rotation);
			formation = false;
		}
		if (Input.GetButtonDown("Mitose Left") && formation) {
			Instantiate(player, transform.position + new Vector3(-1, 0, 0) * GridScript.CELL_SIZE, transform.rotation);
			formation = false;
		}
		if (Input.GetButtonDown("Mitose Right") && formation) {
			Instantiate(player, transform.position + new Vector3(1, 0, 0) * GridScript.CELL_SIZE, transform.rotation);
			formation = false;
		}

	}
}

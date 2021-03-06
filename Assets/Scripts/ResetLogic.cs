﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetLogic : MonoBehaviour
{

    public List<GameObject> items;
	private GameObject item;
    private GameObject currentItem;
	private int randomId;
	public float waitTime;
	private bool rutineStarted = false;

	void Update() {
		if (currentItem == null && !rutineStarted) {
			rutineStarted = true;
			StartCoroutine (InstantiateItem ());
		}
	}

	IEnumerator InstantiateItem() {

		yield return new WaitForSeconds (waitTime);

		randomId = (int) Random.Range (0, items.Count - 1);
		item = items.ToArray () [randomId];
		//Debug.Log ("instantiate object in reset logic");
		currentItem = (GameObject)Instantiate(item, transform.position, transform.rotation);
		currentItem.transform.parent = transform;

		rutineStarted = false;
	}
}

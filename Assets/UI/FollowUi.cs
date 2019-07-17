using UnityEngine;
using System.Collections;

public class FollowUi : MonoBehaviour {

	public int rotationSpeed;
	public Transform target;

	private Transform myTransform;

	void Awake() {
		myTransform = transform;
	}

	void Start () {
		
		GameObject go = GameObject.FindGameObjectWithTag ("MainCamera");
		target = go.transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
	}
}

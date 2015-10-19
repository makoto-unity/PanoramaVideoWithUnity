using UnityEngine;
using System.Collections;

public class MoviePlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MovieTexture movie = (GetComponent<Renderer>().material.mainTexture as MovieTexture);
		movie.loop = true;
		movie.Play();
	}

}

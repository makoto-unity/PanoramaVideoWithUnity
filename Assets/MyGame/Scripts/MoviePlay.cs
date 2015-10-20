using UnityEngine;
using System.Collections;

public class MoviePlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if UNITY_EDITOR || UNITY_STANDALONE
		MovieTexture movie = (GetComponent<Renderer>().material.mainTexture as MovieTexture);
		movie.loop = true;
		movie.Play();
#endif
	}

}

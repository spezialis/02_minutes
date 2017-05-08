using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	AudioSource audioSource;
	Renderer r;

	public void StartFade(){
		StopCoroutine ("FadeIn"); // just in case
		StopCoroutine("FadeOut");

		StartCoroutine ("FadeIn");
	}

	public void StopFade(){
		StopCoroutine ("FadeIn"); // just in case
		StopCoroutine ("FadeOut");

		StartCoroutine ("FadeOut");
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
		r = GetComponent<Renderer> ();
	}

	IEnumerator FadeIn(){

		r.enabled = true;
		audioSource.Play ();
		Color startColor = new Color (0.8f, 0.8f, 0.8f);

		var c = r.material.color;
		for (float f = 0f; f < 1f; f += 0.1f) {
			var col = r.material.color;
			col.a = f;
			r.material.color = col;

			r.material.SetColor("_EmissionColor", startColor);

			yield return null;
		}
	}

	IEnumerator FadeOut(){

		audioSource.Stop ();
		var c = r.material.color;
		Color stopColor = new Color (0f, 0f, 0f);

		for (float f = 1f; f >= 0; f -= 0.1f) {
			var col = r.material.color;
			col.a = f;
			r.material.color = col;
			r.material.SetColor("_EmissionColor", stopColor);

			yield return null;
		}

		r.enabled = false;
	}

}

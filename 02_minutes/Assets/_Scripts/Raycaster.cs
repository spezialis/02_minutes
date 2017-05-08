using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

	GameObject lastLookedAtGameObject;

	// Use this for initialization
	void Start () {
		lastLookedAtGameObject = null;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay(transform.position, forward, Color.green);

		RaycastHit hit;
		if (Physics.Raycast (transform.position, forward, out hit)) {
			var go = hit.collider.gameObject;

			// When started looking at something new
			if (go != lastLookedAtGameObject) {


				// ---- Video 
				if (lastLookedAtGameObject!= null && lastLookedAtGameObject.tag == "Video"){
					var videoPlaybackBehaviour = lastLookedAtGameObject.GetComponent<VideoPlaybackBehaviour> ();
					videoPlaybackBehaviour.VideoPlayer.SeekTo (0f);
					videoPlaybackBehaviour.VideoPlayer.Pause ();

				}

				if (go.tag == "Video") {
					var videoPlaybackBehaviour = go.GetComponent<VideoPlaybackBehaviour> ();
					videoPlaybackBehaviour.VideoPlayer.Play(false, 0f);
				}

				// ---- Audio

				// Old
				if (lastLookedAtGameObject != null) {
					var lastSoundPlayer = lastLookedAtGameObject.GetComponent<SoundPlayer> ();
					if (lastSoundPlayer != null){
						lastSoundPlayer.StopFade ();
					}
				}

				// New
				var soundPlayer = go.GetComponent<SoundPlayer>();
//				var fadePlayer = go.GetComponent<Fade>();
				if (soundPlayer != null) {
					soundPlayer.StartFade ();
//					fadePlayer.StartFade ();
				} else {


				}
			}

			lastLookedAtGameObject = go;
		}
	}
}

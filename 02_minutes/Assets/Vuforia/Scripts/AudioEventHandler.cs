using System.Collections;
using UnityEngine;

namespace Vuforia
{
	public class AudioEventHandler : MonoBehaviour, ITrackableEventHandler
	{
		private TrackableBehaviour mTrackableBehaviour;

		void Start()
		{

			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}

			HideAll ();
		}

		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}

		// Sets the alpha to zero on all renderers
		void HideAll(){
			var objects = GameObject.FindGameObjectsWithTag ("AudioPlane");
			foreach (var o in objects){
				var r = o.GetComponent<Renderer> ();
				var col = r.material.color;
				col.a = 0f;
				r.material.color = col;
				r.material.SetColor("_EmissionColor", Color.black);
			}
		}

		virtual protected void OnTrackingFound()
		{
			//Debug.Log ("TIBOR ON TRACKING FOUND");
		}


		virtual protected void OnTrackingLost()
		{
			//Debug.Log ("TIBOR ON TRACKING LOST");
		}
	}
}
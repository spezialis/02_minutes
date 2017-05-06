using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class createImage : MonoBehaviour {

	public GameObject imagePrefab;
	public float imageDistance = 5.0f;
	Renderer r;
	Material[] materials;

	public Material baseMaterial;
	public string folderName;

	// Use this for initialization
	void Start () {

		Texture2D img = null;
		int j = 0;

		do {
			var path = folderName + "/" + j;
			img = Resources.Load(path) as Texture2D;
			if (img != null){
				//Debug.Log("Height is " + img.height + " and width is " + img.width);
			}

			if (img != null) {
				var mat = new Material(baseMaterial);
				mat.mainTexture = img;

				GameObject preFab;
				preFab = Instantiate (imagePrefab) as GameObject;

				//preFab.transform.position = new Vector3(transform.position.x,j*imageDistance,transform.position.z);

//				preFab.transform.position = new Vector3(Random.Range(-10.0F, 10.0F), Random.Range(-5.0F, 5.0F), Random.Range(-10.0F, 10.0F));
//				preFab.transform.rotation = Random.rotation;

				preFab.transform.position = new Vector3(Random.Range(-5f, 5.0f), Random.Range(-15.0f, -5.0f), Random.Range(-10.0f, 10.0f));
				preFab.transform.rotation = Quaternion.Euler(Random.Range(0.0f, 30.0f), Random.Range(150.0f, 180.0f), Random.Range(-30.0f, 30.0f));

				preFab.transform.parent = transform; 
				r = preFab.GetComponent<Renderer> ();

				// x width
				// z height

				//preFab.transform.local
				var tempScale = preFab.transform.localScale;

				tempScale.x = img.width / 10000f;
				tempScale.z = img.height / 10000f;

				preFab.transform.localScale = tempScale;

				r.material = mat;
			}
			j++;
		} while (img != null);


		// Create array of materials
		/*
		for (var i = 0; i < materials.Length; i++) {
			GameObject horseInstance;
			horseInstance = Instantiate (imagePrefab) as GameObject;
			horseInstance.transform.position = new Vector3(parent.transform.position.x,i*imageDistance,parent.transform.position.z);
			horseInstance.transform.parent = parent.transform; 
			r = horseInstance.GetComponent<Renderer> ();
			r.material = materials[i];
		}*/
	}
}

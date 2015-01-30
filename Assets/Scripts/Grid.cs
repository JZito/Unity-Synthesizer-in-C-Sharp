using UnityEngine;
using System.Collections;


 public class Grid : MonoBehaviour
 {
     public GameObject tile;
     public int GridWidth;
	 public int GridHeight;
	 public float countUpObject;

     void Start() {

     	for(int y=0;y<GridHeight;y++)
		{
			for(int x=0;x<GridWidth;x++)
			{
				
				countUpObject++;
				string countUpObjectString = countUpObject.ToString();
				Debug.Log(countUpObject);
				//this line below is offending line?
				GameObject g = Instantiate(tile,new Vector3(x,y,0),Quaternion.identity)as GameObject;
				g.GetComponent<SpriteRenderer>().color = new Color(0,1 - (countUpObject / 100),countUpObject / 100,0.25f);
				g.transform.parent = gameObject.transform;
				g.name = countUpObjectString;
				/*
				OnCube newCube = g.GetComponent<OnCube>();
				DisplayASequence displayASequence = g.GetComponent<DisplayASequence>();
				Reset reset = g.GetComponent<Reset>();
				var banana = g.GetComponent<AudioSource>();
				banana.clip = cubeSounds[CountUpObject - 1];
				g.name = "cube" +(CountUpObject);
				g.name.Replace("(OnCube)","").Trim();
				g.transform.parent = gameObject.transform;
				//g.renderer.enabled = false;
				newCube.row = y;
				newCube.col = x;
				displayASequence.row = y;
				reset.row = y;
				cubeList.Add(newCube);
				*/
			
			}
		}
     }
 }

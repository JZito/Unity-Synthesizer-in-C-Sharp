using UnityEngine;
using System.Collections;


 public class Grid : MonoBehaviour
 {
     public GameObject tile;
     public int GridWidth;
	 public int GridHeight;
	 public float CountUpObject;

     void Start() {

     	for(int y=0;y<GridHeight;y++)
		{
			for(int x=0;x<GridWidth;x++)
			{
				
				CountUpObject++;
				Debug.Log(CountUpObject);
				//this line below is offending line?
				GameObject g = Instantiate(tile,new Vector3(x,y,0),Quaternion.identity)as GameObject;
				g.GetComponent<SpriteRenderer>().color = new Color(0,1 - (CountUpObject / 100),CountUpObject / 100,1);
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

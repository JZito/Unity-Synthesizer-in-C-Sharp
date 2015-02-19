using UnityEngine;
using System.Collections;
using System.Collections.Generic;


 public class Grid : MonoBehaviour
 {
     public GameObject tile;
     public int GridWidth;
	 public int GridHeight;
	 public int countUpObject;
	 public List<GameObject> tiles = new List<GameObject>();
	 public List<float> note = new List<float> ();

     void Awake() {
		countUpObject = -1;

     	for(int y=0;y<GridHeight;y++)
		{
			for(int x=0;x<GridWidth;x++)
			{
				
				countUpObject++;
				string countUpObjectString = countUpObject.ToString();
				//Debug.Log(countUpObject);
				//this line below is offending line?
				GameObject g = Instantiate(tile,new Vector3(x,y,0),Quaternion.identity)as GameObject;
				//g.GetComponent<SpriteRenderer>().color = new Color(0,1 - (countUpObject / 100),countUpObject / 100,0.25f);
				g.transform.parent = gameObject.transform;
				g.GetComponent<TileDetails>().note = note[countUpObject];
				g.name = countUpObjectString;
				tiles.Add (g);

			
			}
		}
     }
 }

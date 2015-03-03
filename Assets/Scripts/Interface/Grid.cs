using UnityEngine;
using System.Collections;
using System.Collections.Generic;


 public class Grid : MonoBehaviour
 {
     public GameObject tile;
	 public Generate generate;
     public int GridWidth;
	 public int GridHeight;
	 public int countUpObject;
	 public int keyTile0;
	public int keyTile1;
	public int keytile2;
	public int keyTile3;
	public int doorTile0;
	public int doorTile1;
	public int doorTile2;
	public int doorTile3;
	 public List<GameObject> tiles = new List<GameObject>();
	 public List<float> note = new List<float> ();


     void Start() {
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
				var gScript = g.GetComponent<TileDetails>();
				//g.GetComponent<SpriteRenderer>().color = new Color(0,1 - (countUpObject / 100),countUpObject / 100,0.25f);
				g.transform.parent = gameObject.transform;
				gScript.note = note[countUpObject];
				g.name = countUpObjectString;
				tiles.Add (g);
				for (int i = 0; i < generate.movesList.Count; i++){
					//for (int j = 0; j < generate.movesList[i].Count; j++) {
						if (generate.movesList[i].Contains (countUpObject)) {
						gScript.path = true;
						g.GetComponent<SpriteRenderer>().color = gScript.pathColor;
					}
					else {
						gScript.path = false;
					}
				}
				if (countUpObject == 32) {
					gScript.activeFlag = true;
					g.GetComponent<SpriteRenderer>().color = gScript.flagColor;
				}
				if (countUpObject == keyTile0) {
					gScript.activeKey = true;
					g.GetComponent<SpriteRenderer>().color = gScript.keyColor;
				}
				if (countUpObject == doorTile0) {
					gScript.activeDoor = true;
					g.GetComponent<SpriteRenderer>().color = gScript.doorColor;
				}
			
			}
		}
     }
 }

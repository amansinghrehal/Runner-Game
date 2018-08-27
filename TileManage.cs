using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tileManager : MonoBehaviour
{
	public GameObject[] tilePrefabs;
	private Transform playerTransform;
	private float spawnZ=-9.0f;
	private float tileLength=9.0f;
	private int amtTiles=7;
	private List<GameObject> activeTiles;
	private float safe=10.f;
	private int lastPrefabIndex=0;
	void Start()
	{
		//making list for active tiles
		activeTiles=new List<GameObject>();
		//finding Player position using Tag attach to it
		playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
		for(int i=0;i<amtTiles;i++)
		{
			if(i<2)
			{
				SpawnTile(0);
			}
			else
			{
				SpawnTile();
			}	
		}
		
	}
	void Update()
	{
		//adding and removing tiles when player crose a particular distance
		if(playerTransform.position.z-safe>(spawnZ-amtTiles*tileLength))
		{
			SpawnTile();
			DeleteTile();
		}
	}
	private void SpawnTile(int prefabIndex=-1)
	{
		GameObject go;
		if(prefabIndex==-1)
		{
			// random tile instantiation
			go=Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
		}
		else
		{
			// tile instantiation of index 0
			go=Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		}
		// to set TileManager as the parent of all tiles 
		go.transform.SetParent(transform);
		//to add tiles next to existing tiles
		go.transform.position=Vector3.forward*spawnZ;
		//to increase the length of spawnZ for further addition of tiles
		spawnZ+=tileLength;
		// to add current tiles in active tile list
		activeTiles.add(go);
	}
	private void DeleteTile()
	{
		//destroy tile of index zero of the list from the scene
		Destroy(activeTiles[0]);
		//to remove first tile and rearrange the list
		activeTiles.RemoveAt(0);
	}
	private int RandomPrefabIndex()
	{
		//if there is only one tile then index one return
		if(tilePrefabs.Length==1)
		{
			return 0;
		}
		//randomly select the index of tiles
		int randomIndex=lastPrefabIndex;
		while(randomIndex==lastPrefabIndex)
		{
			randomIndex=Random.Range(0,tilePrefabs.length);
		}
		lastPrefabIndex=randomIndex;
		return randomIndex;
	}
}
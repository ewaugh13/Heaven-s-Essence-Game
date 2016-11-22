﻿using UnityEngine;
//using System.Collections;

public class EnemyMap : MonoBehaviour
{

    Texture2D map;

    public int height = 90;
    public int width = 160;
	private Vector2 anchor;
    private Rect region;
    private GameObject mapShower;
	GameObject player;

	public Sprite demonicIcon;
	public Sprite boomIcon;
	public Sprite fallenIcon;
	public Sprite spookIcon;
	private Texture2D enemyTexture;

	private Texture2D baseMap;
    // Use this for initialization
    void Start()
    {
        mapShower = GameObject.FindGameObjectWithTag("Map");
        map = new Texture2D(width, height, TextureFormat.RGBA32, false);
        map.filterMode = FilterMode.Point;

        region = new Rect(0f, 0f, map.width, map.height);
        anchor = new Vector2(map.width * .5f, map.height * .5f);
		player = GameObject.FindGameObjectWithTag ("Player");
		clearMap(Color.black);
    }

    // Update is called once per frame
    void Update()
    {
		//map = baseMap;
		clearMap(Color.black);
        //updateMap();
		placeEnemies();
        Sprite sprite = Sprite.Create(map, region, anchor);
        mapShower.GetComponent<UnityEngine.UI.Image>().sprite = sprite;

    }


	void clearMap(Color color)
    {
        map = new Texture2D(width, height, TextureFormat.RGBA32, false);
        map.filterMode = FilterMode.Point;
        Color fillColor = color;
        Color[] fillPixels = new Color[map.width * map.height];

        for (int i = 0; i < fillPixels.Length; i++)
        {
            fillPixels[i] = fillColor;
        }

        map.SetPixels(fillPixels);
    }

	void placeEnemies(){
		//Color[] colors;
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyDemonic"))
		{
			//Debug.Log("1 called");

			for (int i = 0; i < demonicIcon.texture.width; i++) {
				for (int j = 0; j < demonicIcon.texture.height; j++) {
					map.SetPixel((int)enemy.transform.position.x + width/2 + i, (int)enemy.transform.position.y + height/2+  j, demonicIcon.texture.GetPixel(i,j));
				}
			}
			//map.SetPixel((int)enemy.transform.position.x + width/2, (int)enemy.transform.position.y + height/2, Color.red);
		}

		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyFallen"))
		{
			//Debug.Log("2 called");
			map.SetPixel((int)enemy.transform.position.x + width / 2, (int)enemy.transform.position.y + height / 2, Color.green);
		}

		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyBoom"))
		{
			//Debug.Log("3 called");
			map.SetPixel((int)enemy.transform.position.x + width / 2, (int)enemy.transform.position.y + height / 2, Color.magenta);
		}

		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemySpook"))
		{
			//Debug.Log("4 called");
			map.SetPixel((int)enemy.transform.position.x + width / 2, (int)enemy.transform.position.y + height / 2, Color.yellow);
		}

		if (player != null) 
		{
			map.SetPixel ((int)player.transform.position.x + width / 2, (int)player.transform.position.y + height / 2, Color.blue);
		}
			

		map.Apply();

	}
    void updateMap()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyDemonic"))
        {
            //Debug.Log("1 called");
            map.SetPixel((int)enemy.transform.position.x + width/2, (int)enemy.transform.position.y + height/2, Color.red);
        }

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyFallen"))
        {
            //Debug.Log("2 called");
			map.SetPixel((int)enemy.transform.position.x + width / 2, (int)enemy.transform.position.y + height / 2, Color.green);
        }

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyBoom"))
        {
            //Debug.Log("3 called");
			map.SetPixel((int)enemy.transform.position.x + width / 2, (int)enemy.transform.position.y + height / 2, Color.magenta);
        }

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemySpook"))
        {
            //Debug.Log("4 called");
			map.SetPixel((int)enemy.transform.position.x + width / 2, (int)enemy.transform.position.y + height / 2, Color.yellow);
        }

		if (player != null) 
		{
			map.SetPixel ((int)player.transform.position.x + width / 2, (int)player.transform.position.y + height / 2, Color.blue);
		}

        map.Apply();

    }


}

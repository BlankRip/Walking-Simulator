using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] int width = 256;            //Width of the terrain (X axis scale size)
    [SerializeField] int hight = 256;            //Hight of the terrain (Z axis scale size)
    [SerializeField] int depth = 20;             //Depth of the terrain hight increases (Y azis scalsize)
    [SerializeField] float scale = 20;           //Zooming into so that the hight increases are much more clear
    [SerializeField] float offsetX;                         // X off set to pan the texture along X axis
    [SerializeField] float offsetY;                         // Y off set to pan the texture along Y axis
    Terrain terrain;

    //Getting the terrain component
    private void Start()
    {
        terrain = GetComponent<Terrain>();
    }

    //Updating date in update to check changes on go, once all set move this to start
    private void Update()
    {
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    //Function to generate terrain
    TerrainData GenerateTerrain(TerrainData data)
    {
        data.heightmapResolution = width + 1;
        data.size = new Vector3(width, depth, hight);                //Changing the size of the terrain
        data.SetHeights(0, 0, GenerateHights());                     //Using perlin noise setting to hight of each pixel or such 
        return data;
    }

    //Function to get an array of hights
    float[,] GenerateHights()
    {
        float[,] hights = new float[width, hight];
        //Adding a float value to the array for each point in
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < hight; y++)
            {
                hights[x, y] = CalculatingHight(x, y) *0.1f;
            }
        }
        return hights;
    }

    //Calculating the hight for a perticular point using perlin noise
    float CalculatingHight(int x, int y)
    {
        float perlinCordinateX = (float) x / width * scale + offsetX;
        float perlinCordinateY = (float) y / hight * scale + offsetY;
        //Generating 2D perlin noise based on the cordinate values and setting the hight value of that point
        float setHight = Mathf.PerlinNoise(perlinCordinateX, perlinCordinateY);
        return setHight;
    }
}

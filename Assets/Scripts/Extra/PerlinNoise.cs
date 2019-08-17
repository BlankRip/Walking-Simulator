using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    [SerializeField] int width = 256;                       //Pixels in width
    [SerializeField] int hight = 256;                       //Pixels in hight
    [SerializeField] float scale = 20;                      //Zooming into the pixels or making pixels large
    [SerializeField] float offSetX;                         // X off set to pan the texture along X axis
    [SerializeField] float offSetY;                         // Y off set to pan the texture along Y axis
    Renderer renderer;

    //Getting the mesh-renderer
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    //Setting the texture (can use in update to make changes when running game else do in Start)
    private void Update()
    {
        renderer.material.mainTexture = GenerateTexture();        
    }

    //Gererating texture with the perlinNoise
    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, hight);                 //Creating new texture
        //Looping through all the pixels and setting the colour of each pixel using perlin noise
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < hight; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();                                  //Applying the changes made to the texture
        return texture;
    }

    //Calculating the Colour for a perticular pixel using perlin noise
    Color CalculateColor(int x, int y)
    {
        //As pixels are 0(lit) or 1(unlit) we are making them be decimal numbers by devidin the x and y with the witdth and hight
        float perlinCordinatX = (float)x / width * scale + offSetX;
        float perlinCordinatY = (float)y / hight * scale +offSetY;
        //Generating 2D perlin noise based on the cordinate values of the pixel and setting the colour of the pixel based on it
        float sampleColor = Mathf.PerlinNoise(perlinCordinatX, perlinCordinatY);
        Color pixelColor = new Color(sampleColor, sampleColor, sampleColor);
        return pixelColor;

    }
}

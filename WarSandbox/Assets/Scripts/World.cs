using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public float MaxX;
    public float MaxY;
    public bool DrawBorder;
    public Sprite provinceBase;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < MaxX; i++)
        {
            for(int e = 0; e < MaxY; e++)
            {
                var prov = Instantiate(new GameObject($"Square{i}{e}"), new Vector3(i * 10, e * 10), Quaternion.identity);
                var newBox = prov.AddComponent<BoxCollider2D>();
                newBox.isTrigger = true;
                newBox.size = new Vector2(10, 10);
                var newRend = prov.AddComponent<SpriteRenderer>();
                newRend.sprite = provinceBase;
                var newProvScript = prov.AddComponent<Province>();


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrawGizmosSelected()
    {
        if (DrawBorder)
        {
            Gizmos.DrawCube(new Vector3(0, 0), new Vector3(MaxX, MaxY));
        }
        
    }
}

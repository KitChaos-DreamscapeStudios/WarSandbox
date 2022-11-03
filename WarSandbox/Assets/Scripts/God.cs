using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public Camera main;
    float horizontal;
    float vertical;
    public float CameraSpeed;
    public World world;
    public Vector2 Scroll;
    public float Zoom;
    public GameObject pen;
    public List<GameObject> Pens;
    int PenIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        pen = Pens[PenIndex];
        if(Input.GetKeyDown(".") && PenIndex < Pens.Count || Input.GetKeyDown("e") && PenIndex < Pens.Count)
        {
            PenIndex += 1;
        }
        if (Input.GetKeyDown(",") && PenIndex > 0 || Input.GetKeyDown("q") && PenIndex > Pens.Count)
        {
            PenIndex -= 1;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Scroll = Input.mouseScrollDelta;
        //Debug.Log(Input.mouseScrollDelta);
        Zoom += Scroll.y * 2;
        main.orthographicSize = 5 + -Zoom;
        if (Input.GetMouseButton(0))
        {
            Instantiate(pen, new Vector3(main.ScreenToWorldPoint(Input.mousePosition).x, main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.identity);
        }
        #region Checks
        if (transform.position.x > world.MaxX)
        {
            transform.position += new Vector3(-CameraSpeed*2, 0);
        }
        if (transform.position.y > world.MaxY)
        {
            transform.position += new Vector3(0, -CameraSpeed *2);
        }
        if (transform.position.x < -world.MaxX)
        {
            transform.position += new Vector3(CameraSpeed * 2, 0);
        }
        if (transform.position.y < -world.MaxY)
        {
            transform.position += new Vector3(0, CameraSpeed * 2);
        }
        if(main.orthographicSize > 100)
        {
            main.orthographicSize = 99;
        }
        if (main.orthographicSize < 5)
        {
            main.orthographicSize = 5;
        }
        if(Zoom > 0)
        {
            Zoom = 0;
        }
        if (Zoom < -100)
        {
            Zoom = -100;
        }
        #endregion
    }
    
    private void FixedUpdate()
    {
        transform.position += new Vector3(horizontal * CameraSpeed, vertical * CameraSpeed);
    }
}

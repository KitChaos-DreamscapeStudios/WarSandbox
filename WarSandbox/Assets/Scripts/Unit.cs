using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public LayerMask terrain;
    public TerrainType terrainOn;
    public Country Owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(origin: new Vector3(transform.position.x, transform.position.y, -8), direction: new Vector3(0, 0, 1000), hitInfo: out hit,1000,terrain, queryTriggerInteraction: QueryTriggerInteraction.Collide);
        Debug.Log(hit.collider.gameObject.name);
        terrainOn = hit.collider.GetComponent<Terrain>().terrainType;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y, -8), direction: new Vector3(0, 0, 10));
    }
}

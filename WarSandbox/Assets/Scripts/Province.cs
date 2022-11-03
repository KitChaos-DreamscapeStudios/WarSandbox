using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Province : MonoBehaviour
{
    public List<Unit> UnitsIn;
    public Country Owner;
    public Country CurrentLeader;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Owner != null)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Owner.color;
        }
        var count = new Dictionary<Country, float>();
        Country Dummy = GameObject.Find("Dummy").GetComponent<Country>();
        if (CurrentLeader == null)
        {
            CurrentLeader = Dummy;
        }

        //count.Add(Dummy, 0);


        for (int i = 0; i < UnitsIn.Count; i++)
        {
            if (count.ContainsKey(UnitsIn[i].Owner))
            {
                count[UnitsIn[i].Owner] += 1;
            }
            else
            {
                count.Add(UnitsIn[i].Owner, 1);
            }
        }

        foreach (KeyValuePair<Country, float> Claim in count)
        {
            if (!count.ContainsKey(CurrentLeader))
            {
                CurrentLeader = Dummy;
            }
            if (CurrentLeader == Dummy)
            {
                CurrentLeader = Claim.Key;
            }
            else if (Claim.Value > count[CurrentLeader])
            {
                CurrentLeader = Claim.Key;
            }

        }
        if (CurrentLeader != Dummy)
        {
            Owner = CurrentLeader;
        }
        if (Owner != null && !Owner.OwnedTerritory.Contains(gameObject))
        {
            Owner.OwnedTerritory.Add(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        UnitsIn.Add(col.gameObject.GetComponent<Unit>());
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        UnitsIn.Remove(col.gameObject.GetComponent<Unit>());
    }
}

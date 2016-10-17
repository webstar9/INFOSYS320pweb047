using UnityEngine;
using System.Collections;

public class DisplayPanel : MonoBehaviour {
    public GameObject player;
    public Material[] material;
    public Renderer rend;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<Inventories>().pressedItemColor == "Very High")
        {
            this.rend.sharedMaterial = material[3];
        }
        else if (player.GetComponent<Inventories>().pressedItemColor == "High")
        {
            this.rend.sharedMaterial = material[2];
        }
        else if (player.GetComponent<Inventories>().pressedItemColor == "Medium")
        {
            this.rend.sharedMaterial = material[1];
        }
        else if (player.GetComponent<Inventories>().pressedItemColor == "Low")
        {
            this.rend.sharedMaterial = material[0];
        }
        else
        {
            this.rend.sharedMaterial = material[4];
        }

        if (player.GetComponent<Inventories>().pressedItemColor == "")
        {
            GetComponentInChildren<TextMesh>().text = "";
        }
        else
        {
            GetComponentInChildren<TextMesh>().text = player.GetComponent<Inventories>().pressedItem;
        }
    }
}

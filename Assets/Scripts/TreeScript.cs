using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour
{

    public Vector3 tree1stLocation = new Vector3(0, 0, 0);
    
    // used for the rendering and interaction
    public string treeCatergory;
    public string treeLocation;
    public int treeID;
    public int treeSignificance;
    public bool treeInteract;
    public Material[] material;
    public Renderer rend;
    public GameObject player;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

    }

    void OnMouseDown()
    {
        // Use this to form part of the Select Object part of the Test
        if (treeInteract == true)
        {
        treeInteract = false;
        player.GetComponent<Inventories>().pressedItem = treeLocation;
        player.GetComponent<Inventories>().pressedItemColor = treeCatergory;
        }
        else
        {
        treeInteract = true;
        player.GetComponent<Inventories>().pressedItem = treeLocation;
        player.GetComponent<Inventories>().pressedItemColor = treeCatergory;
        }
    }
    void Update()
    {
        // Rendering each objects colour based on the catergory of the tree
        if (treeCatergory == "Very High")
        {
            this.rend.sharedMaterial = material[3];
        }
        else if (treeCatergory == "High")
        {
            this.rend.sharedMaterial = material[2];
        }
        else if (treeCatergory == "Medium")
        {
            this.rend.sharedMaterial = material[1];
        }
        else
        {
            this.rend.sharedMaterial = material[0];
        }

        if (treeInteract == false)
        {
            GetComponentInChildren<TextMesh>().characterSize = 0.2f;
            GetComponentInChildren<TextMesh>().text = treeCatergory;
        }
        else
        {
            GetComponentInChildren<TextMesh>().characterSize = 0.5f;
            GetComponentInChildren<TextMesh>().text = treeLocation;
        }

    }
    }

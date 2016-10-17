using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
    // Put your URL here
    public string _WebsiteURL = "http://infosys320pweb047.azurewebsites.net/tables/TreeSurvey?ZUMO-API-VERSION=2.0.0";


    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);


        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        TreeSurvey[] tSurvey = JsonReader.Deserialize<TreeSurvey[]>(jsonResponse);

        int i = 0;
        //We can now loop through the array of objects and access each object individually
        foreach (TreeSurvey survey in tSurvey)
        {
            //Example of how to use the object
            Debug.Log("This polutionID is: " + survey.TreeID);
            i++;

            // x,y,z based on the TreeSurvey file in Azure, and then set in the GameObject
            int x = survey.X;
            int y = survey.Y;
            int z = survey.Z;
            GameObject newTree = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);

            // Used to set public variable of each tree, for use with other scripts
            newTree.GetComponent<TreeScript>().treeCatergory= survey.EcologicalValue;
            newTree.GetComponent<TreeScript>().treeID = survey.TreeID;
            newTree.GetComponent<TreeScript>().treeLocation = survey.Location;
            newTree.GetComponent<TreeScript>().treeSignificance = survey.HistoricalSignificance;

            // This is part of the Put a Label on Each Point section of the test
            newTree.GetComponentInChildren<TextMesh>().text = survey.EcologicalValue;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

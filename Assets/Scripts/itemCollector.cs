using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class itemCollector : MonoBehaviour
{
    public int collectedItems = 0; 
    public TMP_Text collectedItemsText; 
    private List<Vector3> collectiblePositions = new List<Vector3>();
    private List<GameObject> collectibles = new List<GameObject>();

    void Start()
    {
        UpdateUI();
        foreach (GameObject collectible in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            collectiblePositions.Add(collectible.transform.position);
            collectibles.Add(collectible);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D collider in hitColliders)
            {
                if (collider.CompareTag("Collectible"))
                {
                    CollectItem(collider.gameObject);
                }
            }
        }
    }

    void CollectItem(GameObject item)
    {
        collectedItems++; 
        UpdateUI(); 
        item.SetActive(false); 
    }

    public void ResetCollectedItems()
    {
        collectedItems = 0; 
        UpdateUI(); 

        for (int i = 0; i < collectibles.Count; i++)
        {
            collectibles[i].transform.position = collectiblePositions[i];
            collectibles[i].SetActive(true);
        }
    }

    void UpdateUI()
    {
        collectedItemsText.text = "Cristals Collected: " + collectedItems;
    }

}



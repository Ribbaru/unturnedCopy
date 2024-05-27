using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherResources : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask layerMask;
    public InventoryManager inventoryManager;
    public int resourceAmount;
    public ItemScriptableObject resource;
    public GameObject hitFX;
    public void GatherResource()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if(Physics.Raycast(ray, out hit, 1.5f, layerMask))
        {
            if(resource.name == hit.collider.GetComponent<ResourceHealth>().resourceType.name)
            {
                if (hit.collider.GetComponent<ResourceHealth>().health >= 1)
                {
                    Instantiate(hitFX, hit.point, Quaternion.Euler(hit.normal));
                    inventoryManager.AddItem(resource, resourceAmount);
                    hit.collider.GetComponent<ResourceHealth>().health--;
                    if (hit.collider.GetComponent<ResourceHealth>().health <= 0 && hit.collider.gameObject.layer == 6)
                    {
                        hit.collider.GetComponent<ResourceHealth>().TreeFall();
                        hit.collider.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * 10, ForceMode.Impulse);
                    }
                    if (hit.collider.GetComponent<ResourceHealth>().health <= 0 && hit.collider.gameObject.layer == 8)
                    {
                        hit.collider.GetComponent<ResourceHealth>().StoneGathered();
                    }

                }
            }


        }
    }
}

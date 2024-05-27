using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{


    public bool axeCanAttack = true;

    public Animator anim;

    public InventoryManager inventoryManager;
    public QuickslotInventory quickslotInventory;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && axeCanAttack)
        {
                if (quickslotInventory.activeSlot != null)
                {
                    if (quickslotInventory.activeSlot.item != null)
                    {
                        if (quickslotInventory.activeSlot.item.itemType == ItemType.Instrument)
                        {
                            if (inventoryManager.isOpened == false)
                            {
                                axeCanAttack = true;
                                StartCoroutine(AxeAttack());
                            }
                        }
                    }
                }
        }
    }

    IEnumerator AxeAttack()
    {


        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // Создаем луч из центра экрана
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.7f))
        {
            
        }

        anim.SetBool("axeAttack", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("axeAttack", false);
        axeCanAttack = false; // Устанавливаем перезарядку
        yield return new WaitForSeconds(1);
        axeCanAttack = true; // Перезарядка завершена

    }
}

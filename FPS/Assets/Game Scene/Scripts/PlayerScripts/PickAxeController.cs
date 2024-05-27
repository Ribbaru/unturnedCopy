using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeController : MonoBehaviour
{


    public bool PickAxeCanAttack = true;

    public Animator anim;

    public InventoryManager inventoryManager;
    public QuickslotInventory quickslotInventory;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PickAxeCanAttack)
        {
            if (quickslotInventory.activeSlot != null)
            {
                if (quickslotInventory.activeSlot.item != null)
                {
                    if (quickslotInventory.activeSlot.item.itemType == ItemType.Instrument)
                    {
                        if (inventoryManager.isOpened == false)
                        {
                            PickAxeCanAttack = true;
                            StartCoroutine(PickAxeAttack());
                        }
                    }
                }
            }
        }
    }

    IEnumerator PickAxeAttack()
    {


        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // ������� ��� �� ������ ������
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.7f))
        {

        }

        anim.SetBool("pickAxeAttack", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("pickAxeAttack", false);
        PickAxeCanAttack = false; // ������������� �����������
        yield return new WaitForSeconds(1);
        PickAxeCanAttack = true; // ����������� ���������

    }
}

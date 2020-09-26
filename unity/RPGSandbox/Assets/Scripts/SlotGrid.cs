using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotGrid : MonoBehaviour
{
    public int SlotsTotal;
    public int SlotsPerRow;
    public int SlotSize;
    public int SlotSpacing;

    int slotStagger;

    List<GameObject> slots;

    void Start()
    {
        slotStagger = SlotSpacing + SlotSize;

        for (var i = 0; i < SlotsTotal; i++)
        {
            GameObject slot = CreateSlot(i);
        }

        int rows = SlotsTotal % SlotsPerRow + 1;
        int columns = SlotsTotal > SlotsPerRow ? SlotsPerRow : SlotsTotal;
        GetComponent<RectTransform>().sizeDelta = new Vector2(columns * slotStagger + SlotSpacing, rows * slotStagger + SlotSpacing);
    }

    void Update()
    {
        
    }

    GameObject CreateSlot(int slotIndex)
    {
        GameObject slot = new GameObject();
        slot.name = $"Slot #{slotIndex + 1}";
        slot.AddComponent<CanvasRenderer>();
        RectTransform slotTransform = slot.AddComponent<RectTransform>();
        slotTransform.SetParent(this.transform);

        int startingPoint = SlotSize / 2 + SlotSpacing;
        int x = slotIndex % SlotsPerRow;
        int y = slotIndex / SlotsPerRow;
        slotTransform.localPosition = new Vector3(startingPoint + x * slotStagger, -(startingPoint + y * slotStagger), 0);

        slotTransform.sizeDelta = new Vector2(SlotSize, SlotSize);
        slotTransform.anchorMin = new Vector2(0, 1);
        slotTransform.anchorMax = new Vector2(0, 1);
        slotTransform.pivot = new Vector2(0.5f, 0.5f);

        Image slotImage = slot.AddComponent<Image>();
        slotImage.color = new Color32(0, 0, 0, 200);

        return slot;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUIComponent : MonoBehaviour
{
    public PlayerResourcesController PlayerResourcesController;
    public GameResourceType ResourceType;

    // Start is called before the first frame update
    public TMP_Text Label;

    void Start()
    {
        PlayerResourcesController.UpdateWallet += UpdateText;
    }

    private void UpdateText(GameResourceType gameResourceType, int i)
    {
        if (ResourceType == gameResourceType)
        {
            Label.text = i.ToString();
        }
    }
}

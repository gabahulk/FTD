using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGivingBehaviour : MonoBehaviour
{
    public PlayerResourcesController PlayerResourcesController;
    public HealthComponent HealthComponent;
    public GameResourceType ResourceType;
    public int ResourceQuantity;

    private void Awake()
    {
        HealthComponent.Death += GiveResource;
    }
    
    private void OnDestroy()
    {
        HealthComponent.Death -= GiveResource;
    }

    private void GiveResource()
    {
        PlayerResourcesController.AddResource(ResourceType, ResourceQuantity);    
    }
}
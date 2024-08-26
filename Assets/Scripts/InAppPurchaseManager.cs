using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;
using UnityEngine.Purchasing.Extension;

public class InAppPurchaseManager : MonoBehaviour,IDetailedStoreListener
{
    public string goldProductID = "com.DefaultCompany.Online-Services.Gold1";
    public string diamondProductID = "com.DefaultCompany.Online-Services.Diamond1";

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Initialize Sucess");
        storeController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        OnInitializeFailed(error,"InitializedFailed");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Initialize Failed");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchase Failed");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        OnPurchaseFailed(product, PurchaseFailureReason.UserCancelled);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;

        if (product.definition.id == goldProductID)
        {
            AddGold();
        }

        else if (product.definition.id == diamondProductID)
        {
            AddDiamond();
        }

        return PurchaseProcessingResult.Complete;
    }

    public void AddGold()
    {
        Debug.Log("Gold Added");
    }

    public void AddDiamond()
    {
        Debug.Log("Diamond Added");
    }

    IStoreController storeController;

    public void InitializePurchase()
    {
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(goldProductID, ProductType.Consumable);
        builder.AddProduct(diamondProductID, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void GoldPurchase()
    {
        storeController.InitiatePurchase(goldProductID);
    }

    public void DiamondPurchase()
    {
        storeController.InitiatePurchase(diamondProductID);
    }
    // Start is called before the first frame update
    void Start()
    {
        InitializePurchase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

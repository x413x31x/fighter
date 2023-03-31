using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour
{
    public UnityEvent _onGoldButtonPressed;
    public UnityEvent _onWinsButtonPressed;

    public void OnGoldPurchaseComplene(Product product)
    {
        if(product.definition.id == "com.413x31.fighter.1000coins")
        {
            _onGoldButtonPressed.Invoke();
        }
    }

    public void OnWinsPurchaseComplene(Product product)
    {
        if (product.definition.id == "com.413x31.fighter.1win")
        {
            _onWinsButtonPressed.Invoke();
        }
    }
}

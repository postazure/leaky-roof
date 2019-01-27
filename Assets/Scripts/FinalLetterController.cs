using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLetterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int itemsFound = ScoreController.instance.FoundItemCount();
        gameObject.SetActive(itemsFound >= 10);
    }


}

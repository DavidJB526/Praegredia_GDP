using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDemo : MonoBehaviour
{

    [SerializeField]
    InventoryObject key;

    [SerializeField]
    CanvasGroup uiElement;

    [SerializeField]
    GameObject uiOverlay;

    private List<InventoryObject> playerInventory;

    private bool HasKey
    {
        get
        {
            return playerInventory.Contains(key);
        }
    }

	// Use this for initialization
	void Start ()
    {
        playerInventory = FindObjectOfType<InventoryMenu>().PlayerInventory;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && HasKey)
        {
            StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            uiOverlay.SetActive(false);
        }
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1f)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while(true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Title");
    }
}

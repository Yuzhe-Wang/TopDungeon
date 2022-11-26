using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // text fields
    public Text levelText, hitpointText, pesosText, upgradeCostText, xpText;

    // logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // character selection
    public void OnArrowClick(bool isRight)
    {
        if(isRight)
        {
            currentCharacterSelection += 1;
            if(currentCharacterSelection == GameManager.manager.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }
            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection -= 1;
            if (currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.manager.playerSprites.Count - 1;
            }
            OnSelectionChanged();
        }
    }

    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.manager.playerSprites[currentCharacterSelection];
    }

    // weapon upgrade
    public void OnUpgradeClick()
    {

    }

    // update character information
    public void UpdateMenu()
    {
        // weapon
        weaponSprite.sprite = GameManager.manager.weaponSprites[0];
        upgradeCostText.text = "NOT IMPLEMENTED";

        // meta
        levelText.text = "NOT IMPLEMENTED";
        hitpointText.text = GameManager.manager.player.hitpoint.ToString();
        pesosText.text = GameManager.manager.pesos.ToString();

        // xp bar
        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
}

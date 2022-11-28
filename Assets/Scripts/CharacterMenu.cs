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
        GameManager.manager.player.SwapSprite(currentCharacterSelection);
    }

    // weapon upgrade
    public void OnUpgradeClick()
    {
        if(GameManager.manager.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    // update character information
    public void UpdateMenu()
    {
        // weapon
        weaponSprite.sprite = GameManager.manager.weaponSprites[GameManager.manager.weapon.weaponLevel];
        if(GameManager.manager.weapon.weaponLevel == GameManager.manager.weaponPrices.Count)
        {
            upgradeCostText.text = "MAX";
        }
        else
        {
            upgradeCostText.text = GameManager.manager.weaponPrices[GameManager.manager.weapon.weaponLevel].ToString();
        }

        // meta
        levelText.text = GameManager.manager.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.manager.player.hitpoint.ToString();
        pesosText.text = GameManager.manager.pesos.ToString();

        // xp bar
        int currLevel = GameManager.manager.GetCurrentLevel();
        if (currLevel == GameManager.manager.xpTable.Count)
        {
            xpText.text = GameManager.manager.experience.ToString() + " total experience points";
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.manager.GetXpToLevel(currLevel-1);
            int currLevelXp = GameManager.manager.GetXpToLevel(currLevel);
            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.manager.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff.ToString();
        }
    }
}

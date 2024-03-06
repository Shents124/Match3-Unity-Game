using UnityEngine;
using static BonusItem;
using static NormalItem;

[CreateAssetMenu(fileName = "New TextureSO", menuName = "Scriptable Object/New TextureSO")]
public class TextureSO : ScriptableObject
{
    [SerializeField] private Sprite normalItemSpriteOne;
    [SerializeField] private Sprite normalItemSpriteTwo;
    [SerializeField] private Sprite normalItemSpriteThree;
    [SerializeField] private Sprite normalItemSpriteFour;
    [SerializeField] private Sprite normalItemSpriteFive;
    [SerializeField] private Sprite normalItemSpriteSix;
    [SerializeField] private Sprite normalItemSpriteSeven;

    [SerializeField] private Sprite bonusItemSpriteHorizontal;
    [SerializeField] private Sprite bonusItemSpriteVertical;
    [SerializeField] private Sprite bonusItemSpriteBomb;

    public Sprite GetNormalItemSprite(eNormalType normalType)
    {
        return normalType switch
        {
            eNormalType.TYPE_ONE => normalItemSpriteOne,
            eNormalType.TYPE_TWO => normalItemSpriteTwo,
            eNormalType.TYPE_THREE => normalItemSpriteThree,
            eNormalType.TYPE_FOUR => normalItemSpriteFour,
            eNormalType.TYPE_FIVE => normalItemSpriteFive,
            eNormalType.TYPE_SIX => normalItemSpriteSix,
            eNormalType.TYPE_SEVEN => normalItemSpriteSeven,
            _ => null,
        };
    }

    public Sprite GetBonusItemSprite(eBonusType bonusType)
    {
        return bonusType switch
        {
            eBonusType.HORIZONTAL => bonusItemSpriteHorizontal,
            eBonusType.VERTICAL => bonusItemSpriteVertical,
            eBonusType.ALL => bonusItemSpriteBomb,
            _ => null,
        };
    }
}

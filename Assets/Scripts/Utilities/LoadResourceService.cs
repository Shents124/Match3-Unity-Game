using UnityEngine;
using static BonusItem;
using static NormalItem;

public class LoadResourceService 
{
    private static TextureSO s_fishTexture;

    public static void LoadTextureSO()
    {
        s_fishTexture = Resources.Load<TextureSO>(Constants.FISH_TEXTURES);
    }

    public static Sprite LoadFishSprite(eNormalType normalType)
    {
        if (s_fishTexture == null)
            LoadTextureSO();

        return s_fishTexture.GetNormalItemSprite(normalType);
    }

    public static Sprite LoadBonusItemSprite(eBonusType bonusType)
    {
        if (s_fishTexture == null)
            LoadTextureSO();

        return s_fishTexture.GetBonusItemSprite(bonusType);
    }
}

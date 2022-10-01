using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [Header("Skin")]
    public SkinnedMeshRenderer bodyRend;
    private BodyMaterialID bodyMatID;

    private PantSkinID pantSkinID;
    public SkinnedMeshRenderer pantRend;

    private HatSkinID hatSkinID;
    private Item hatItem;
    public Transform hatHolder;

    private ShieldSkinID shieldSkinID;
    private Item shieldItem;
    public Transform shieldHolder;

    public Transform tailHolder;
    private Item tailItem;
    private TailSkinID tailSkinID;

    public Transform wingHolder;
    private Item wingItem;
    private WingSkinID wingSkinID;

    public void OnInit()
    {
        SetItems();
    }

    public void SetItems()
    {
        InitWing();
        InitTail();
        InitBody();
        InitPant();
        InitHat();
        InitShield();
    }

    #region Initialize Skin
    private void InitPant()
    {
        if (PlayerPrefs.HasKey(Constant.SELECTED_PANT))
            pantSkinID = (PantSkinID)PlayerPrefs.GetInt(Constant.SELECTED_PANT);
        else
            pantSkinID = (PantSkinID)0;

        Material pantMat = SkinController.Ins.GetPantMaterial(pantSkinID);
        var materials = pantRend.sharedMaterials;
        materials[0] = pantMat;
        pantRend.sharedMaterials = materials;
    }

    private void InitHat()
    {
        if (hatItem != null)
            Destroy(hatItem.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_HAT))
            hatSkinID = (HatSkinID)PlayerPrefs.GetInt(Constant.SELECTED_HAT);
        else
            hatSkinID = (HatSkinID)0;

        hatItem = ItemController.Ins.SetHat(hatSkinID, hatHolder);
    }

    private void InitShield()
    {
        if (shieldItem != null)
            Destroy(shieldItem.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_SHIELD))
            shieldSkinID = (ShieldSkinID)PlayerPrefs.GetInt(Constant.SELECTED_SHIELD);
        else
            shieldSkinID = (ShieldSkinID)0;

        shieldItem = ItemController.Ins.SetShield(shieldSkinID, shieldHolder);
    }

    private void InitBody()
    {
        if (PlayerPrefs.HasKey(Constant.SELECTED_BODY))
            bodyMatID = (BodyMaterialID)PlayerPrefs.GetInt(Constant.SELECTED_BODY);
        else
            bodyMatID = (BodyMaterialID)0;

        Material bodyMat = SkinController.Ins.GetBodyMaterial(bodyMatID);
        var materials = bodyRend.sharedMaterials;
        materials[0] = bodyMat;
        bodyRend.sharedMaterials = materials;
    }

    private void InitTail()
    {
        if (tailItem != null)
            Destroy(tailItem.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_TAIL))
            tailSkinID = (TailSkinID)PlayerPrefs.GetInt(Constant.SELECTED_TAIL);
        else
            tailSkinID = (TailSkinID)0;

        tailItem = ItemController.Ins.SetTail(tailSkinID, tailHolder);
    }

    private void InitWing()
    {
        if (wingItem != null)
            Destroy(wingItem.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_WING))
            wingSkinID = (WingSkinID)PlayerPrefs.GetInt(Constant.SELECTED_WING);
        else
            wingSkinID = (WingSkinID)0;

        wingItem = ItemController.Ins.SetWing(wingSkinID, wingHolder);
    }
    #endregion

    #region Change Skin
    public void ChangePant()
    {
        if (PlayerPrefs.HasKey(Constant.SELECTED_PANT))
            pantSkinID = (PantSkinID)PlayerPrefs.GetInt(Constant.SELECTED_PANT);
        else
            pantSkinID = (PantSkinID)0;

        Material pantMat = SkinController.Ins.GetPantMaterial(pantSkinID);
        var materials = pantRend.sharedMaterials;
        materials[0] = pantMat;
        pantRend.sharedMaterials = materials;
    }

    public void TryPant(PantSkinID pantSkinID)
    {
        Material pantMat = SkinController.Ins.GetPantMaterial(pantSkinID);
        var materials = pantRend.sharedMaterials;
        materials[0] = pantMat;
        pantRend.sharedMaterials = materials;
    }

    public void ChangeHat()
    {
        if (hatItem != null)
            Destroy(hatItem.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_HAT))
            hatSkinID = (HatSkinID)PlayerPrefs.GetInt(Constant.SELECTED_HAT);
        else
            hatSkinID = (HatSkinID)0;

        hatItem = ItemController.Ins.SetHat(hatSkinID, hatHolder);
    }

    public void TryHat(HatSkinID hatSkinID)
    {
        if (hatItem != null)
            Destroy(hatItem.gameObject);

        hatItem = ItemController.Ins.SetHat(hatSkinID, hatHolder);
    }

    public void ChangeShield()
    {
        if (shieldItem != null)
            Destroy(shieldItem.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_SHIELD))
            shieldSkinID = (ShieldSkinID)PlayerPrefs.GetInt(Constant.SELECTED_SHIELD);
        else
            shieldSkinID = (ShieldSkinID)0;

        shieldItem = ItemController.Ins.SetShield(shieldSkinID, shieldHolder);
    }

    public void TryShield(ShieldSkinID shieldSkinID)
    {
        if (shieldItem != null)
            Destroy(shieldItem.gameObject);

        shieldItem = ItemController.Ins.SetShield(shieldSkinID, shieldHolder);
    }

    public void ChangeBody()
    {
        if (PlayerPrefs.HasKey(Constant.SELECTED_BODY))
            bodyMatID = (BodyMaterialID)PlayerPrefs.GetInt(Constant.SELECTED_BODY);
        else
            bodyMatID = (BodyMaterialID)0;

        Material bodyMat = SkinController.Ins.GetBodyMaterial(bodyMatID);
        var materials = bodyRend.sharedMaterials;
        materials[0] = bodyMat;
        bodyRend.sharedMaterials = materials;
    }

    public void TryBody(BodyMaterialID bodyMatId)
    {
        Material bodyMat = SkinController.Ins.GetBodyMaterial(bodyMatId);
        var materials = bodyRend.sharedMaterials;
        materials[0] = bodyMat;
        bodyRend.sharedMaterials = materials;
    }

    public void ChangeTail()
    {
        if (tailItem != null)
            Destroy(tailItem.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_TAIL))
            tailSkinID = (TailSkinID)PlayerPrefs.GetInt(Constant.SELECTED_TAIL);
        else
            tailSkinID = (TailSkinID)0;

        tailItem = ItemController.Ins.SetTail(tailSkinID, tailHolder);
    }

    public void TryTail(TailSkinID tailSkinID)
    {
        if (tailItem != null)
            Destroy(tailItem.gameObject);

        tailItem = ItemController.Ins.SetTail(tailSkinID, tailHolder);
    }

    public void ChangeWing()
    {
        if (wingItem != null)
            Destroy(wingItem.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_WING))
            wingSkinID = (WingSkinID)PlayerPrefs.GetInt(Constant.SELECTED_WING);
        else
            wingSkinID = (WingSkinID)0;

        wingItem = ItemController.Ins.SetWing(wingSkinID, wingHolder);
    }

    public void TryWing(WingSkinID wingSkinID)
    {
        if (wingItem != null)
            Destroy(wingItem.gameObject);

        wingItem = ItemController.Ins.SetWing(wingSkinID, wingHolder);
    }
    #endregion
}

using UnityEngine;

public class MenuPlayerUIManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private ItemManager itemManager = null;
    [SerializeField] private Animator animator = null;

    [Header("PlayerBody")]
    [SerializeField] private Transform headBasicHelmet = null;
    [SerializeField] private Transform headSpecialHelmet = null;
    [SerializeField] private Transform torso = null;
    [SerializeField] private GameObject lowerTorsoArmor = null;
    [SerializeField] private Transform handR = null;
    [SerializeField] private Transform handL = null;

    private Armor armorHelmetPrefab = null;
    private Armor armorTorsoPrefab = null;
    private Armor currentArmorHelmet = null;
    private Armor currentArmorTorso = null;
    private Weapon weaponPrefab = null;
    private Weapon currentWeapon = null;
    private Weapon currentSecondWeapon = null;
    private WeaponTypeHandedEnum weaponTypeHanded;
    private WeaponTypeEnum weaponType;

    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        lowerTorsoArmor.SetActive(false);
    }

    public void AttachWeapon()
    {
        RemovePreviousWeapon();
        weaponTypeHanded = itemManager.CurrentWeapon.GetWeaponTypeHanded();
        weaponType = itemManager.CurrentWeapon.GetWeaponType();
        weaponPrefab = itemManager.CurrentWeaponPrefab;

        currentWeapon = Instantiate<Weapon>(weaponPrefab);

        switch(weaponType)
        {
            case WeaponTypeEnum.LANCE:
                SetLanceTransform();
                break;

            case WeaponTypeEnum.HAMMER:
                SetHammerTransform();
                break;

            case WeaponTypeEnum.DAGGERS:
                SetRightDaggerTransform();
                break;

            case WeaponTypeEnum.SHORTSWORD:
                SetShortswordTransform();
                break;

            case WeaponTypeEnum.LONGSWORD:
                SetLongswordTransform();
                break;
        }

        AddLayerToChildren(currentWeapon.transform, LayerMask.NameToLayer("PlayerRender"));

        if (weaponTypeHanded == WeaponTypeHandedEnum.BOTH)
        {
            currentSecondWeapon = Instantiate<Weapon>(weaponPrefab);
            SetLeftDaggerTransform();
            AddLayerToChildren(currentSecondWeapon.transform, LayerMask.NameToLayer("PlayerRender"));
            
        }
        SetAnimation();
    }

    public void AttachTorsoArmor()
    {
        lowerTorsoArmor.SetActive(true);

        RemovePreviousTorsoArmor();
        armorTorsoPrefab = itemManager.CurrentTorsoArmorPrefab;

        currentArmorTorso = Instantiate<Armor>(armorTorsoPrefab);
        currentArmorTorso.transform.parent = torso.transform;
        currentArmorTorso.transform.position = torso.position;
        currentArmorTorso.transform.rotation = torso.transform.rotation;
        currentArmorTorso.transform.localScale = new Vector3(1, 1, 1);
        AddLayerToChildren(currentArmorTorso.transform, LayerMask.NameToLayer("PlayerRender"));
    }

    public void AttachBasicHelmet()
    {
        RemovePreviousHelmet();
        armorHelmetPrefab = itemManager.CurrentHelmetPrefab;

        currentArmorHelmet = Instantiate<Armor>(armorHelmetPrefab);
        currentArmorHelmet.transform.parent = headBasicHelmet.transform;
        currentArmorHelmet.transform.position = headBasicHelmet.position;
        currentArmorHelmet.transform.rotation = headBasicHelmet.rotation;
        currentArmorHelmet.transform.localScale = new Vector3(1, 1, 1);
        AddLayerToChildren(currentArmorHelmet.transform, LayerMask.NameToLayer("PlayerRender"));
    }

    public void AttachSpecialHelmet()
    {
        RemovePreviousHelmet();
        armorHelmetPrefab = itemManager.CurrentHelmetPrefab;

        currentArmorHelmet = Instantiate<Armor>(armorHelmetPrefab);
        currentArmorHelmet.transform.parent = headSpecialHelmet.transform;
        currentArmorHelmet.transform.position = headSpecialHelmet.position;
        currentArmorHelmet.transform.rotation = headSpecialHelmet.rotation;
        currentArmorHelmet.transform.localScale = new Vector3(1, 1, 1); 
        AddLayerToChildren(currentArmorHelmet.transform, LayerMask.NameToLayer("PlayerRender"));
    }

    private void AddLayerToChildren(Transform root, int layer)
    {
        root.gameObject.layer = layer;
        foreach(Transform child in root)
        {
            AddLayerToChildren(child, layer);
        }
    }

    private void SetAnimation()
    {
        animator.ResetTrigger("ONEHAND");
        animator.ResetTrigger("TWOHAND");

        if(weaponTypeHanded == WeaponTypeHandedEnum.ONEHAND || weaponTypeHanded == WeaponTypeHandedEnum.BOTH)
        {
            animator.SetTrigger("ONEHAND");
        }
        else if(weaponTypeHanded == WeaponTypeHandedEnum.TWOHAND)
        {
            animator.SetTrigger("TWOHAND");
        }
    }

    private void RemovePreviousHelmet()
    {
        if (headSpecialHelmet.GetComponentInChildren<Armor>() != null)
        {
            Destroy(headSpecialHelmet.GetComponentInChildren<Armor>().gameObject);
        }

        if (headBasicHelmet.GetComponentInChildren<Armor>() != null)
        {
            Destroy(headBasicHelmet.GetComponentInChildren<Armor>().gameObject);
        }
    }

    private void RemovePreviousTorsoArmor()
    {
        if (torso.GetComponentInChildren<Armor>() != null)
        {
            Destroy(torso.GetComponentInChildren<Armor>().gameObject);
        }
    }

    private void RemovePreviousWeapon()
    {
        if (handL.GetComponentInChildren<Weapon>() != null)
        {
            Destroy(handL.GetComponentInChildren<Weapon>().gameObject);
        }
        if (handR.GetComponentInChildren<Weapon>() != null)
        {
            Destroy(handR.GetComponentInChildren<Weapon>().gameObject);
        }
    }

    private void SetWeaponRotation()
    {
        SetRightHandWeaponTransform();


                //currentWeapon.transform.localRotation = Quaternion.Euler(-90, 180, -180);

    }

    private void SetLeftDaggerTransform()
    {
        currentSecondWeapon.transform.parent = handL.transform;
        currentSecondWeapon.transform.position = handL.position;
        currentSecondWeapon.transform.localScale = new Vector3(1, 1, 1);
        currentSecondWeapon.transform.localRotation = Quaternion.Euler(-90, 180, -180);
    }

    private void SetRightHandWeaponTransform()
    {
        currentWeapon.transform.parent = handR.transform;
        currentWeapon.transform.position = handR.position;
        currentWeapon.transform.localScale = new Vector3(1, 1, 1);
    }

    private void SetLanceTransform()
    {
        SetRightHandWeaponTransform();
        currentWeapon.transform.localRotation = Quaternion.Euler(-90, 90, 0);
        currentWeapon.transform.localPosition += new Vector3(0, -0.5f, 0);
    }

    private void SetRightDaggerTransform()
    {
        SetRightHandWeaponTransform();
        currentWeapon.transform.localRotation = Quaternion.Euler(-77, 180, -180);
    }

    private void SetShortswordTransform()
    {
        SetRightHandWeaponTransform();
        currentWeapon.transform.localRotation = Quaternion.Euler(-90, 90, 90);
    }

    private void SetHammerTransform()
    {
        SetRightHandWeaponTransform();
        currentWeapon.transform.localRotation = Quaternion.Euler(-63, -138, -131);
        currentWeapon.transform.localPosition += new Vector3(0.05f, -0.313f, 0.153f);
    }

    private void SetLongswordTransform()
    {
        SetRightHandWeaponTransform();
        currentWeapon.transform.localRotation = Quaternion.Euler(-113, 20, 67);
        currentWeapon.transform.localPosition = new Vector3(0, 0, 0);
    }
}

// Decompiled with JetBrains decompiler
// Type: OutpostOutsideRadar
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class OutpostOutsideRadar : ObjectActionController
{
  public Sprite painting;
  private bool wstan;
  public Sprite open;
  public Sprite closed;
  public GameObject walkHere;
  public GameObject walkHere2;
  public PolygonCollider2D blok;
  public SpriteRenderer blysk;
  [SerializeField]
  private float alpha;
  [SerializeField]
  private float alphaDir;

  private void Update()
  {
    this.alpha += Random.Range(-1f, 1f) * Time.deltaTime;
    if ((double) this.alpha > 1.0)
      this.alpha = 1f;
    if ((double) this.alpha < 0.5)
      this.alpha = 0.5f;
    this.blysk.color = new Color(1f, 1f, 1f, this.alpha);
    if (!this.wstan || (double) PlayerController.wc.currentXY.x < 165.0)
      return;
    this.wstan = false;
    PlayerController.wc.forceDirection(WalkController.Direction.W);
    PlayerController.wc.forceAnimation("stand_e", true, makeBusy: false);
    PlayerController.wc.forceDirection(WalkController.Direction.W);
    PlayerController.pc.setBusy(false);
    this.updateAll();
    PlayerController.wc.setSimpleTargetV3(this.walkHere2.transform.position);
  }

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_radar_panel";
    this.range = 1f;
    this.wstan = false;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("screwdriver", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("duplexer", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "crowbar_too_brute"), anim: string.Empty));
    this.updateAll();
  }

  public override void clickAction()
  {
    if (this.usedItem == "screwdriver")
    {
      if (!GameDataController.gd.getObjective("outpost_radar_open"))
      {
        ItemsManager.im.getItem("metal_slab").dataRef.droppedLocation = "LocationOutpostOutside2";
        ItemsManager.im.getItem("metal_slab").dataRef.locX = 160;
        ItemsManager.im.getItem("metal_slab").dataRef.locY = 95;
        Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) ItemsManager.im.getItem("metal_slab").dataRef.locX, (float) (ItemsManager.im.getItem("metal_slab").dataRef.locY + GroundItemController.yOffset)));
        Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint((Vector3) screen);
        (Object.Instantiate(Resources.Load("Prefabs/GroundItem"), worldPoint, new Quaternion()) as GameObject).GetComponent<GroundItemController>().init(ItemsManager.im.getItem("metal_slab"));
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.screw);
        GameDataController.gd.setObjective("outpost_radar_open", true);
        this.updateState();
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_opened"));
    }
    else if (this.usedItem == "duplexer")
    {
      if (!GameDataController.gd.getObjective("outpost_radar_open"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "radar_locked"));
      }
      else
      {
        this.wstan = true;
        InventoryController.ic.removeItem("duplexer");
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.screw);
        GameDataController.gd.setObjective("outpost_radar_repaired", true);
        PlayerController.wc.forceAnimation("kneel_e_out", true);
      }
    }
    else if (!GameDataController.gd.getObjective("outpost_radar_open"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "radar_locked"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "radar_broken"));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    this.blok.enabled = false;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("screwdriver", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("duplexer", string.Empty, anim: string.Empty));
    if (!GameDataController.gd.getObjective("outpost_radar_open"))
    {
      this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "crowbar_too_brute"), anim: string.Empty));
      this.GetComponent<SpriteRenderer>().sprite = this.closed;
      this.blysk.enabled = true;
    }
    else
    {
      this.blysk.enabled = false;
      this.GetComponent<SpriteRenderer>().sprite = this.open;
    }
    if (GameDataController.gd.getObjective("outpost_radar_repaired"))
    {
      this.blok.enabled = true;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.blok.enabled = false;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2()
  {
    if (!this.wstan)
      return;
    PlayerController.wc.forceAnimation("walk_e");
    PlayerController.wc.setSimpleTargetV3(this.walkHere.transform.position);
    PlayerController.pc.setBusy(true);
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}

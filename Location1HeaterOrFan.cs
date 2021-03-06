// Decompiled with JetBrains decompiler
// Type: Location1HeaterOrFan
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Location1HeaterOrFan : ObjectActionController
{
  public SpriteRenderer fanstill;
  public SpriteRenderer fango;
  public SpriteRenderer heater;
  public SpriteRenderer heaterGlow;
  public float lightAlfa;
  public float lightAlfa2;
  public AudioClip fanSound;
  public AudioClip heaterSound;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "fan";
    this.range = 1f;
    this.fanSound = SoundsManagerController.sm.fan;
    this.heaterSound = SoundsManagerController.sm.heater2;
    this.updateState();
  }

  private void Update()
  {
    if (GameDataController.gd.getObjective("base_heater_cord_plugged"))
    {
      if (GameDataController.gd.getObjective("base_heater_cord_plugged") && (double) this.lightAlfa < 1.0 && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
        this.lightAlfa += Time.deltaTime * 0.1f;
      if ((double) this.lightAlfa > 0.0 && (!GameDataController.gd.getObjective("barn_pump_started") || GameDataController.gd.getObjectiveDetail("barn_pump_started") != 1) || !GameDataController.gd.getObjective("base_heater_cord_plugged"))
        this.lightAlfa -= Time.deltaTime * 0.1f;
      if ((double) this.lightAlfa < 0.0)
        this.lightAlfa = 0.0f;
      if ((double) this.lightAlfa > 1.0)
        this.lightAlfa = 1f;
      this.lightAlfa2 += Random.Range(-0.1f, 0.1f);
      if ((double) this.lightAlfa2 < 0.0)
        this.lightAlfa2 = 0.0f;
      if ((double) this.lightAlfa2 > 1.0)
        this.lightAlfa2 = 1f;
      this.heaterGlow.color = new Color(1f, 1f, 1f, (float) ((double) this.lightAlfa * 0.75 + (double) this.lightAlfa * (double) this.lightAlfa2 * 0.25));
      this.heater.color = new Color(1f, 1f, 1f, 1f);
    }
    else if (!GameDataController.gd.getObjective("base_fan_cord_plugged"))
      ;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("base_fan_cord_plugged"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("fan")))
        return;
      GameDataController.gd.setObjective("base_fan_cord_plugged", false);
      this.updateAll();
    }
    else
    {
      if (!GameDataController.gd.getObjective("base_heater_cord_plugged") || !InventoryController.ic.pickUpItem(ItemsManager.im.getItem("heater")))
        return;
      GameDataController.gd.setObjective("base_heater_cord_plugged", false);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("base_fan_cord_plugged"))
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.heaterGlow.enabled = false;
      this.heater.enabled = false;
      if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      {
        this.fanstill.enabled = false;
        this.fango.enabled = true;
        this.GetComponent<AudioSource>().clip = this.fanSound;
        this.GetComponent<AudioSource>().loop = true;
        this.GetComponent<AudioSource>().Play();
        this.objectName = "base_fan_on";
      }
      else
      {
        this.fanstill.enabled = true;
        this.fango.enabled = false;
        this.GetComponent<AudioSource>().Stop();
        this.objectName = "base_fan_off";
      }
    }
    else if (GameDataController.gd.getObjective("base_heater_cord_plugged"))
    {
      this.colliderManager.setCollider(1);
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.heater.enabled = true;
      this.fanstill.enabled = false;
      this.fango.enabled = false;
      if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      {
        this.GetComponent<AudioSource>().clip = this.heaterSound;
        this.GetComponent<AudioSource>().loop = true;
        this.GetComponent<AudioSource>().Play();
        this.heaterGlow.enabled = true;
        this.objectName = "base_heater_on";
      }
      else
      {
        this.GetComponent<AudioSource>().Stop();
        this.heaterGlow.enabled = false;
        this.objectName = "base_heater_off";
      }
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.heaterGlow.enabled = false;
      this.heater.enabled = false;
      this.GetComponent<AudioSource>().Stop();
      this.fanstill.enabled = false;
      this.fango.enabled = false;
    }
  }

  public override void clickAction2()
  {
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

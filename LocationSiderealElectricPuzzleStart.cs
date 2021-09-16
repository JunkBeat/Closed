// Decompiled with JetBrains decompiler
// Type: LocationSiderealElectricPuzzleStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationSiderealElectricPuzzleStart : MonoBehaviour
{
  private bool failsafe;
  public SpriteRenderer s1;
  public SpriteRenderer s2;
  private bool easycome = true;
  public ElectricPuzzleReset butbut;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("none");
    PlayerController.pc.copySettingsToNPCs();
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    GameObject.Find("Location").GetComponent<LocationManager>().esc = (ObjectActionController) GameObject.Find("ElectricExit").GetComponent<LocationElectricExit>();
    this.failsafe = false;
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") == 50 && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") == 10)
    {
      this.s1.enabled = false;
      this.s2.enabled = false;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.65f);
    }
    else
    {
      this.s1.enabled = true;
      this.s2.enabled = true;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
    }
    GameObject.Find("ButtonReset").GetComponent<Button>().initButton(GameStrings.getString(GameStrings.world_labels, "generic_reset"));
    GameObject.Find("ButtonReset").GetComponent<Button>().onClick = new Button.Delegate(this.onclick);
    this.updateManual();
    GameObject.Find("Pin_A1").GetComponent<Electric_Pin>().startWithCheck();
    GameObject.Find("Pin_B2").GetComponent<Electric_Pin>().startWithCheck();
    this.butbut.showOrNot();
  }

  public void onclick()
  {
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_a1", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_a2", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_b1", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_b2", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_b3", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_c1", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_c2", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_d1", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_d2", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_d3", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_d4", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_e1", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_e2", 0);
    GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_e3", 0);
    GameObject.Find("Pin_A1").GetComponent<Electric_Pin>().startWithCheck();
    GameObject.Find("Pin_B2").GetComponent<Electric_Pin>().startWithCheck();
  }

  private void updateManual()
  {
    if (CursorController.cc.selectedItemRef == null)
    {
      this.easycome = true;
      for (int index = 0; index <= 13; ++index)
      {
        string str = string.Empty;
        if (index == 0)
          str = "sidereal_electric_pin_a1";
        if (index == 1)
          str = "sidereal_electric_pin_a2";
        if (index == 2)
          str = "sidereal_electric_pin_b1";
        if (index == 3)
          str = "sidereal_electric_pin_b2";
        if (index == 4)
          str = "sidereal_electric_pin_b3";
        if (index == 5)
          str = "sidereal_electric_pin_c1";
        if (index == 6)
          str = "sidereal_electric_pin_c2";
        if (index == 7)
          str = "sidereal_electric_pin_d1";
        if (index == 8)
          str = "sidereal_electric_pin_d2";
        if (index == 9)
          str = "sidereal_electric_pin_d3";
        if (index == 10)
          str = "sidereal_electric_pin_d4";
        if (index == 11)
          str = "sidereal_electric_pin_e1";
        if (index == 12)
          str = "sidereal_electric_pin_e2";
        if (index == 13)
          str = "sidereal_electric_pin_e3";
        string id = str;
        if (GameDataController.gd.getObjective(id))
        {
          if (GameDataController.gd.getObjectiveDetail(id) == -1)
            GameDataController.gd.setObjectiveDetail(id, 0);
          if (GameDataController.gd.getObjectiveDetail(id) == 0)
            this.easycome = false;
        }
      }
      if ((Object) GameObject.Find("Pin_A1") != (Object) null)
        GameObject.Find("Pin_A1").GetComponent<Electric_Pin>().updateAll();
    }
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") == 50 && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") == 10)
    {
      if (this.s1.enabled)
      {
        this.s1.enabled = false;
        this.s2.enabled = false;
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.neon_on);
        JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.buzz, 0.65f);
      }
    }
    else if (!this.s1.enabled)
    {
      this.s1.enabled = true;
      this.s2.enabled = true;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.underground_1, 1f);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.neon_off);
    }
    this.Invoke(nameof (updateManual), 0.1f);
  }

  private void Update()
  {
  }
}

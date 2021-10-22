// Decompiled with JetBrains decompiler
// Type: LocationSiderealPCStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationSiderealPCStart : MonoBehaviour
{
  private bool failsafe;

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
    GameObject.Find("Location").GetComponent<LocationManager>().esc = (ObjectActionController) GameObject.Find("SiderealPCExit").GetComponent<SiderealPCExit>();
    this.failsafe = false;
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_mystery);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.pc_noise, 1f);
    GameObject.Find("PC_mail").GetComponent<SiderealPCMail>().updateState();
  }

  public void resetMail() => GameObject.Find("PC_mail").GetComponent<SiderealPCMail>().updateAll();

  private void Update()
  {
  }
}

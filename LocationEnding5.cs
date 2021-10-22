// Decompiled with JetBrains decompiler
// Type: LocationEnding5
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationEnding5 : MonoBehaviour
{
  private void Start()
  {
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal, 0.9f);
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0015f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 8f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 200f;
    PlayerController.ssg.setStepType("dirt");
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.speed = 0.0f;
    PlayerController.wc.dir = WalkController.Direction.SE;
    PlayerController.wc.currentXY = new Vector2(-51f, -28f);
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    PlayerController.wc.busy = true;
    this.Invoke("nextScene", 5f);
  }

  private void nextScene()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("Ending1", WalkController.Direction.S, tSpeed: 1f);
  }

  private void Update()
  {
  }
}

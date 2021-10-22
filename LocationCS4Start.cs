// Decompiled with JetBrains decompiler
// Type: LocationCS4Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationCS4Start : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.01f;
    PlayerController.wc.shadow.fadeRateH = 1f / 1000f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 10f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 240f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.DIRT, AudioReverbPreset.Off);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_metal, 1f);
    GameDataController.gd.setObjective("visited_cs_4", true);
    if (!GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("LocationOtherHitTest").GetComponent<PolygonCollider2D>().enabled = false;
    }
    else
    {
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("LocationOtherHitTest").GetComponent<PolygonCollider2D>().enabled = true;
    }
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  private void Update()
  {
  }
}

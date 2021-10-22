// Decompiled with JetBrains decompiler
// Type: LocationRestaurant5Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationRestaurant5Start : MonoBehaviour
{
  public PolygonCollider2D block;
  public PolygonCollider2D block2;
  private bool shadowbegone;
  public SpriteRenderer shadow;
  public float al;

  private void Start()
  {
    this.shadowbegone = false;
    PlayerController.wc.shadow.fadeRateV = 1f / 500f;
    PlayerController.wc.shadow.fadeRateH = 1f / 500f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 25f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 140f;
    PlayerController.ssg.setStepType2("normal", AudioReverbPreset.Stoneroom);
    GameDataController.gd.setObjective("visited_restaurant_wc", true);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_3a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_flag, 0.25f);
    if (GameDataController.gd.getCurrentDay() > 2)
    {
      this.block.enabled = false;
      if (GameDataController.gd.getObjective("restaurant_chem_door_open"))
        this.block2.enabled = false;
    }
    else
    {
      this.block.enabled = true;
      this.block2.enabled = true;
    }
    this.al = !GameDataController.gd.getObjective("restaurant_chem_walked") ? 1f : 0.0f;
    this.shadow.color = new Color(1f, 1f, 1f, this.al);
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.y < 40.0 && !GameDataController.gd.getObjective("restaurant_chem_walked"))
    {
      this.shadowbegone = true;
      GameDataController.gd.setObjective("restaurant_chem_walked", true);
      GameObject.Find("Conspiracy").GetComponent<RestaurantConspiracy>().updateState();
    }
    if (!this.shadowbegone)
      return;
    this.al -= Time.deltaTime;
    if ((double) this.al < 0.0)
    {
      this.al = 0.0f;
      this.shadowbegone = false;
    }
    this.shadow.color = new Color(1f, 1f, 1f, this.al);
  }
}

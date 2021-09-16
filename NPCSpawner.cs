// Decompiled with JetBrains decompiler
// Type: NPCSpawner
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
  public bool ifEntriesMatch;
  public float rand_del_min = 0.5f;
  public float rand_del_max = 3f;
  public bool flipX;
  public string npcName = string.Empty;
  private NPCWalkController npc;
  private BoxCollider2D collider;
  private float targetAlpha = 1f;
  private float alpha = 1f;
  private SpriteRenderer spriteRenderer;
  public List<string> conditions;
  public List<bool> conditionsValues;
  private List<string> basicConditions;
  private string mainCondition;
  private bool spawn = true;
  public string startAnimation = string.Empty;
  private LocationManager currentLocationManager;

  private void Start()
  {
    this.npc = GameObject.Find(this.npcName).GetComponent<NPCWalkController>();
    this.collider = this.npc.gameObject.GetComponent<BoxCollider2D>();
    this.spriteRenderer = this.npc.gameObject.GetComponent<SpriteRenderer>();
    this.hide();
    this.basicConditions = new List<string>();
    if (this.npcName == "Ginger")
    {
      this.basicConditions.Add("npc1_alive");
      this.mainCondition = "npc1_alive";
      this.basicConditions.Add("dialogue_ginger_intro");
      this.mainCondition = string.Empty;
    }
    if (this.npcName == "Npc2")
    {
      this.basicConditions.Add("npc2_joined");
      this.basicConditions.Add("npc2_alive");
      this.mainCondition = "npc2_alive";
    }
    if (this.npcName == "Npc3")
    {
      this.basicConditions.Add("npc3_joined");
      this.basicConditions.Add("npc3_alive");
      this.mainCondition = "npc3_alive";
    }
    if (this.npc.spawned)
      return;
    this.spawnOrNot();
  }

  public void spawnOrNot(bool resumingGame = false)
  {
    this.spawn = true;
    string str = PlayerController.pc.spawnName;
    if (PlayerController.pc.spawnName.Equals("previous") || PlayerController.pc.spawnName.Equals(string.Empty) || PlayerController.pc.spawnName.Equals("none"))
    {
      resumingGame = true;
      str = GameDataController.gd.usedSpawner;
    }
    if (this.ifEntriesMatch)
    {
      for (int index = 0; index < this.basicConditions.Count; ++index)
      {
        if (!GameDataController.gd.getObjective(this.basicConditions[index]))
          this.spawn = false;
      }
    }
    for (int index = 0; index < this.conditions.Count; ++index)
    {
      if (GameDataController.gd.getObjective(this.conditions[index]) == !this.conditionsValues[index])
        this.spawn = false;
    }
    if (this.mainCondition != string.Empty && !GameDataController.gd.getObjective(this.mainCondition))
      this.spawn = false;
    if (this.ifEntriesMatch && !str.Equals(this.gameObject.transform.parent.name))
      this.spawn = false;
    if (!this.spawn)
      return;
    this.npc.gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    MonoBehaviour.print((object) ("ROUND TO NEAREST FULL PIXEL " + (object) ScreenControler.screenToGame((Vector2) Camera.main.WorldToScreenPoint(this.gameObject.transform.position))));
    this.npc.currentXY = (Vector2) ScreenControler.roundToNearestFullPixel(this.gameObject.transform.position);
    this.npc.clearTarget();
    if (PlayerController.pc.spawnName == "car")
    {
      this.rand_del_max /= 2f;
      this.rand_del_min /= 4f;
    }
    if (!PlayerController.pc.npcShouldAppearRightOnSpot)
      this.Invoke("arrive", Random.Range(this.rand_del_min, this.rand_del_max));
    else
      this.Invoke("arrive", Random.Range(0.0f, 0.01f));
    this.flipage();
    if (this.startAnimation != string.Empty)
      this.npc.forceAnimation(this.startAnimation);
    this.npc.gameObject.GetComponent<SpriteRenderer>().flipX = this.flipX;
    this.npc.gameObject.GetComponent<NPCActionController>().updateState();
    MonoBehaviour.print((object) ("SPAWNING NPC " + this.npcName + " at " + (object) this.npc.currentXY + " (" + (object) this.gameObject.transform.position + ") resumingGame? " + (object) resumingGame + " "));
    MonoBehaviour.print((object) ("SPAWNING NPC at " + this.gameObject.transform.parent.name + "  because " + PlayerController.pc.spawnName));
    MonoBehaviour.print((object) ("SPAWNING NPC with starting animation " + this.startAnimation + " AND FLIP X " + (object) this.flipX));
  }

  private void flipage()
  {
    if (!this.flipX)
      this.npc.gameObject.GetComponent<NPCWalkController>().forceDirection(NPCWalkController.Direction.SE);
    else
      this.npc.gameObject.GetComponent<NPCWalkController>().forceDirection(NPCWalkController.Direction.SW);
  }

  public void hide(bool fast = true)
  {
    this.collider.enabled = false;
    this.targetAlpha = 0.0f;
    if (!fast)
      return;
    this.spriteRenderer.enabled = false;
    this.npc.colorAlpha = 0.0f;
    this.npc.shadow.alphaMod = 0.0f;
    this.alpha = 0.0f;
    this.spriteRenderer.color = new Color(this.npc.colorRed, this.npc.colorGreen, this.npc.colorBlue, 0.0f);
  }

  public void show(bool fast = true)
  {
    MonoBehaviour.print((object) ("SHOW " + this.npcName + " fast? " + (object) fast + " at " + this.gameObject.transform.parent.gameObject.name));
    this.collider.enabled = true;
    this.npc.spawned = true;
    this.targetAlpha = 1f;
    this.spriteRenderer.enabled = true;
    if (!fast)
      return;
    this.alpha = 1f;
    this.npc.colorAlpha = 1f;
    this.npc.shadow.alphaMod = 1f;
    this.spriteRenderer.color = new Color(this.npc.colorRed, this.npc.colorGreen, this.npc.colorBlue, 1f);
  }

  private void arrive()
  {
    this.show(PlayerController.pc.npcShouldAppearRightOnSpot);
    if (PlayerController.pc.spawnName == "car")
    {
      int num = Random.Range(0, 3);
      if (num == 0)
        this.npc.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.car_close);
      if (num == 1)
        this.npc.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.car_close2);
      if (num == 2)
        this.npc.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.car_close3);
    }
    if ((Object) this.currentLocationManager == (Object) null)
      this.currentLocationManager = GameObject.Find("Location").GetComponent<LocationManager>();
    if (PlayerController.pc.npcShouldAppearRightOnSpot)
    {
      MonoBehaviour.print((object) ("ROUND TO NEAREST FULL PIXEL B " + (object) ScreenControler.screenToGame((Vector2) Camera.main.WorldToScreenPoint(this.gameObject.transform.Find("NPCTarget").transform.position))));
      this.npc.currentXY = (Vector2) ScreenControler.roundToNearestFullPixel(this.gameObject.transform.Find("NPCTarget").transform.position);
      this.npc.clearTarget();
      this.flipX = (double) this.gameObject.transform.Find("NPCTarget").transform.position.x < (double) this.gameObject.transform.position.x;
      this.flipage();
    }
    else
    {
      List<Vector2> newTarget = this.currentLocationManager.Search2(this.currentLocationManager.findNearestClearNode(this.currentLocationManager.getNodeLocation(this.npc.currentXY)), this.currentLocationManager.findNearestClearNode(this.currentLocationManager.getNodeLocation((Vector2) ScreenControler.roundToNearestFullPixel(this.gameObject.transform.Find("NPCTarget").transform.position))));
      newTarget.Insert(0, this.npc.currentXY);
      this.npc.setTarget(newTarget);
    }
    this.npc.gameObject.GetComponent<NPCActionController>().updateState();
  }

  private void Update()
  {
    if (!this.spawn)
      return;
    float num = 2.5f * Time.deltaTime;
    if ((double) Mathf.Abs(this.targetAlpha - this.alpha) < (double) num)
    {
      this.alpha = this.targetAlpha;
      this.npc.colorAlpha = this.alpha;
      this.spriteRenderer.color = new Color(this.npc.colorRed, this.npc.colorGreen, this.npc.colorBlue, this.alpha);
      this.npc.shadow.alphaMod = this.alpha;
    }
    else
    {
      if ((double) this.targetAlpha == (double) this.alpha)
        return;
      if ((double) this.targetAlpha > (double) this.alpha)
        this.alpha += num;
      else if ((double) this.targetAlpha < (double) this.alpha)
        this.alpha -= num;
      this.npc.colorAlpha = this.alpha;
      this.npc.shadow.alphaMod = this.alpha;
      this.spriteRenderer.color = new Color(this.npc.colorRed, this.npc.colorGreen, this.npc.colorBlue, this.alpha);
    }
  }
}

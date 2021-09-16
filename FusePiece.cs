// Decompiled with JetBrains decompiler
// Type: FusePiece
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class FusePiece : ObjectActionController
{
  public static bool broken;
  public bool N;
  public bool E;
  public bool S;
  public bool W;
  public bool n_now;
  public bool e_now;
  public bool w_now;
  public bool s_now;
  public string coords_X;
  public string coords_Y;
  public Vector2[] breakers;
  public ParticleGenerator[] breakersParts;
  public Sprite[] sprites;
  private SpriteRenderer sr;
  public bool energized;
  public bool energized_before;
  public bool checkedNow;
  public FusePiece first;
  public FusePiece doorish;
  public FusePiece last;
  public FusePiece neighbour_n;
  public FusePiece neighbour_e;
  public FusePiece neighbour_s;
  public FusePiece neighbour_w;
  public List<FusePiece> allPieces;
  public ParticleGenerator pg;
  public static int updateIndex;
  public float delay;

  private void Start()
  {
    this.dkvs = GameStrings.objects;
    this.objectName = "fuse_piece";
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.pg = this.gameObject.GetComponent<ParticleGenerator>();
    this.sprites = Resources.LoadAll<Sprite>("Bitmaps/Locations/Outpost/fusebox/buttons");
    this.energized = false;
    this.checkedNow = false;
    this.updateNESW();
    this.updateView();
    this.updateEnergy();
  }

  private void Update()
  {
  }

  public void updateNESW()
  {
    this.n_now = this.N;
    this.e_now = this.E;
    this.w_now = this.W;
    this.s_now = this.S;
    for (int index = 0; index < GameDataController.gd.getObjectiveDetail("outpost_fuse_" + this.coords_X + this.coords_Y); ++index)
    {
      bool nNow = this.n_now;
      this.n_now = this.w_now;
      this.w_now = this.s_now;
      this.s_now = this.e_now;
      this.e_now = nNow;
    }
  }

  public void updateView(bool slow = false)
  {
    if (!slow)
    {
      this.updateView();
    }
    else
    {
      for (int index = 0; index < this.allPieces.Count; ++index)
      {
        if ((Object) this.allPieces[index] == (Object) this)
        {
          this.Invoke(nameof (updateView), 0.075f * (float) index);
          this.Invoke("pykSound", 0.075f * (float) index);
        }
      }
    }
  }

  public void pykSound() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hose);

  public void updateView()
  {
    string empty = string.Empty;
    if (this.n_now)
      empty += "N";
    if (this.e_now)
      empty += "E";
    if (this.s_now)
      empty += "S";
    if (this.w_now)
      empty += "W";
    if (this.energized)
      empty += "_L";
    for (int index = 0; index < this.sprites.Length; ++index)
    {
      if (this.sprites[index].name == "fuse_" + empty)
      {
        this.sr.sprite = this.sprites[index];
        break;
      }
    }
  }

  public void updateEnergy(bool slow = false)
  {
    for (int index = 0; index < this.allPieces.Count; ++index)
    {
      this.allPieces[index].energized = false;
      this.allPieces[index].checkedNow = false;
      this.allPieces[index].updateView(slow);
    }
    if (this.first.w_now)
      this.first.energizeThis();
    if (!FusePiece.broken && this.doorish.energized)
    {
      GameDataController.gd.setObjective("outpost_door_powered", true);
      this.updateAll();
    }
    else if (!this.doorish.energized)
    {
      GameDataController.gd.setObjective("outpost_door_powered", false);
      this.updateAll();
    }
    if (!FusePiece.broken && this.last.energized && (GameDataController.gd.getObjectiveDetail("outpost_fuse_55") == 2 || GameDataController.gd.getObjectiveDetail("outpost_fuse_55") == 3))
    {
      GameDataController.gd.setObjective("outpost_elevator_powered", true);
      this.updateAll();
    }
    else
    {
      if (this.last.energized)
        return;
      GameDataController.gd.setObjective("outpost_elevator_powered", false);
      this.updateAll();
    }
  }

  public void energizeThis()
  {
    this.energized = true;
    this.updateView();
    if (this.checkedNow || FusePiece.broken)
      return;
    this.checkedNow = true;
    if (this.breakers.Length > 0)
    {
      for (int whichone = 0; whichone < this.breakers.Length; ++whichone)
      {
        if (this.n_now && (double) int.Parse(this.coords_X) == (double) this.breakers[whichone].x && (double) (int.Parse(this.coords_Y) - 1) == (double) this.breakers[whichone].y)
          this.breakBoom(whichone);
        else if (this.e_now && (double) (int.Parse(this.coords_X) + 1) == (double) this.breakers[whichone].x && (double) int.Parse(this.coords_Y) == (double) this.breakers[whichone].y)
          this.breakBoom(whichone);
        else if (this.s_now && (double) int.Parse(this.coords_X) == (double) this.breakers[whichone].x && (double) (int.Parse(this.coords_Y) + 1) == (double) this.breakers[whichone].y)
          this.breakBoom(whichone);
        else if (this.w_now && (double) (int.Parse(this.coords_X) - 1) == (double) this.breakers[whichone].x && (double) int.Parse(this.coords_Y) == (double) this.breakers[whichone].y)
          this.breakBoom(whichone);
      }
    }
    if (this.n_now && (bool) (Object) this.neighbour_n && this.neighbour_n.s_now)
      this.neighbour_n.energizeThis();
    if (this.e_now && (bool) (Object) this.neighbour_e && this.neighbour_e.w_now)
      this.neighbour_e.energizeThis();
    if (this.s_now && (bool) (Object) this.neighbour_s && this.neighbour_s.n_now)
      this.neighbour_s.energizeThis();
    if (this.w_now && (bool) (Object) this.neighbour_w && this.neighbour_w.e_now)
      this.neighbour_w.energizeThis();
    if (!FusePiece.broken)
      ;
  }

  public void door()
  {
  }

  public void win()
  {
  }

  public void breakBoom(int whichone)
  {
    PlayerController.pc.setBusy(true);
    this.breakersParts[whichone].started = true;
    this.Invoke("stopZapBreak", 1.2f);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.electric);
    this.Invoke("stopBreak", 1.5f);
    Debug.LogWarning((object) "BOOM");
    FusePiece.broken = true;
    int num = 0;
    for (int index = 0; index < this.allPieces.Count; ++index)
    {
      if (this.allPieces[index].energized)
        ++num;
    }
    for (int index = 0; index < this.allPieces.Count; ++index)
    {
      Debug.LogWarning((object) ("BOOM " + (object) index));
      if (this.allPieces[index].coords_Y == "1")
      {
        if (this.allPieces[index].coords_X == "1")
          GameDataController.gd.setObjectiveDetail("outpost_fuse_" + this.allPieces[index].coords_X + this.allPieces[index].coords_Y, 1);
        else
          GameDataController.gd.setObjectiveDetail("outpost_fuse_" + this.allPieces[index].coords_X + this.allPieces[index].coords_Y, Random.Range(0, 4));
      }
      else
        GameDataController.gd.setObjectiveDetail("outpost_fuse_" + this.allPieces[index].coords_X + this.allPieces[index].coords_Y, Random.Range(0, 4));
      if (this.allPieces[index].energized)
        this.allPieces[index].zap((float) (num - index) * 0.1f);
    }
  }

  private void stopZapBreak()
  {
    for (int index1 = 0; index1 < this.breakersParts.Length; ++index1)
    {
      this.breakersParts[index1].started = false;
      int num;
      for (int index2 = 0; index2 < this.breakersParts[index1].particles.Count; index2 = num + 1)
      {
        if ((Object) this.breakersParts[index1].particles[index2] == (Object) null)
        {
          this.breakersParts[index1].particles.RemoveAt(index2);
          num = index2 - 1;
        }
        else
        {
          GameObject gameObject = this.breakersParts[index1].particles[index2].gameObject;
          this.breakersParts[index1].particles.RemoveAt(index2);
          Object.Destroy((Object) gameObject);
          num = index2 - 1;
        }
      }
    }
  }

  public void zap(float delay) => this.Invoke("zapzap", delay);

  private void zapzap()
  {
    this.pg.started = true;
    this.Invoke("endZap", 1f);
  }

  private void stopBreak()
  {
    FusePiece.broken = false;
    for (int index = 0; index < this.allPieces.Count; ++index)
    {
      this.allPieces[index].energized = false;
      this.allPieces[index].updateView();
    }
    for (int index = 0; index < this.allPieces.Count; ++index)
      this.allPieces[index].updateNESW();
    this.updateEnergy(true);
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "fuse_short_circuit" + (object) GameDataController.gd.getObjectiveDetail("outpost_fuse_short_circuit")));
    if (GameDataController.gd.getObjectiveDetail("outpost_fuse_short_circuit") < 3)
      GameDataController.gd.setObjectiveDetail("outpost_fuse_short_circuit", GameDataController.gd.getObjectiveDetail("outpost_fuse_short_circuit") + 1);
    else
      GameDataController.gd.setObjectiveDetail("outpost_fuse_short_circuit", 0);
  }

  private void endZap()
  {
    this.pg.started = false;
    int num;
    for (int index = 0; index < this.pg.particles.Count; index = num + 1)
    {
      if ((Object) this.pg.particles[index] == (Object) null)
      {
        this.pg.particles.RemoveAt(index);
        num = index - 1;
      }
      else
      {
        GameObject gameObject = this.pg.particles[index].gameObject;
        this.pg.particles.RemoveAt(index);
        Object.Destroy((Object) gameObject);
        num = index - 1;
      }
    }
  }

  public override void updateState()
  {
  }

  public override void clickAction0()
  {
  }

  public void rotate()
  {
    this.pykSound();
    int detail = GameDataController.gd.getObjectiveDetail("outpost_fuse_" + this.coords_X + this.coords_Y) + 1;
    if (detail >= 4)
      detail = 0;
    GameDataController.gd.setObjectiveDetail("outpost_fuse_" + this.coords_X + this.coords_Y, detail);
  }

  public override void clickAction()
  {
    this.rotate();
    this.updateNESW();
    this.updateEnergy();
  }

  public override void clickAction2()
  {
  }
}

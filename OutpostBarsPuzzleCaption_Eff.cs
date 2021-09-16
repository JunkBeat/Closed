// Decompiled with JetBrains decompiler
// Type: OutpostBarsPuzzleCaption_Eff
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class OutpostBarsPuzzleCaption_Eff : MonoBehaviour
{
  public string nameToDisplay;
  public TextFieldController t;
  public int score;

  private void Start() => this.t.keepAlive = true;

  public void aktualizuj()
  {
    this.score = 0;
    this.score += GameDataController.gd.getObjectiveDetail("outpost_score_a");
    this.score += GameDataController.gd.getObjectiveDetail("outpost_score_b");
    this.score += GameDataController.gd.getObjectiveDetail("outpost_score_c");
    this.score += GameDataController.gd.getObjectiveDetail("outpost_score_d");
    this.score += GameDataController.gd.getObjectiveDetail("outpost_score_e");
    if (this.score == 0)
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, "bars_puzzle_q0"), quick: true, instant: true, mwidth: 200, r: 0.4980392f, g: 0.0f, b: 0.0f, ba: 0.0f);
    else if (this.score < 2)
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, "bars_puzzle_q1"), quick: true, instant: true, mwidth: 200, r: 0.4862745f, g: 0.1215686f, b: 0.0f, ba: 0.0f);
    else if (this.score < 4)
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, "bars_puzzle_q2"), quick: true, instant: true, mwidth: 200, r: 0.4862745f, g: 0.2039216f, b: 0.0f, ba: 0.0f);
    else if (this.score < 6)
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, "bars_puzzle_q3"), quick: true, instant: true, mwidth: 200, r: 0.4862745f, g: 0.282353f, b: 0.0f, ba: 0.0f);
    else if (this.score < 8)
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, "bars_puzzle_q4"), quick: true, instant: true, mwidth: 200, r: 0.4980392f, g: 0.4156863f, b: 0.0f, ba: 0.0f);
    else if (this.score < 9)
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, "bars_puzzle_q5"), quick: true, instant: true, mwidth: 200, r: 0.4470588f, g: 0.4862745f, b: 0.0f, ba: 0.0f);
    else if (this.score < 10)
    {
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, "bars_puzzle_q6"), quick: true, instant: true, mwidth: 200, r: 0.282353f, g: 0.4862745f, b: 0.0f, ba: 0.0f);
    }
    else
    {
      if (this.score != 10)
        return;
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, "bars_puzzle_q7"), quick: true, instant: true, mwidth: 200, r: 0.0f, g: 0.4862745f, b: 0.0f, ba: 0.0f);
    }
  }

  private void Update()
  {
  }
}

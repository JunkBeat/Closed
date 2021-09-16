// Decompiled with JetBrains decompiler
// Type: OutpostBarsPuzzleCaption_Title
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class OutpostBarsPuzzleCaption_Title : MonoBehaviour
{
  public string nameToDisplay;
  private TextFieldController t;

  private void Start()
  {
    if (this.nameToDisplay == "bars_puzzle_caption_1a")
      this.nameToDisplay = GameDataController.gd.getObjectiveDetail("day_4_threat") != 0 ? "bars_puzzle_caption_1a" : "bars_puzzle_caption_1b";
    else if (this.nameToDisplay == "bars_puzzle_caption_2a")
      this.nameToDisplay = GameDataController.gd.getObjectiveDetail("day_4_threat") != 0 ? "bars_puzzle_caption_2a" : "bars_puzzle_caption_2b";
    int mwidth = 50;
    if (!(PlayerPrefs.GetString("lang") == GameStrings.Language.DE.ToString()))
      ;
    this.t = this.GetComponent<TextFieldController>();
    this.t.viewText(GameStrings.getString(GameStrings.world_labels, this.nameToDisplay), quick: true, instant: true, mwidth: mwidth, r: 0.1372549f, g: 0.3333333f, b: 0.4509804f, ba: 0.0f);
    this.t.keepAlive = true;
  }

  private void Update()
  {
  }
}

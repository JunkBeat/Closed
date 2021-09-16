// Decompiled with JetBrains decompiler
// Type: StepSoundGenerator
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StepSoundGenerator : MonoBehaviour
{
  private AudioSource aS;
  private bool secStep;
  public bool useDoubleStepSound = true;
  public float volumeMultip = 1f;
  public static string NORMAL = "normal";
  public static string DIRT = "dirt";
  public static string WOOD = "wood";
  public static string METAL = "metal";
  public static string ROAD = "road";
  public static string GRASS = "grass";
  public static string HAY = "hay";
  public static string RUBBER = "rubber";
  public static string DIRT_GLASS = "dirtglass";
  public static string FENCE = "fence";
  public static string MOON = "moon";
  public List<AudioClip> stepsNormal = new List<AudioClip>();
  public List<AudioClip> stepsDirt = new List<AudioClip>();
  public List<AudioClip> stepsRoad = new List<AudioClip>();
  public List<AudioClip> stepsWood = new List<AudioClip>();
  public List<AudioClip> stepsMetal = new List<AudioClip>();
  public List<AudioClip> stepsGrass = new List<AudioClip>();
  public List<AudioClip> stepsHay = new List<AudioClip>();
  public List<AudioClip> stepsRubber = new List<AudioClip>();
  public List<AudioClip> stepsDirtGlass = new List<AudioClip>();
  public List<AudioClip> stepsFence = new List<AudioClip>();
  public List<AudioClip> stepsMoon = new List<AudioClip>();
  public Sprite[] dustNormal;
  public Sprite[] dustDirt;
  public Sprite[] dustRoad;
  public Sprite[] dustWood;
  public Sprite[] dustMetal;
  public Sprite[] dustGrass;
  public Sprite[] dustHay;
  public Sprite[] dustRubber;
  public string selectedStepsType = "normal";
  private float volume = 0.15f;
  private List<AudioClip> currtenSteps;

  private void Start()
  {
    this.aS = this.gameObject.GetComponent<AudioSource>();
    this.volumeMultip = 1f;
  }

  private void Update()
  {
  }

  public void setDust(Sprite[] dust)
  {
    if (dust == null || !((UnityEngine.Object) this.gameObject.GetComponent<ParticleGenerator>() != (UnityEngine.Object) null))
      return;
    this.gameObject.GetComponent<ParticleGenerator>().sprites = dust;
  }

  public void setStepType2(string type, AudioReverbPreset reverb)
  {
    this.selectedStepsType = type;
    if (type.Equals("normal"))
    {
      this.currtenSteps = this.stepsNormal;
      this.volume = 0.2f;
      this.setDust(this.dustNormal);
    }
    if (type.Equals("dirt"))
    {
      this.currtenSteps = this.stepsDirt;
      this.volume = 0.8f;
      this.setDust(this.dustDirt);
    }
    if (type.Equals("none"))
    {
      this.currtenSteps = this.stepsNormal;
      this.volume = 0.0f;
      this.setDust(this.dustNormal);
    }
    if (type.Equals("road"))
    {
      this.currtenSteps = this.stepsRoad;
      this.volume = 0.8f;
      this.setDust(this.dustRoad);
    }
    if (type.Equals(StepSoundGenerator.WOOD))
    {
      this.currtenSteps = this.stepsWood;
      this.volume = 0.5f;
      this.setDust(this.dustWood);
    }
    if (type.Equals("metal"))
    {
      this.currtenSteps = this.stepsMetal;
      this.volume = 0.3f;
    }
    if (type.Equals(StepSoundGenerator.GRASS))
    {
      this.currtenSteps = this.stepsGrass;
      this.volume = 0.7f;
    }
    if (type.Equals(StepSoundGenerator.HAY))
    {
      this.currtenSteps = this.stepsHay;
      this.volume = 0.99f;
    }
    if (type.Equals(StepSoundGenerator.RUBBER))
    {
      this.currtenSteps = this.stepsRubber;
      this.volume = 0.99f;
    }
    if (type.Equals(StepSoundGenerator.DIRT_GLASS))
    {
      this.currtenSteps = this.stepsDirtGlass;
      this.volume = 0.99f;
    }
    if (type.Equals(StepSoundGenerator.FENCE))
    {
      this.currtenSteps = this.stepsFence;
      this.volume = 0.99f;
      this.setDust(this.dustDirt);
    }
    if (type.Equals(StepSoundGenerator.MOON))
    {
      this.currtenSteps = this.stepsMoon;
      this.volume = 0.99f;
      this.setDust(this.dustRoad);
    }
    this.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = reverb;
    SoundsManagerController.sm.GetComponent<AudioReverbFilter>().reverbPreset = reverb;
  }

  public void setStepType(string type) => this.setStepType2(type, AudioReverbPreset.Off);

  public void soundStep()
  {
    AudioClip currtenStep = this.currtenSteps[0];
    int num = UnityEngine.Random.Range(this.currtenSteps.Count / 2, this.currtenSteps.Count);
    this.currtenSteps.RemoveAt(0);
    this.currtenSteps.Insert(num - 1, currtenStep);
    if (this.secStep || !this.useDoubleStepSound)
    {
      this.aS.PlayOneShot(currtenStep, this.volume * this.volumeMultip);
    }
    else
    {
      SoundsManagerController.sm.auxASPlayer.panStereo = this.gameObject.GetComponent<AudioSource>().panStereo;
      SoundsManagerController.sm.auxASPlayer.PlayOneShot(currtenStep, this.volume * this.volumeMultip);
    }
    this.secStep = !this.secStep;
  }
}

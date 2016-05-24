namespace Game

open UnityEngine

type Rotator() = 
  inherit MonoBehaviour()

  member x.Update() =
    let rotation = Vector3(15.0f, 30.0f, 45.0f)
    x.transform.Rotate(rotation * Time.deltaTime)

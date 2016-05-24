namespace Game

open UnityEngine

type CameraController() = 
  inherit MonoBehaviour()
  
  [<SerializeField>]
  let mutable player = Unchecked.defaultof<GameObject>
  
  let mutable offset = None

  member x.Start() =
    offset <- Some(x.transform.position - player.transform.position)

  member x.LateUpdate() = 
    match offset with
    | Some(o) -> x.transform.position <- player.transform.position + o
    | None -> ()

namespace Game

open UnityEngine
open UnityEngine.UI

type PlayerController() = 
  inherit MonoBehaviour()
  
  [<SerializeField>]
  let mutable speed = 10.0f
  
  [<SerializeField>]
  let scoreText = Unchecked.defaultof<Text>
  
  [<SerializeField>]
  let winText = Unchecked.defaultof<Text>
  
  let mutable rb = Unchecked.defaultof<Rigidbody>
  let mutable score = 0
  
  let setScore(newScore) = 
    score <- newScore
    scoreText.text <- "Score: " + score.ToString()
    winText.text <- if score < 12 then "" else "You win!"
  
  member x.Start() = 
    rb <- x.GetComponent<Rigidbody>()
    setScore(0)
  
  member x.FixedUpdate() = 
    let moveHorizontal = Input.GetAxis("Horizontal")
    let moveVertical = Input.GetAxis("Vertical")
    let movement = Vector3(moveHorizontal, 0.0f, moveVertical)
    rb.AddForce(movement * speed)
  
  member x.OnTriggerEnter(other : Collider) = 
    if other.gameObject.CompareTag("Pickup") then
      other.gameObject.SetActive(false)
      setScore(score + 1)

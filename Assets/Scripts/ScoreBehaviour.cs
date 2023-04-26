using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    public PlayerCollisionBehaviour Player;

    [SerializeField]
    private Text _scoreText;

    private string _startText;

    // Start is called before the first frame update
    void Start()
    {
        _startText = _scoreText.text;
    }

    // Update is called once per frame
    void Update()
    {
        //Changes the score with each frame.
        _scoreText.text = _startText + "" + (int)Player.Score;
    }
}

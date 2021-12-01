using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    //Criacao da lista de segmentos
    private List<Transform> _segments = new List<Transform>();

    //uso do component transform
    public Transform segmentPrefab;

    //uso do component vaector2
    public Vector2 direction = Vector2.right;

    //variavel para determinar o tamanho inicial da cobra
    public int initialSize = 4;
        
    //metodo start padrao da unity
    private void Start()
    {
        //metodo para reiniciar o estado do jogo
        ResetState();
    }
    
    //metodo update da unity
    private void Update()
    {
        //condicional para input de controles
        if (this.direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                this.direction = Vector2.up;
            } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                this.direction = Vector2.down;
            }
        }
        //condicional para input de controles
        else if (this.direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                this.direction = Vector2.right;
            } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                this.direction = Vector2.left;
            }
        }
    }

    private void FixedUpdate()
    {
        // posicionamento dos segmentos
        for (int i = _segments.Count - 1; i > 0; i--) {
            _segments[i].position = _segments[i - 1].position;
        }

        // posicao dos segmentos
        float x = Mathf.Round(this.transform.position.x) + this.direction.x;
        float y = Mathf.Round(this.transform.position.y) + this.direction.y;

        this.transform.position = new Vector2(x, y);
    }
    
    //funcao para a cobra crescer depois de receber um ponto
    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }
    
    //metodo para reiniciar o estado do jogo
    public void ResetState()
    {
        //posicao selecionada para iniciar o jogo novamente
        this.direction = Vector2.right;
        this.transform.position = Vector3.zero;

        // destroi todos o segmentos 
        for (int i = 1; i < _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        }

        // linpa os segmentos da lista
        _segments.Clear();
        _segments.Add(this.transform);

        // add os segmentos desejados novamente
        for (int i = 0; i < this.initialSize - 1; i++) {
            Grow();
        }
    }

    //funcao para deteccao de colisoes
    private void OnTriggerEnter2D(Collider2D other)
    {
        //add ponto crece o player
        if (other.tag == "Food") {
            Grow();
        } 
        //se player bater em um obstaculo o jogo reinicia
        else if (other.tag == "Obstacle") {
            ResetState();
        }
    }

}

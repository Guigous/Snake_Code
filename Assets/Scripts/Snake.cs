using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ESTE EXERCÍCIO FAZ PARTE DAS ATIVIDADES DA AVALIAÇÃO FINAL;
/// ASSISTA A AULA GRAVADA DISPONÍVEL NO CONTEÚDO DO EXERCÍCIO DADO;
/// UTILIZE O CONTEÚDO EXTRA DA AULA PARA AUXILIAR NA TAREFA;
/// O EXERCÍCIO DEVE SER ENTREGUE DE MANEIRA INDIVÍDUAL;
/// FAÇA OS COMENTÁRIOS NOS LOCAIS MARCADOS DENTRO DO CÓDIGO;
/// CRIE UM REPOSITÓRIO REMOTO E SUBMETA O SEU PROJETO COMPLETO;
/// AO TÉRMINO ENVIE O LINK PARA O ATIVIDADE ABERTA.
/// </summary>

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    //
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public Vector2 direction = Vector2.right;
    public int initialSize = 4;
        
    //
    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        //
        if (this.direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                this.direction = Vector2.up;
            } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                this.direction = Vector2.down;
            }
        }
        //
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
        // 
        for (int i = _segments.Count - 1; i > 0; i--) {
            _segments[i].position = _segments[i - 1].position;
        }

        // 
        float x = Mathf.Round(this.transform.position.x) + this.direction.x;
        float y = Mathf.Round(this.transform.position.y) + this.direction.y;

        this.transform.position = new Vector2(x, y);
    }
    
    //
    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }
    
    //
    public void ResetState()
    {
        this.direction = Vector2.right;
        this.transform.position = Vector3.zero;

        // 
        for (int i = 1; i < _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        }

        // 
        _segments.Clear();
        _segments.Add(this.transform);

        // 
        for (int i = 0; i < this.initialSize - 1; i++) {
            Grow();
        }
    }

    //
    private void OnTriggerEnter2D(Collider2D other)
    {
        //
        if (other.tag == "Food") {
            Grow();
        } else if (other.tag == "Obstacle") {
            ResetState();
        }
    }

}

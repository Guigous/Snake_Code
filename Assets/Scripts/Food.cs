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

public class Food : MonoBehaviour
{
    public Collider2D gridArea;

    private void Start()
    {
        //
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        //
        Bounds bounds = this.gridArea.bounds;

        //
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // 
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        this.transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //
        RandomizePosition();
    }

}

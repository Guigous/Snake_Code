using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;

    private void Start()
    {
        //metodo de randomizacao
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        //limites da grid
        Bounds bounds = this.gridArea.bounds;

        //valores de limites da grid
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // arredodamento para que a fruta apareca em espacos fisicos
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        this.transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //uso do metodo para randomizar a localizacao da fruta quando o player passa por ela
        RandomizePosition();
    }

}

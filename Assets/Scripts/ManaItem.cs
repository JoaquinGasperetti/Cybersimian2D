using UnityEngine;

// Es un objeto que el jugador puede recoger.
// Al recogerlo, aumenta el mana del jugador.
public class ManaItem : MonoBehaviour, ICollectible
{
    [SerializeField] private float manaAmount = 10f;

    public void Collect()
    {
        var player = FindObjectOfType<PlayerManager>();
        if (player != null)
        {
            player.currentMana = Mathf.Min(player.currentMana + manaAmount, player.maxMana);
            UIManager.Instance.UpdateMana(player.currentMana, player.maxMana); // Actualiza el texto de mana
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
}
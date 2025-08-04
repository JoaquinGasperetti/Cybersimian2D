using UnityEngine;

// Es un objeto que el jugador puede recoger.
// Al recogerlo, desbloquea un nuevo hechizo para el jugador.
public class SpellItem : MonoBehaviour, ICollectible
{
    [SerializeField] private Spell spellToUnlock;

    public void Collect()
    {
        var playerSpells = FindObjectOfType<PlayerSpells>();
        if (playerSpells != null && spellToUnlock != null)
        {
            playerSpells.DesbloquearHechizo(spellToUnlock);
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
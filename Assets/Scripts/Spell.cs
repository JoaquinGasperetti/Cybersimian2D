using UnityEngine;

// Representa un hechizo.
// Al usarlo, gasta mana y lanza un proyectil si tiene uno asignado.
[System.Serializable]
public class Spell
{
    public string nombre;
    public float manaCost;
    public GameObject projectilePrefab;
    public float damage = 10f;

    public virtual void Lanzar(PlayerManager player)
    {
        if (player.currentMana >= manaCost)
        {
            player.UseMana(manaCost);
            Debug.Log($"Hechizo {nombre} lanzado. Mana restante: {player.currentMana}");

            // Instanciar el proyectil
            if (projectilePrefab != null)
            {
                var spawnPos = player.transform.position + player.transform.right; // Ajusta según tu juego
                var proj = GameObject.Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
                var spellProj = proj.GetComponent<SpellProjectile>();
                spellProj.damage = damage;
                spellProj.Init(player.transform.right); // Dispara hacia la derecha del jugador
            }
        }
        else
        {
            Debug.Log("No hay suficiente mana para lanzar el hechizo.");
        }
    }
}
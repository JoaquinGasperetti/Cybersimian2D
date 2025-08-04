using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

// Maneja los hechizos del jugador.
// Permite lanzar, cambiar y desbloquear hechizos.
public class PlayerSpells : MonoBehaviour
{
    [SerializeField] private List<Spell> spellsInspector = new List<Spell>(); // Editable en el inspector
    public GenericContainer<Spell> spellContainer = new GenericContainer<Spell>();
    private PlayerManager playerManager;
    private int currentSpellIndex = 0;

    [SerializeField] private float cooldown = 1f;
    private float tiempoUltimoHechizo;

    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        foreach (var spell in spellsInspector)
        {
            spellContainer.Agregar(spell);
        }
    }

    void Update()
    {
        
    }

    public void LanzarHechizo(int index)
    {
        var spell = spellContainer.ObtenerTodos()[index];
        spell.Lanzar(playerManager);
    }

    public void OnSpellChange(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            int direccion = (int)context.ReadValue<float>(); // Por ejemplo, +1 o -1
            SpellChange(direccion);
        }
    }

    public void OnCastSpell(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LanzarHechizoActual();
        }
    }

    private void SpellChange(int direccion)
    {
        var total = spellContainer.ObtenerTodos().Count;
        if (total == 0) return;

        currentSpellIndex = (currentSpellIndex + direccion + total) % total;
        Debug.Log($"Hechizo seleccionado: {spellContainer.ObtenerTodos()[currentSpellIndex].nombre}");
    }

    private void LanzarHechizoActual()
    {
        if (Time.time - tiempoUltimoHechizo < cooldown)
        {
            Debug.Log("Hechizo en cooldown.");
            return;
        }

        var hechizos = spellContainer.ObtenerTodos();
        if (currentSpellIndex < hechizos.Count)
        {
            hechizos[currentSpellIndex].Lanzar(playerManager);
            tiempoUltimoHechizo = Time.time;
        }
    }

    public void DesbloquearHechizo(Spell nuevoHechizo)
    {
        spellContainer.Agregar(nuevoHechizo);
        Debug.Log($"Hechizo {nuevoHechizo.nombre} desbloqueado.");
    }
}

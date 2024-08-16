using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Defini��o da classe ControladorSom que herda de MonoBehaviour, permitindo que seja usada como um componente em objetos do Unity.
public class ControladorSom : MonoBehaviour
{
    // Vari�vel privada que mant�m o estado atual do som, inicializada como true (som ligado).
    private bool estadoSom = true;

    // Refer�ncia ao componente AudioSource que controla a reprodu��o de �udio de fundo.
    [SerializeField] private AudioSource fundoMusical;

    // Refer�ncia ao sprite que ser� exibido quando o som estiver ligado.
    [SerializeField] private Sprite somLigadoSprite;

    // Refer�ncia ao sprite que ser� exibido quando o som estiver desligado.
    [SerializeField] private Sprite somDesligadoSprite;

    // Refer�ncia ao componente de imagem (Image) que ser� alterado para mostrar o estado atual do som.
    [SerializeField] private Image muteImage;

    // M�todo p�blico para ligar ou desligar o som.
    public void LigarDesligarSom()
    {
        // Alterna o estado do som entre ligado e desligado.
        estadoSom = !estadoSom;

        // Habilita ou desabilita a reprodu��o do �udio de fundo com base no estado atual do som.
        fundoMusical.enabled = estadoSom;

        // Atualiza a imagem do bot�o de mute para refletir o estado atual do som.
        if (estadoSom)
        {
            // Se o som estiver ligado, usa o sprite de som ligado.
            muteImage.sprite = somLigadoSprite;
        }
        else
        {
            // Se o som estiver desligado, usa o sprite de som desligado.
            muteImage.sprite = somDesligadoSprite;
        }
    }

    // M�todo p�blico para ajustar o volume do som de fundo.
    public void VolumeMusical(float value)
    {
        // Define o volume do AudioSource de fundo com o valor fornecido.
        fundoMusical.volume = value;
    }
}

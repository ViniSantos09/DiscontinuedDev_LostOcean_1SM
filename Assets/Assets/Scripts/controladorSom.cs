using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Definição da classe ControladorSom que herda de MonoBehaviour, permitindo que seja usada como um componente em objetos do Unity.
public class ControladorSom : MonoBehaviour
{
    // Variável privada que mantém o estado atual do som, inicializada como true (som ligado).
    private bool estadoSom = true;

    // Referência ao componente AudioSource que controla a reprodução de áudio de fundo.
    [SerializeField] private AudioSource fundoMusical;

    // Referência ao sprite que será exibido quando o som estiver ligado.
    [SerializeField] private Sprite somLigadoSprite;

    // Referência ao sprite que será exibido quando o som estiver desligado.
    [SerializeField] private Sprite somDesligadoSprite;

    // Referência ao componente de imagem (Image) que será alterado para mostrar o estado atual do som.
    [SerializeField] private Image muteImage;

    // Método público para ligar ou desligar o som.
    public void LigarDesligarSom()
    {
        // Alterna o estado do som entre ligado e desligado.
        estadoSom = !estadoSom;

        // Habilita ou desabilita a reprodução do áudio de fundo com base no estado atual do som.
        fundoMusical.enabled = estadoSom;

        // Atualiza a imagem do botão de mute para refletir o estado atual do som.
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

    // Método público para ajustar o volume do som de fundo.
    public void VolumeMusical(float value)
    {
        // Define o volume do AudioSource de fundo com o valor fornecido.
        fundoMusical.volume = value;
    }
}

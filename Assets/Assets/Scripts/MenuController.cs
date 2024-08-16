using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    public void Jogar()
    {
        SceneManager.LoadScene("Ocean");
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
#if UNITY_EDITOR
        // Para sair do modo de execução no editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Para sair da aplicação quando construída
        Application.Quit();
#endif
    }
}
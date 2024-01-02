using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum Idiom
    {
        ptBr,
        en,
        es
    }
    public Idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //janela do diálogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //variáveis de controle
    public bool isShowing;
    private int _index;
    private string[] _sentences;

    public static DialogueControl instance;

    //awake é chamado antes de todos os Start() na hierarquia de execução de scripts
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in _sentences[_index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (speechText.text == _sentences[_index])
        {
            if (_index < _sentences.Length - 1)
            {
                _index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                _index = 0;
                dialogueObj.SetActive(false);
                _sentences = null;
                isShowing = false;
            }
        }
    }
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            _sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Xml;
using System.IO;

public struct Phrase
{
    public string character;
    public string text;
}

public struct Dialogue
{
    public int index;
    public List<Phrase> phrases;
}

public class DialogueManager : MonoBehaviour
{
    public Text target;
    public TextAsset source;
    public Image image;
    public Sprite onion;
    public Sprite olga;
    public Sprite dimitri;
    public Sprite alien;
    public float letterPause = 0.05f;
    public float DialoguePause = 0.1f;
    public int dialogueIndex = 0;
    private int phraseIndex = 0;
    private string message = "";

    public List<Dialogue> dialogues = new List<Dialogue>();

    void Start()
    {
        ParseDialogue();
        PlayDialogue();
    }

    public void ParseDialogue()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(source.text);
        XmlNodeList dialogueList = xmlDoc.GetElementsByTagName("dialogue");

        foreach (XmlNode dialogueInfo in dialogueList)
        {
            XmlNodeList dialogueContent = dialogueInfo.ChildNodes;
            Dialogue currentXMLDialogue;
            currentXMLDialogue.phrases = new List<Phrase>();
            int.TryParse(dialogueInfo.Attributes["index"].Value, out currentXMLDialogue.index);

            foreach (XmlNode dialogueItems in dialogueContent)
            {
                if (dialogueItems.Name == "phrase")
                {
                    Phrase currentXMLPhrase;
                    currentXMLPhrase.character = dialogueItems.Attributes["name"].Value;
                    currentXMLPhrase.text = dialogueItems.InnerText;
                    currentXMLDialogue.phrases.Add(currentXMLPhrase);
                }
            }

            dialogues.Add(currentXMLDialogue);
        }
    }

    public void CreateDialogue()
    {
        Phrase currentPhrase;
        currentPhrase = dialogues[dialogueIndex].phrases[phraseIndex];
        message = currentPhrase.text;

        if (currentPhrase.character == "Onion")
        {
            image.sprite = onion;
        }
        else if (currentPhrase.character == "Olga")
        {
            image.sprite = olga;
        }
        else if (currentPhrase.character == "Dimitri")
        {
            image.sprite = dimitri;
        }
        else if (currentPhrase.character == "Alien")
        {
            image.sprite = alien;
        }
    }

    public void PlayDialogue()
    {
        CreateDialogue();
        target.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            target.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }

        if (phraseIndex < dialogues[0].phrases.Count - 1)
        {
            yield return 0;
            yield return new WaitForSeconds(DialoguePause);
            phraseIndex++;
            PlayDialogue();
        }
        else
        {
            yield return 0;
            yield return new WaitForSeconds(DialoguePause);
            gameObject.SetActive(false);
        }
    }
}

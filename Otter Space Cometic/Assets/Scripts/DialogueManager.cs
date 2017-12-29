using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Xml;
using System.IO;

public struct Dialogue
{
    public string character;
    public string text;
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
    private string message;
    private int index = 0;

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

            foreach (XmlNode dialogueItems in dialogueContent)
            {
                if (dialogueItems.Name == "phrase")
                {
                    Dialogue tempDialogue;
                    tempDialogue.character = dialogueItems.Attributes["name"].Value;
                    tempDialogue.text = dialogueItems.InnerText;
                    dialogues.Add(tempDialogue);
                }
            }
        }
    }

    public void CreateDialogue()
    {
        message = dialogues[index].text;

        if (dialogues[index].character == "Onion")
        {
            image.sprite = onion;
        }
        else if (dialogues[index].character == "Olga")
        {
            image.sprite = olga;
        }
        else if (dialogues[index].character == "Dimitri")
        {
            image.sprite = dimitri;
        }
        else if (dialogues[index].character == "Alien")
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

        if (index < dialogues.Count - 1)
        {
            yield return 0;
            yield return new WaitForSeconds(DialoguePause);
            index++;
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

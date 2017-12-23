using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Xml;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public Text target;
    public TextAsset source;
    public float letterPause = 0.05f;
    private string message;

    List<Dictionary<string, string>> dialogues = new List<Dictionary<string, string>>();
    Dictionary<string, string> obj;

    void Start()
    {
        ParseDialogue();
        PlayDialogue();
    }

    public void ParseDialogue()
    {
        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        xmlDoc.LoadXml(source.text); // load the file.
        XmlNodeList dialogueList = xmlDoc.GetElementsByTagName("dialogue"); // array of the level nodes.

        foreach (XmlNode dialogueInfo in dialogueList)
        {
            XmlNodeList dialogueContent = dialogueInfo.ChildNodes;
            obj = new Dictionary<string, string>(); // Create a object(Dictionary) to colect the both nodes inside the level node and then put into levels[] array.

            foreach (XmlNode dialogueItems in dialogueContent) // levels itens nodes.
            {
                if (dialogueItems.Name == "object")
                {
                    switch (dialogueItems.Attributes["name"].Value)
                    {
                        case "Wife": obj.Add("Wife", dialogueItems.InnerText); break; // put this in the dictionary.
                        case "Dimitri": obj.Add("Dimitri", dialogueItems.InnerText); break; // put this in the dictionary.
                        case "Onion": obj.Add("Onion", dialogueItems.InnerText); break; // put this in the dictionary.
                    }
                }
            }
            dialogues.Add(obj); // add whole obj dictionary in the levels[].
        }
    }

    public void CreateDialogue()
    {
        dialogues[0].TryGetValue("Onion", out message);
        Debug.Log("test " + message);
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
    }
}

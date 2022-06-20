using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DialogSystem;

public class TestXmlParsing
{
    [Test]
    public void TestXmlParsingSuccess()
    {
        string xml = "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>" +
            "<Dialogs>" +
            "<Dialog id=\"1\">" +
            "<Phrase Text=\"Some text\" id=\"start\">" +
            "<Answer Text=\"Answer1\" next=\"0\"/>" +
            "<Answer Text=\"Answer2\" exit=\"true\"/>" +
            "</Phrase>" +
            "<Phrase Text=\"Some text 2\" id=\"0\">" +
            "<Answer Text=\"Answer3\" exit=\"true\"/>" +
            "</Phrase>" +
            "</Dialog>" +
            "</Dialogs>";

        Phrase phrase = XmlToDialog.ReadDialogByString(xml, "1");

        Assert.AreEqual("Some text", phrase.Text);
        Assert.AreEqual("Answer1", phrase.answers[0].Text);
        Assert.AreEqual("Answer2", phrase.answers[1].Text);
        Assert.AreEqual("Some text 2", phrase.answers[0].Next.Text);
    }
}

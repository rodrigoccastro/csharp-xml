using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

public class XmlObject 
{
    private XmlDocument doc;
    private string nohPai;

    public XmlObject(string xml, string nohPai)
    {
        this.nohPai = nohPai;
        doc = new XmlDocument();
        doc.LoadXml(xml);
    }

    public int getSize()
    {
        return doc.SelectSingleNode(nohPai).ChildNodes.Count;
    }

    public string getValueByIndex(int index, int campo)
    {
        return getCampo(index,campo).Value;
    }

    public string getValueByName(int index, string campo)
    {
        return getCampo(index, getIndexCampo(campo)).Value;
    }

    public int getIndexCampo(string campo)
    {
        int index = -1;
        for (int i = 0; i < getListaRegistros().Count; i++)
        {
            if (getCampo(0,i).Name.ToUpper() == campo.ToUpper())
            {
                index = i;
                i = getListaRegistros().Count;
            }
        }
        return index;
    }

    public string getStringXml()
    {
        return doc.InnerXml;
    }

    public XmlDocument getXmlDocument()
    {
        return doc;
    }

    public XmlNode getNohPai()
    {
        return doc.SelectSingleNode(nohPai);
    }

    public XmlNodeList getListaRegistros()
    {
        return getNohPai().ChildNodes;
    }

    public XmlNode getRegistro(int registro)
    {
        return getNohPai().ChildNodes.Item(registro);
    }

    public XmlNodeList getListaCampos()
    {
        return getRegistro(0).ChildNodes;
    }

    public XmlNode getCampo(int registro, int campo)
    {
        return getRegistro(registro).ChildNodes.Item(campo);
    }

}
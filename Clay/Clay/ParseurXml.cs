using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClayData;

namespace Clay
{
    class ParseurXml
    {
        List<Data> MaListData;
        Data MesData;
        public List<Data> LectureXML(string fichierXML)
        {
            XDocument doc = XDocument.Load(fichierXML);
            MaListData = new List<Data>();
            foreach (XElement data in doc.Root.Elements("data"))
            {
                MesData = new Data();

                MesData.offset = data.Element("offset").Value == "" ? 0 : int.Parse(data.Element("offset").Value);
                MesData.pressure = data.Element("pressure").Value == "" ? 0 : int.Parse(data.Element("pressure").Value);
                MesData.layout = data.Element("layout").Value == "" ? 0 : int.Parse(data.Element("layout").Value);
                MesData.component = data.Element("component").Value.ToString();
                MesData.colorbound = data.Element("colorbound").Value.ToString();
                MesData.quality = data.Element("quality").Value.ToString();
                MesData.performance = data.Element("performance").Value.ToString();
                MesData.result = data.Element("result").Value == "" ? 0 : int.Parse(data.Element("result").Value);
                if (data.Attribute("lot") != null)
                {
                    MesData.lot = data.LastAttribute.Value.ToString();
                }
                else
                {
                    MesData.lot = "";
                }

                if (data.Attribute("timecode") != null)
                {
                    MesData.timecode = data.FirstAttribute.Value == "" ? 0 : int.Parse(data.FirstAttribute.Value);
                }
                else
                {
                    MesData.timecode = -1;
                }

                MesData.date = DateTime.Parse(data.Parent.FirstAttribute.Value).Date;
                //string test = MesData.date.ToString("d");

                MaListData.Add(MesData);
            }

            


            return MaListData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clay
{
    class ParseurXml
    {
        List<Data.Datas> MaListData;
        Data.Datas MesData;
        public List<Data.Datas> LectureXML(string fichierXML)
        {
            XDocument doc = XDocument.Load(fichierXML);
            MaListData = new List<Data.Datas>();
            foreach (XElement data in doc.Root.Elements("data"))
            {
                MesData = new Data.Datas();

                MesData.offset = data.Element("offset").Value == "" ? 0 : int.Parse(data.Element("offset").Value);
                MesData.pressure = data.Element("pressure").Value == "" ? 0 : int.Parse(data.Element("pressure").Value);
                MesData.layout = data.Element("layout").Value == "" ? 0 : int.Parse(data.Element("layout").Value);
                MesData.component = data.Element("component").Value.ToString();
                MesData.colorbound = data.Element("colorbound").Value.ToString();
                MesData.quality = data.Element("quality").Value.ToString();
                MesData.perfomance = data.Element("performances").Value.ToString();
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

                MaListData.Add(MesData);
            }

            


            return MaListData;
        }
    }
}

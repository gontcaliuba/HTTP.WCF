using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PAD_04v1
{
    public class XMLWorker
    {
        string xmlName;
        public XMLWorker(string xmlName)
        {
            this.xmlName = xmlName;
        }

        public EmployeeRepository readXML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(EmployeeRepository));
            EmployeeRepository employee = null;
            try
            {
                using (FileStream fs = new FileStream(xmlName, FileMode.Open))
                {
                    employee = (EmployeeRepository)formatter.Deserialize(fs);
                }
            }
            catch
            {
                return null;
            }
            return employee;
        }
        public void writeXML(EmployeeRepository employee)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(EmployeeRepository));
            using (FileStream fs = new FileStream(xmlName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, employee);
            }
        }

        public static string SerializeObject(EmployeeRepository rep)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(rep.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, rep);
                return textWriter.ToString();
            }
        }

        public static string SerializeObject(List<EmployeeRepository> rep_lst)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(rep_lst.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, rep_lst);
                return textWriter.ToString();
            }
        }

    }
}

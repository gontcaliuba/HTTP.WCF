using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace PAD_04v1
{
    public class Validator
    {
        bool errors = false;
        XDocument xsd = XDocument.Load("xsd.txt");

        public Validator(XDocument xml)
        {
            var shemas = new XmlSchemaSet();
            shemas.Add(null, xsd.CreateReader());

            xml.Validate(shemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
        }
        public bool isValid()
        {
            return !errors;
        }

        public override string ToString()
        {
            if (errors) return "Данные не валидны!";
            else return "Данные валидны!";
        }
    }
}

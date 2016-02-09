
namespace HTMLDispatcher
{
    using System;
    using System.Text;

    public class ElementBuilder
    {
        private string elementName;

        public ElementBuilder(string elementName)
        {
            this.ElementName = elementName;
        }

        public string ElementName
        {
            get
            {
                return this.elementName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Element name can not be null or empty");
                }

                this.elementName = value;
            }
        }

        public string Attributes { get; set; }

        public string Content { get; set; }

        public void AddAttribute(string attribute, string value)
        {
            this.Attributes += " " + attribute + "=\"" + value + "\"";
        }

        public void AddContent(string content)
        {
            this.Content += content;
        }

        public override string ToString()
        {
            return string.Format("<{0}{1}>{2}</{0}>", this.ElementName, this.Attributes, this.Content);
        }

        public static string operator *(ElementBuilder element, int value)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < value; i++)
            {
                result.Append(element);
            }
            return result.ToString();
        }
    }
}

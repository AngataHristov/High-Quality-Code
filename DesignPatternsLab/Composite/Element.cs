namespace Composite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Element
    {
        private readonly IList<Element> children;

        private Element child;

        public Element(string type, params Element[] child)
        {
            this.Type = type;
            this.children = new List<Element>(child);
        }

        public string Type { get; private set; }

        public IEnumerable<Element> Children
        {
            get { return this.children; }
        }

        public Element Child
        {
            get
            {
                return this.child;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Child cannot be null");
                }

                this.child = value;
            }
        }

        public void Add()
        {
            this.children.Add(this.Child);
        }

        public void Remove()
        {

        }

        public string Display()
        {
            StringBuilder output = new StringBuilder();
            this.Display(output, 0);

            return output.ToString();
        }

        private void Display(StringBuilder output, int depth)
        {
            output.AppendLine(string.Format("{0}{1}", new string(' ', depth), "<" + this.Type + ">"));

            foreach (var child in this.children)
            {
                child.Display(output, depth + 2);
            }

            output.AppendLine(string.Format("{0}{1}", new string(' ', depth), "</" + this.Type + ">"));
        }
    }
}

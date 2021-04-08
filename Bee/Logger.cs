using System;
using Newtonsoft.Json;

namespace Bee
{
    public class Logger<Label> where Label : Enum
    {
        public Node RootNode { get; }
        public IWriter Writer { get; }
        public bool OutputPerWrite { get; }


        public Logger(IWriter writer, string projectName, string message, bool outputPerWrite = false)
        {
            RootNode = new Node(projectName, message);
            Writer = writer;
            OutputPerWrite = outputPerWrite;
        }
        private Logger(IWriter writer, Node node, bool outputPerWrite = false)
        {
            RootNode = node;
            Writer = writer;
            OutputPerWrite = outputPerWrite;
        }

        public void Write(bool isIndentedFormat = false)
        {
            var json = JsonConvert.SerializeObject(
                RootNode,
                isIndentedFormat ? Formatting.Indented : Formatting.None
            );
            Writer.WriteAll(json);
        }

        public void Log(Label l, string msg)
        {
            var node = LogNode(l, msg);
            RootNode.AddChild(node);
        }

        private Node LogNode(Label l, string msg)
        {
            var node = new Node(l.ToString(), msg);
            if (OutputPerWrite)
            {
                var json = JsonConvert.SerializeObject(node);
                Writer.Write(json);
            }
            return node;
        }

        public Logger<Label> Child(Label l, string msg) =>
            Child<Label>(l, msg);

        public Logger<NewLabel> Child<NewLabel>(Label l, string msg) where NewLabel : Enum
        {
            var node = LogNode(l, msg);
            RootNode.AddChild(node);

            return new Logger<NewLabel>(Writer, node, OutputPerWrite);
        }
    }
}

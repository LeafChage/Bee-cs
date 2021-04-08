using System.Collections.Generic;
using Newtonsoft.Json;

using System;

namespace Bee
{
    [JsonObject("n")]
    public class Node
    {
        [JsonProperty("l")]
        public string Label { get; }

        [JsonProperty("m")]
        public string Message { get; }

        [JsonProperty("ts")]
        public DateTime Timestamp { get; }

        [JsonProperty("ns")]
        public Queue<Node> Nodes { get; }


        public Node(string label, string msg)
        {
            Label = label;
            Message = msg;
            Timestamp = DateTime.Now;
            Nodes = new Queue<Node>();
        }

        public void AddChild(Node node)
        {
            Nodes.Enqueue(node);
        }

        public void AddChild(string label, string msg)
        {
            Nodes.Enqueue(new Node(label, msg));
        }
    }
}

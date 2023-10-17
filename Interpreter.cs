using Microsoft.AspNetCore.Components.Forms;
using System.Net.NetworkInformation;
using System.Text;
using static indexdotinfo.Pages.Index;

namespace indexdotinfo
{
    public class Interpreter
    {
        public static int? MessagesSent { get; set; }
        public static int? MessagesReceived { get; set; }
        public static string? Pending { get; set; }
        public static bool? Affirmative { get; set; } = false;
        public static string? Scenario { get; set; }
        public static string? ForInterpretation { get; set; }
        public static int OutputModule { get; set; } = 0;
        public static List<Line> LinesToRead { get; set; } = new List<Line>() { };
        public static string? ToInterpret { get; set; }
        public static Array? Trigger { get; set; }
        public static bool? StateOne { get; set; } = false;
        public static bool? StateTwo { get; set; } = false;
        public static bool? StateThree { get; set; } = false;
        public static bool? StateFour { get; set; } = false;
        public static bool? StateFive { get; set; } = false;
        public static string ChtIncoming { get; set; } = "incoming";
        public static string ChtOutgoing { get; set; } = "outgoing";
        public static int ChtCountSuggestions { get; set; } = 0;

        // new interpretation
        // get session
        // moment in structure of interpretation (accuracy)
        // report 

        public class Line
        {
            public Line(string aLine)
            {
                AsLine = aLine;
            }
            public string? AsLine { get; set; }
        }

        static public void NewInterpreter()
        {
            Reading.ReadIndex = 0;
            ChtCountSuggestions = 0;
            // empty chat log (review)
        }
        static public void NewInterpretation()
        {
            if (Reading.ReadIndex == 0)
            {
                Reading.ChtState = 1;
                Chat.MsgIncomingTxt = "Introductory approach.";
                Chat.NewMessage();
                Reading.ChtApproach = "Introductory";
            }
            Pending = "The Administrator awaits your response.";
            Chat.CountMessages();
            Chat.MessagesIncoming = false;
            Reading.NewReading();
        }

        static public void InterpretMessage()
        {
            Chat.ReadMessage();
            foreach (var ToRead in Reading.MessagesToRead!)
            {
                ForInterpretation = ToRead.msgContent;
                LinesToRead.Add(new Line(ForInterpretation));
            }
            LinesToRead.Reverse();
            ToInterpret = LinesToRead.ToString();

            Reading.ModuleZero();
            
        }

    }
}

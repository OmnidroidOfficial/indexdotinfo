using Microsoft.AspNetCore.Components.Forms;
using System;
using static indexdotinfo.Pages.Index;

namespace indexdotinfo
{
    public class OutputBuilder
    {
        public static int Attempts { get; set; } = 0;
        public static int? TotalMessages { get; set; }
        public static StreamWriter? StreamWriter { get; set; }
        public static string? Output { get; set; }
        public static int? AskConfirm { get; set; }
        public static InputText? MsgOutgoing { get; set; }
        public static InputText? MsgIncoming { get; set; }
        public StreamReader? ReadStream { get; set; }
        public StringReader? ReadString { get; set; }
        public StringComparer? TxtComparer { get; set; }

        public class OutputStreamLine
        {
            public OutputStreamLine(string lineOut)
            {
                StreamLine = lineOut;
            }
            public string? StreamLine { get; set; }
        }

        public static List<OutputStreamLine> AgrOutput = new List<OutputStreamLine>() { };

        static public void NewOutputBuilder()
        {
            Attempts = 0;
        }

        static public void NewOutput()
        {
            AgrOutput.Clear();
            
            if (Reading.ChtState == 1)
            {
                IntroductoryOutput();
            }
            else if (Reading.ChtState == 2)
            {
                DefinitiveOutput();
            }
            else if (Reading.ChtState == 3)
            {
                ConfirmationalOutput();
            }

            Chat.ReadMessage();
            TotalMessages = Interpreter.MessagesReceived + Interpreter.MessagesSent;
            Attempts++;
        }

        static public void IntroductoryOutput()
        {

        }

        static public void DefinitiveOutput()
        {

        }

        static public void ConfirmationalOutput()
        {

        }

        static public void SubmitOutput()
        {
            System.Collections.IList OutputStreamLines = AgrOutput;
                for (int i = 0; i < OutputStreamLines.Count; i++)
                {
                    string StreamLine = (string)OutputStreamLines[i]!;
                    Chat.MsgIncomingTxt = StreamLine;
                    Chat.NewMessage();
                }
            
        }

        static public void OutputReview()
        {
            
        }
    }
}

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
        public static int OutputModule { get; set; } = 0;
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

        static public void NewInterpreter()
        {
            Reading.ReadIndex = 0;
            Reading.CountMessagesToRead = 0;
            ChtCountSuggestions = 0;
            // empty chat log (review)
        }
        static public void NewInterpretation()
        {
            if (Reading.BookmarkIndex == 0)
            {
                Reading.ChtState = 1;
                Chat.MsgIncomingTxt = "Introductory approach.";
                Chat.NewMessage();
                Reading.ChtApproach = "Introductory";
            }
                Reading.NewReading();
            
        }

        static public void InterpretMessage()
        {
            if (OutputModule == 0)
            {
                Reading.ModuleZero();
            }
            else if (Interpreter.OutputModule == 1)
            {
                Reading.ModuleOne();
            }
            else if (Interpreter.OutputModule == 2)
            {
                Reading.ModuleTwo();
            }
            else if (Interpreter.OutputModule == 3)
            {
                Reading.ModuleThree();
            }
            else if (Interpreter.OutputModule == 4)
            {
                Reading.ModuleFour();
            }
            else if (Interpreter.OutputModule == 5)
            {
                Reading.ModuleFive();
            }
            Reading.StopReading();
        }

    }
}

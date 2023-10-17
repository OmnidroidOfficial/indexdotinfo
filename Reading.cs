using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Diagnostics;
using static indexdotinfo.Pages.Index;
using Microsoft.AspNetCore.WebUtilities;
using System.Reflection;
using System.Collections.Generic;
using static indexdotinfo.Interpreter;

namespace indexdotinfo
{
    public class Reading
    {
        public static int ReadIndex { get; set; } = 0;
        public static int Bookmark { get; set; } = 0;
        public static int BookmarkIndex { get; set; } = 1;
        private static Stopwatch MsgTimer { get; set; } = Stopwatch.StartNew();
        public static string? Modus { get; set; }
        public static int? Direction { get; set; }
        public static string? ChtApproach { get; set; }
        public static string? ChtSubject { get; set; }
        public static string? ChtModus { get; set; }
        public static string? ChtX { get; set; }
        public static string? ChtY { get; set; }
        public static string? ChtZ { get; set; }
        public static string? ToConfirm { get; set; }
        public static string? ChtVisitor { get; set; }
        public static int ChtState { get; set; } = 0;
        public static List<Message> MessagesToRead { get; set; } = new List<Message>() { };
        public static bool? InComparison { get; set; }
        public static int? InComparisonIndex { get; set; }
        public static string? IsReading { get; set; }
        public static int CountMessagesToRead { get; set; } = 0;
        public static string? ChtQuestion = "Is";
        static public void NewReading()
        {
            MsgTimer.Start();
            BookmarkIndex = Chat.MsgCount;
            CountMessagesToRead = BookmarkIndex - Bookmark;
            Interpreter.Pending = "The Administrator has" + CountMessagesToRead + " messages to read.";

            if (MsgTimer.ElapsedMilliseconds > 1000) 
            {
                MsgTimer.Stop();
                MsgTimer.Reset();
                StartReading();
                Chat.MessagesIncoming = true;
                Chat.Typing();
            }

        }
        
        public static void StartReading()
        {

            if (ChtApproach == "Introductory")
            {
         //       ChtApproach = "";
                ChtSubject = "";
                ChtX = "";
                ChtY = "";
                ChtZ = "";
                ChtVisitor = "";
    //            Bookmark = BookmarkIndex;
                Direction = 3;
            }
            else
            {
                Interpreter.Pending = "The Administrator has" + CountMessagesToRead + " messages to read.";
            }
            Chat.ReadMessage();
            InterpretBookmark();
        }

        static public void InterpretBookmark()
        {
            switch (ChtApproach)
            {
                case "Introductory":
                    ChtSubject = "introductory";
                    ChtModus = "initiate";
                    ChtZ = "to" + ChtY;
                    Interpreter.Scenario = "A";
                    Interpreter.OutputModule = 0; 
                    ModuleZero();
                    break;
                case "Simple":
                    ChtSubject = "simple approach to finding an answer";
                    ChtModus = "as simple as possible";
                    ChtZ = "to find";
                    Interpreter.Scenario = "B";
                    break;
                case "Advanced":
                    ChtSubject = "advanced approach to finding an answer";
                    ChtModus = "in detail";
                    ChtZ = "to define";
                    ChtQuestion = "If";
                    Interpreter.Scenario = "C";
                    break;
                case "Custom":
                    ChtSubject = "custom approach to this chat";
                    ChtModus = "custom";
                    ChtZ = "to" + ChtY;
                    ChtQuestion = "If";
                    Interpreter.Scenario = "D";
                    break;
            }
            Bookmark = BookmarkIndex - CountMessagesToRead;
            Interpreter.InterpretMessage();
        }

        public static void StopReading()
        {
            SessionMessages.Add(new Message(Session.NowTxtTime, "The Administrator", "Messages read.", "end", "right"));
            Bookmark = BookmarkIndex;
            Chat.MessagesIncoming = true;
            ReadIndex++;

        }

        static public void ModuleZero()
        {    
            bool InComparison = Interpreter.ToInterpret!.Contains("Hello.");
         //   int InComparisonIndex = ToInterpret!.IndexOf("Hello.");
                if (InComparison == true)
                {
                    SessionMessages.Add(new Message(Session.NowTxtTime, "The Administrator", "Woooow.", "end", "right"));
                }
                else
                {
                    SessionMessages.Add(new Message(Session.NowTxtTime, "The Administrator", "Oké." + ForInterpretation, "end", "right"));
                }
            
            OutputBuilder.NewOutput();
        }
        static public void ModuleOne()
        {
            Interpreter.OutputModule = 1;
            Interpreter.StateOne = true;
            if (Modus == "Introduce")
            {
                Interpreter.Pending = "use ''find' + text ' for simple chat, use ''define' + text' for advanced chat, use 'custom' for quick custom chat";
            }
            else if (Modus == "Define")
            {
                Interpreter.Pending = "";
            }
            else if (Modus == "Confirm")
            {

            }

        }

        static public void ModuleTwo()
        {
            Interpreter.OutputModule = 2;
            Interpreter.StateTwo = true;
        }

        static public void ModuleThree()
        {
            Interpreter.OutputModule = 3;
            Interpreter.StateThree = true;
        }

        static public void ModuleFour()
        {
            Interpreter.OutputModule = 4;
            Interpreter.StateFour = true;
        }

        static public void ModuleFive()
        {
            Interpreter.OutputModule = 5;
            Interpreter.StateFive = true;
        }
    }
}

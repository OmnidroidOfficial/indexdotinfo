using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Diagnostics;
using static indexdotinfo.Pages.Index;
using Microsoft.AspNetCore.WebUtilities;
using System.Reflection;

namespace indexdotinfo
{
    public class Reading
    {
        public static int ReadIndex { get; set; } = 0;
        public static int Bookmark { get; set; } = 0;
        public static int BookmarkIndex { get; set; } = 1;
        private static Stopwatch MsgTimer { get; set; } = Stopwatch.StartNew();
        public static string? Modus { get; set; }
        public static string? ChtApproach { get; set; }
        public static string? ChtSubject { get; set; }
        public static string? ChtModus { get; set; }
        public static string? ChtX { get; set; }
        public static string? ChtY { get; set; }
        public static string? ChtZ { get; set; }
        public static string? ToConfirm { get; set; }
        public static string? ChtVisitor { get; set; }
        public static int ChtState { get; set; } = 0;
        public static Array? MessagesToRead { get; set; }
        public static int CountMessagesToRead { get; set; } = 0;
        public static string ChtQuestion = "Is";
        static public void NewReading()
        {
            MsgTimer.Start();
            if (MsgTimer.ElapsedMilliseconds > 10000) 
            {
                MsgTimer.Stop();
                Chat.CountMessages();
                StartReading();
            }

        }

        public static void StartReading()
        {
            BookmarkIndex = Chat.MsgCount;
            CountMessagesToRead = BookmarkIndex - Bookmark;
            Bookmark = BookmarkIndex - CountMessagesToRead;

            if (ChtApproach == "Introductory")
            {
                ChtApproach = "";
                ChtSubject = "";
                ChtX = "";
                ChtY = "";
                ChtZ = "";
                ChtVisitor = "";
                Bookmark = BookmarkIndex;
            }
            else
            {
                Interpreter.Pending = "The Administrator has" + CountMessagesToRead + " messages to read.";
            }
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
                    ModuleZero();
                    break;
                case "Simple":
                    ChtSubject = "simple approach to finding an answer";
                    ChtModus = "as simple as possible";
                    ChtZ = "to find";
                    break;
                case "Advanced":
                    ChtSubject = "advanced approach to finding an answer";
                    ChtModus = "in detail";
                    ChtZ = "to define";
                    ChtQuestion = "If";
                    break;
                case "Custom":
                    ChtSubject = "custom approach to this chat";
                    ChtModus = "custom";
                    ChtZ = "to" + ChtY;
                    ChtQuestion = "If";
                    break;
            }
            Chat.ReadMessage();
            Interpreter.InterpretMessage();
        }

        public static void StopReading()
        {
            Bookmark = BookmarkIndex;
            Chat.MessagesIncoming = true;
            ReadIndex++;
        }

        static public void ModuleZero()
        {
            if (Modus == "Introduce")
            {
                Interpreter.Pending = "use ''find' + text ' for simple chat, use ''define' + text' for advanced chat, use 'custom' for quick custom chat";
            }
            else if (Modus == "Define")
            {
                Interpreter.Pending = 
            }
            else if (Modus == "Confirm")
            {

            }
        }
        static public void ModuleOne()
        {
            Interpreter.OutputModule = 1;
            Interpreter.StateOne = true;
            

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

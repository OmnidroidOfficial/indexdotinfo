using static indexdotinfo.Pages.Index;

namespace indexdotinfo
{
    public class Session
    {
        public static bool IsSessionActive { get; set; } = false;
        public static string? Alerts { get; set; }
        public static string TxtSessionState { get; set; } = "active";
        public static string NowTxtTime { get; set; } = DateTime.Now.ToString(format: "hh:mm tt (HH:mm)");
        public string? NowTxtDate { get; set; }
        public void TokenSession()
        {
            
        }
    }
}

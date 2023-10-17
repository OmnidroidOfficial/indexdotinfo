namespace indexdotinfo
{
    public class Title
    {
        public static string PageName { get; set; } = "Regentesse.info";
        public static string PageYear { get; set; } = DateTime.Now.Year.ToString();
        public static string PageTime { get; set; } = DateTime.Now.ToString(format: "hh:mm tt");
        public static string PageDate { get; set; } = DateTime.Now.ToShortDateString();
    }
}

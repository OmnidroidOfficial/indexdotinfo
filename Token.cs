using Microsoft.AspNetCore.Components;

namespace indexdotinfo
{
    public class Token
    {
        [Parameter]
        public int? TokenID { get; set; }
        public string? TokenName { get; set; }
        public string? TokenType { get; set; }
        public string? TokenDescription { get; set; }

        public Token(int id_token, string name_token, string type_token, string description_token)
        {
            TokenID = id_token;
            TokenName = name_token;
            TokenType = type_token;
            TokenDescription = description_token;
        }
    }
}

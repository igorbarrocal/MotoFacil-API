namespace MotoFacilAPI.Application.Dtos
{
    public class LinkDto
    {
        /// <example>self</example>
        public string Rel { get; set; } = string.Empty;
        /// <example>/api/motos/1</example>
        public string Href { get; set; } = string.Empty;
        /// <example>GET</example>
        public string Method { get; set; } = "GET";
    }
}
namespace domino_api.Utilities
{
    public static class JwtUtils
    {
        public static readonly string Key = "JWTAuthentication@777";
        public static readonly string Issuer = "JWTAuthenticationServer";
        public static readonly string Audience = "JWTServicePostmanClient";
        public static readonly string Subject = "JWTServiceAccessToken";
    }
}

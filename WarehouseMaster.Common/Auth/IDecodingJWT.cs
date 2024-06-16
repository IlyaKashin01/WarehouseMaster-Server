namespace WarehouseMaster.Common.Auth
{
    public interface IDecodingJWT
    {
        string? getJWTTokenClaim(string token, string claimName);
    }
}

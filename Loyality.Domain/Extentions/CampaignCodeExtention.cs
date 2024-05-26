using System.Security.Cryptography;
using System.Text;
using Loyality.Domain.Constants;
using Loyality.Domain.Dtos.CampaignCode;

namespace Loyality.Domain.Extentions;

public static class CampaignCodeExtention
{
    private const string Characters = CommonConstant.CompaignCodePattern;
    private static readonly Random Random = new Random();

    public static List<CampaignCodeDto> GenerateCode(int codeCount)
    {
        var result = new List<CampaignCodeDto>();
        for (int i = 0; i < codeCount; i++)
        {
            var code = new char[7];
            for (int j = 0; j < 7; j++)
            {
                code[j] = Characters[Random.Next(Characters.Length)];
            }

            var codeString = new string(code);
            var checkCharacter = GetCheckCharacter(codeString);
            var codeResult = new CampaignCodeDto()
            {
                Code = codeString + checkCharacter
            };
            result.Add(codeResult);
        }

        return result;

    }

    public static bool ValidateCode(string code)
    {
        if (code.Length != 8) return false;
        
        var mainPart = code.Substring(0, 7);
        var checkCharacter = code[7];

        return checkCharacter == GetCheckCharacter(mainPart);
    }

    private static char GetCheckCharacter(string code)
    {
        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(code));
            var hashValue = BitConverter.ToUInt32(hash, 0);
            return Characters[(int)(hashValue % (uint)Characters.Length)];
        }
    }
}
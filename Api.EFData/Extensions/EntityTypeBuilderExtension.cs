//using System.Security.Cryptography;
//using System.Text;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using OpenWorker.Domain.DatabaseHelper.Models;

//namespace OpenWorker.EFData.Extensions;

//internal static class EntityTypeBuilderExtension
//{
//    internal static DataBuilder<AccountModel> HasDefaultData(this EntityTypeBuilder<AccountModel> builder)
//    {
//        var password = SHA512.HashData(Encoding.UTF8.GetBytes("qwe123"));

//        var data = new[]
//        {
//            new AccountModel
//            {
//                Id = 1,
//                Nickname = "sawich",
//                Password = password,
//            }
//        };

//        return builder.HasData(data);
//    }
//}

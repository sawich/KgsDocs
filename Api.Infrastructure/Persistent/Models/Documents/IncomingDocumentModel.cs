using Api.Domain.Enums;

namespace Api.Infrastructure.Persistent.Models.Documents
{
    public sealed class IncomingDocumentModel
    {
        public int Id { get; init; }

        /// <summary>
        /// Отправитель письма
        /// </summary>
        public string MailSender { get; init; } = string.Empty;

        /// <summary>
        /// Тип письма
        /// </summary>
        public MailType MailType { get; init; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateOnly RegisteredAt { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// Исходящая дата
        /// </summary>
        public DateOnly OutcomingAt { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// Исходящая дата
        /// </summary>
        public DateOnly IncomingAt { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// Регистрационный номер письма
        /// </summary>
        public int MailRegistrationNumber { get; init; }

        /// <summary>
        /// Исходящий номер
        /// </summary>
        public int OutcomingNumber { get; init; }

        /// <summary>
        /// Краткое содержание письма
        /// </summary>
        public string BriefContentOfMail { get; init; } = string.Empty;

        /// <summary>
        /// Файл
        /// </summary>
        public FileModel File { get; init; } = FileModel.Empty;
    }
}

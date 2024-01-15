namespace Api.Domain.Enums;

public enum MailType
{
    /// <summary>
    /// Входящее письмо
    /// Направляется генеральному директору на назначение
    /// </summary>
    Inbox,

    /// <summary>
    /// Письмо от ЧСИ
    /// Направляется на исполнение главному бухгалтеру
    /// </summary>
    FromPrivateCourtExecutor
}
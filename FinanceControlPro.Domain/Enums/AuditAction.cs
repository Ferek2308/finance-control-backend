namespace FinanceControlPro.Domain.Enums;

public enum AuditAction
{
    LOGIN_SUCCESS,
    LOGIN_FAILED,
    LOGOUT,

    USER_CREATED,
    USER_DISABLED,
    USER_ROLE_CHANGED,

    TOKEN_REFRESH,
    UNAUTHORIZED_ACCESS,

    //SYSTEM_STARTUP
}

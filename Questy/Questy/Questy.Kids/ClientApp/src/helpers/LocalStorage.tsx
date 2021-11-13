const LSConstants = {
    "TOKEN": "token",
    "TOKEN_EXPIRES": "tokenExpires"
}

export default {
    getToken: (): string | null => getToken(),
    setToken: (token: string): string => setToken(token),
    clearToken: (): boolean => clearToken()
}

function getToken(): string | null {
    return window.localStorage.getItem(LSConstants.TOKEN);
}

function setToken(token: string): string {
    window.localStorage.setItem(LSConstants.TOKEN, token);
    return token;
}

function clearToken(): boolean {
    window.localStorage.removeItem(LSConstants.TOKEN);
    return true;
}
const LSConstants = {
    "TOKEN": "token",
    "TOKEN_EXPIRES": "tokenExpires",
    "USERNAME": "username"
}

export default {
    getToken: ():string | null => getToken(),
    setToken: (token: string): string => setToken(token),
    clearToken: (): boolean => clearToken(),
    getUsername: ():string | null => getUsername(),
    setUsername: (username: string): string => setUsername(username)
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

function getUsername(): string | null {
    return window.localStorage.getItem(LSConstants.USERNAME);
}

function setUsername(username: string): string {
    window.localStorage.setItem(LSConstants.USERNAME, username);
    return username;
}
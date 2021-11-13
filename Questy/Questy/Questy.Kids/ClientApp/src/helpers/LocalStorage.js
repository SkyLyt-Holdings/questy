"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LSConstants = {
    "TOKEN": "token",
    "TOKEN_EXPIRES": "tokenExpires"
};
exports.default = {
    getToken: function () { return getToken(); },
    setToken: function (token) { return setToken(token); },
    clearToken: function () { return clearToken(); }
};
function getToken() {
    return window.localStorage.getItem(LSConstants.TOKEN);
}
function setToken(token) {
    window.localStorage.setItem(LSConstants.TOKEN, token);
    return token;
}
function clearToken() {
    window.localStorage.removeItem(LSConstants.TOKEN);
    return true;
}
//# sourceMappingURL=LocalStorage.js.map
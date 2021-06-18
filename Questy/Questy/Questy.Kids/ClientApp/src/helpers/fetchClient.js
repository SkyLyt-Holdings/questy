"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.fetchClient = void 0;
var LocalStorage_1 = require("./LocalStorage");
var logger_1 = require("./logger");
var baseUrl = "http://localhost:55795/api";
var OK = 200;
var CREATED_AT = 201;
var NO_CONTENT = 204;
var BAD_REQUEST = 400;
var UNAUTHORIZED = 401;
var FORBIDDEN = 403;
var NOT_FOUND = 404;
var SERVER_ERROR = 500;
exports.fetchClient = {
    get: function (request) { return getRequest(request); },
    post: function (request) { return postRequest(request); },
    put: function (request) { return putRequest(request); },
    delete: function (request) { return deleteRequest(request); }
};
function getApiToken() {
    var token = LocalStorage_1.default.getToken();
    return token;
}
function baseErrorHandler(error) {
    logger_1.default.log("Error: ", error);
}
function getRequest(req) {
    var token = getApiToken();
    var head = new Headers();
    head.append("Authorization", "bearer " + token);
    fetch(baseUrl + req.endpoint, { headers: head })
        .then(function (res) { return responseHandler(res); })
        .then(function (data) { return req.callback(data); })
        .catch(function (error) {
        if (req.onError) {
            req.onError(error);
        }
        baseErrorHandler(error.message);
    });
}
function postRequest(req) {
    var token = getApiToken();
    var head = new Headers();
    head.append("Authorization", "bearer " + token);
    head.append("Content-Type", "application/json");
    fetch(baseUrl + req.endpoint, { method: "POST", headers: head, body: JSON.stringify(req.data) })
        .then(function (res) { return responseHandler(res); })
        .then(function (data) { return req.callback(data); })
        .catch(function (error) {
        if (req.onError) {
            req.onError(error);
        }
        baseErrorHandler(error.message);
    });
}
function putRequest(req) {
    var token = getApiToken();
    var head = new Headers();
    head.append("Authorization", "bearer " + token);
    head.append("Content-Type", "application/json");
    fetch(baseUrl + req.endpoint, { method: "PUT", headers: head, body: JSON.stringify(req.data) })
        .then(function (res) { return responseHandler(res); })
        .then(function (data) { return req.callback(data); })
        .catch(function (error) {
        if (req.onError) {
            req.onError(error);
        }
        baseErrorHandler(error.message);
    });
}
function deleteRequest(req) {
    var token = getApiToken();
    fetch(baseUrl + req.endpoint, { method: "DELETE", headers: { "Authorization": "bearer " + token } })
        .then(function (res) { return responseHandler(res); })
        .then(function (data) { return req.callback(data); })
        .catch(function (error) {
        if (req.onError) {
            req.onError(error);
        }
        baseErrorHandler(error.message);
    });
}
function responseHandler(res) {
    return __awaiter(this, void 0, void 0, function () {
        var redirectPath;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    if (res.status === OK || res.status === CREATED_AT)
                        return [2 /*return*/, res.json()];
                    if (res.status === NO_CONTENT)
                        return [2 /*return*/, true];
                    if (res.status === UNAUTHORIZED) {
                        redirectPath = window.location.pathname;
                        if (redirectPath === "/")
                            window.location.href = "/login";
                        else
                            window.location.href = "/login?referrer=" + encodeURI(redirectPath);
                        throw "Unauthorized";
                    }
                    if (!!res.ok) return [3 /*break*/, 2];
                    return [4 /*yield*/, res.json()];
                case 1: throw _a.sent();
                case 2: return [2 /*return*/];
            }
        });
    });
}
//# sourceMappingURL=fetchClient.js.map
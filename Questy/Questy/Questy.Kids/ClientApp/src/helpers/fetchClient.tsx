import LocalStorage from "./LocalStorage";
import logger from "./logger";

export interface fetchRequest {
    endpoint: string,
    callback: ((data: any) => any) | ((data: any) => void),
    onError?: ((error: any) => any) | ((error: any) => void)
}

export interface fetchErrorResponse {
    statusCode: number,
    message: string,
    data: any
}

export interface fetchDataRequest extends fetchRequest {
    data?: any
}

const baseUrl = "http://localhost:55795/api";
const OK = 200;
const CREATED_AT = 201;
const NO_CONTENT = 204;
const BAD_REQUEST = 400;
const UNAUTHORIZED = 401;
const FORBIDDEN = 403;
const NOT_FOUND = 404;
const SERVER_ERROR = 500;

export const fetchClient = {
    get: (request: fetchRequest) => getRequest(request),
    post: (request: fetchDataRequest) => postRequest(request),
    put: (request: fetchDataRequest) => putRequest(request),
    delete: (request: fetchRequest) => deleteRequest(request)
}

function getApiToken() {
    const token = LocalStorage.getToken();
    return token;
}

function baseErrorHandler(error: string) {
    logger.log("Error: ", error);
}

function getRequest(req: fetchRequest) {
    const token = getApiToken();
    var head = new Headers();
    head.append("Authorization", `bearer ${token}`);

    fetch(baseUrl + req.endpoint, { headers: head })
        .then(res => responseHandler(res))
        .then(data => req.callback(data))
        .catch((error: fetchErrorResponse) => {
            if (req.onError) {
                req.onError(error);
            }
            baseErrorHandler(error.message);
        })
}

function postRequest(req: fetchDataRequest) {
    const token = getApiToken();
    var head = new Headers();
    head.append("Authorization", `bearer ${token}`);
    head.append("Content-Type", "application/json");

    fetch(baseUrl + req.endpoint, { method: "POST", headers: head, body: JSON.stringify(req.data) })
        .then(res => responseHandler(res))
        .then(data => req.callback(data))
        .catch((error: fetchErrorResponse) => {
            if (req.onError) {
                req.onError(error);
            }
            baseErrorHandler(error.message);
        })
}

function putRequest(req: fetchDataRequest) {
    const token = getApiToken();
    var head = new Headers();
    head.append("Authorization", `bearer ${token}`);
    head.append("Content-Type", "application/json");

    fetch(baseUrl + req.endpoint, { method: "PUT", headers: head, body: JSON.stringify(req.data) })
        .then(res => responseHandler(res))
        .then(data => req.callback(data))
        .catch((error: fetchErrorResponse) => {
            if (req.onError) {
                req.onError(error);
            }
            baseErrorHandler(error.message);
        })
}

function deleteRequest(req: fetchRequest) {
    const token = getApiToken();

    fetch(baseUrl + req.endpoint, { method: "DELETE", headers: { "Authorization": `bearer ${token}` } })
        .then(res => responseHandler(res))
        .then(data => req.callback(data))
        .catch((error: fetchErrorResponse) => {
            if (req.onError) {
                req.onError(error);
            }
            baseErrorHandler(error.message);
        })
}

async function responseHandler(res: Response) {
    if (res.status === OK || res.status === CREATED_AT) return res.json();
    if (res.status === NO_CONTENT) return true;
    if (res.status === UNAUTHORIZED) {
        const redirectPath = window.location.pathname;
        if (redirectPath === "/") window.location.href = "/login";
        else window.location.href = `/login?referrer=${encodeURI(redirectPath)}`
        throw "Unauthorized";
    }

    if (!res.ok) throw await res.json();
}
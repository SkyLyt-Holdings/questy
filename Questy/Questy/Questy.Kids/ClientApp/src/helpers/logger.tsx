const logger = {
    log: log
}

function log(message?: any, ...optionalParams: any[]) {
    if (process.env.REACT_APP_ENVIRONMENT !== "production") {
        if (optionalParams.length > 0) {
            console.log(message, optionalParams);
        }
        else {
            console.log(message);
        }
    }
}

export default logger
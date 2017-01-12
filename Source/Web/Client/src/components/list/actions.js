import callApi from "../../state/callApi";

export const ListActions = {
    Request: "LIST_REQUEST",
    Receive: "LIST_RECEIVE",
    Error: "LIST_ERROR",
};

function request() {
    return {
        type: ListActions.Request
    };
}

function receive(json) {
    return {
        type: ListActions.Receive,
        json
    };
}

function error() {
    return {
        type: ListActions.Error
    };
}

export function fetchList(list) {
    return callApi("/api/lists/" + list, request, receive, error);
}

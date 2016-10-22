﻿export const Actions = {
    RequestStart: 'REQUEST_START',
    ReceiveMountain: 'RECEIVE_MOUNTAIN',
    ReceiveClassification: 'RECEIVE_CLASSIFICATION',
    ReceiveSearch: 'RECEIVE_SEARCH',
    RequestIgnored: 'REQUEST_IGNORED',
    RequestError: 'REQUEST_ERROR'
};

function requestStart() {
    return {
        type: Actions.RequestStart
    }
}

function receiveMountain(json) {
    return {
        type: Actions.ReceiveMountain,
        json
    }
}

function receiveClassification(json) {
    return {
        type: Actions.ReceiveClassification,
        json
    }
}

function receiveSearch(json) {
    return {
        type: Actions.ReceiveSearch,
        json
    }
}

function requestIgnored() {
    return {
        type: Actions.RequestIgnored
    }
}

function requestError() {
    return {
        type: Actions.RequestError
    }
}

export function fetchMountain(id) {
    return callApi('/api/mountains/' + id, receiveMountain);
}

export function fetchClassification(classification) {
    return callApi('/api/classifications/mountains/' + classification, receiveClassification);
}

export function search(term) {

    if (!term || term.length < 3) {
        return dispatch => dispatch(requestIgnored());
    }

    return callApi('/api/mountains/search/' + term, receiveSearch);
}

function callApi(url, onSuccess) {
    return dispatch => {
        dispatch(requestStart());
        return fetch(url, {redirect: 'follow', mode: 'cors'})
            .then(response => {
                if (!response.ok) {
                    throw new Error();
                }
                return response.json();
            })
            .then(json => {
                dispatch(onSuccess(json));
            })
            .catch(function(error) {
                dispatch(requestError());
            });
    }
}
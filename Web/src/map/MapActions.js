'use strict';

import alt from '../alt';

class MapActions {

    createMap(htmlElement) {
        return htmlElement;
    }

    zoomIn() {
        return true;
    }

    zoomOut() {
        return true;
    }

    reset() {
        return true;
    }

    destroyMap() {
        return true;
    }

}

export default alt.createActions(MapActions);
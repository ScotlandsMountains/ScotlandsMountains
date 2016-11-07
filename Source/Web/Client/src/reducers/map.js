﻿import { MapActions } from '../actions/map';
import mapFactory from '../factories/mapFactory';

const map = (mapObject = null, action) => {
    switch (action.type) {
        
        case MapActions.Create:
            return mapFactory(action.elementId);

        case MapActions.ZoomIn:
            mapObject.zoomIn();
            break;

        case MapActions.ZoomOut:
            mapObject.zoomOut();
            break;

        case MapActions.Reset:
            mapObject.reset();
            break;

        case MapActions.SetBaseLayer:
            mapObject.setBaseLayer(action.baseLayer);
            break;

        case MapActions.Destroy:
            return null;

        default:
            break;
    }

    return mapObject;
};

export default map;
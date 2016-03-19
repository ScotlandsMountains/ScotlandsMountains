'use strict';

import React from 'react';
import ReactDOM from 'react-dom';

import ToolBarComponent from './ToolBarComponent';
import SearchBarComponent from './SearchBarComponent';
import buildMap from './MapFactory';

const center = [57.5, -4.6];
const zoom = 7;

class MapComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            showSearch: false,
            view: 'Map'
        };
        
        this.toggleSearch = this.toggleSearch.bind(this)
        this.zoomIn = this.zoomIn.bind(this)
        this.zoomOut = this.zoomOut.bind(this)
        this.reset = this.reset.bind(this)
        this.setBaseLayer = this.setBaseLayer.bind(this)
    }

    componentDidMount() {
        this.map = buildMap(ReactDOM.findDOMNode(this.refs.map), center, zoom);
    }

    componentWillUnmount() {
        this.map = null;
    }

    toggleSearch() { this.setState({showSearch: !this.state.showSearch}); }

    zoomIn() { this.map.zoomIn(); }

    zoomOut() { this.map.zoomOut(); }

    reset() { this.map.reset(center, zoom); }

    setBaseLayer(layer) { this.map.setBaseLayer(layer); }

    render() {
        
        let searchBar = this.state.showSearch ? <SearchBarComponent /> : null;
        
        return (
            <div id="map-component">
                <div id="map" ref="map"></div>
                <div id="map-control">
                    <ToolBarComponent
                        toggleSearch={this.toggleSearch}
                        zoomIn={this.zoomIn}
                        zoomOut={this.zoomOut}
                        reset={this.reset} 
                        setBaseLayer={this.setBaseLayer} />
                    {searchBar}
                </div>
            </div>
        );
    }
}

export default MapComponent;
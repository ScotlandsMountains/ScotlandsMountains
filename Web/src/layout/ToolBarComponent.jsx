'use strict';

import React from 'react';
import LayoutActions from './LayoutActions';
import MapActions from '../map/MapActions';

import Toolbar from 'material-ui/lib/toolbar/toolbar';
import ToolbarGroup from 'material-ui/lib/toolbar/toolbar-group';
import IconButton from 'material-ui/lib/icon-button';
import IconMenu from 'material-ui/lib/menus/icon-menu';
import MenuItem from 'material-ui/lib/menus/menu-item';

import ContentAddCircleOutline from 'material-ui/lib/svg-icons/content/add-circle-outline';
import ContentRemoveCircleOutline from 'material-ui/lib/svg-icons/content/remove-circle-outline';
import NavigationRefresh from 'material-ui/lib/svg-icons/navigation/refresh';
import MapsSatellite from 'material-ui/lib/svg-icons/maps/satellite';
import MapsMap from 'material-ui/lib/svg-icons/maps/map';
import MapsLayers from 'material-ui/lib/svg-icons/maps/layers';
import MapsMyLocation from 'material-ui/lib/svg-icons/maps/my-location';

import MapButtonsComponent from './MapButtonsComponent.jsx';
import SearchComponent from '../search/SearchComponent.jsx';

class ToolBarComponent extends React.Component {

    constructor(props) {
        super(props);

        // React components using ES6 classes no longer autobind `this` to non React methods
        this.handleOpenSearch = this.handleOpenSearch.bind(this)
        this.handleCloseSearch = this.handleCloseSearch.bind(this)
    }
    
    handleOpenSearch() {
        this.props.onOpenSearch();
    }
    
    handleCloseSearch() {
        this.props.onCloseSearch();
    }

    render() {

        return (
            <Toolbar style={{position:'fixed',top:'64',minWidth:'440px', height:'46', zIndex:'1350'}}>
                <ToolbarGroup firstChild={true} float="left">
                    
                    <SearchComponent
                        open={this.props.searchOpen}
                        onOpen={this.handleOpenSearch}
                        onClose={this.handleCloseSearch} />
                    
                    <span style={{display: this.props.searchOpen ? 'none' : 'inline'}}>
                        <MapButtonsComponent />            
                    </span>
                    
                </ToolbarGroup>
            </Toolbar>
        );
    }
}

export default ToolBarComponent;
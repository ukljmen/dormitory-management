import React, { useEffect, useState } from "react";
import Sidebar from "../../components/Sidebar/Sidebar";
import FloorsComponent from "../../components/FloorsComponent/FloorsComponent";

import "./ManageRoomsView.css";

const ManageRoomsView = () => {
    return (
        <Sidebar>
            <h1>Zarządzanie pokojami</h1>
            <div className="manageRoomsMain">
                <FloorsComponent isDirectMessages={false}/>
            </div>
        </Sidebar>
    )
}

export default ManageRoomsView;
import React, { useEffect, useState } from "react";
import Sidebar from "../../components/Sidebar/Sidebar";
import { GetFloors } from "../../services/RoomsService";
import { Floor, RoomSimple } from "../../models/Floor";
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';

import "./FloorsComponent.css";
import { Collapse, ListItemButton, ListItemIcon } from "@mui/material";
import { CheckBox } from "@mui/icons-material";
import { useNavigate } from "react-router-dom";

interface RoomState {
    [key: number] : boolean;
}

const FloorsComponent = ({isDirectMessages} : {isDirectMessages : boolean}) => {

    const [floors, setFloors] = useState<Floor[]>([]);
    const [collapsedFloors, setCollapsedFloors] = useState<boolean[]>([]);
    const [collapsedRooms, setCollapsedRooms] = useState<Map<number, boolean>>(new Map());

    const toggleFloor = (floorNumber: number) : void => {
        const cf = collapsedFloors.map((cf, i) => {
            if(i === floorNumber - 1){
                return !cf;
            } else {
                return cf;
            }
        })

        setCollapsedFloors(cf);
    }

    const toggleRoom = (roomNumber: number) : void => {
        const cr = new Map(collapsedRooms);
        cr.set(roomNumber, !cr.get(roomNumber));
        setCollapsedRooms(cr);
    }

    let navigate = useNavigate();

    useEffect(() => {
        GetFloors()
            .then((res) => {
                setFloors(res.data);
                const cf = res.data.map(() => false);

                let mp = new Map();
                res.data.forEach((f : Floor) => 
                    f.rooms.forEach((r) => {
                        mp.set(r.roomNumber, false);
                    }));
                                
                setCollapsedRooms(mp);
                setCollapsedFloors(cf);
            })
            .catch((err) => {
                console.log(err);
            })
    }, [setFloors]);

    return (
        <List
            sx={{ width: '100%', maxWidth: '50%', bgcolor: 'background.paper' }}
            component="nav"
            aria-labelledby="nested-list-subheader">
            {
                floors.map((f) => (
                    <ListItem className="floorListItem">
                        Piętro {f.floorNumber}, {collapsedFloors[f.floorNumber - 1] ? 'true' : 'false'}
                        <Collapse in={collapsedFloors[f.floorNumber - 1]} timeout="auto">
                            <List>
                                {f.rooms.map((r) => (
                                    <ListItem className='roomListItem'>
                                        Pokój {r.roomNumber}, {collapsedRooms.get(r.roomNumber) ? 'true' : 'false'}
                                        <Collapse in={collapsedRooms.get(r.roomNumber)} timeout="auto" unmountOnExit>
                                            <List>
                                                {r.students.map((s) => (
                                                    <ListItem className='studentListItem'>
                                                        {s.name}
                                                        {
                                                            isDirectMessages &&
                                                            <ListItemButton>
                                                                <ListItemIcon>
                                                                    <CheckBox>
                                                                    
                                                                    </CheckBox>
                                                                </ListItemIcon>
                                                            </ListItemButton>
                                                        }
                                                    </ListItem>
                                                ))}
                                            </List>                                        
                                        </Collapse>
                                        {
                                            isDirectMessages &&
                                            <ListItemButton 
                                                onClick={() => toggleRoom(r.roomNumber)}>
                                                {'>'}
                                            </ListItemButton>
                                        }
                                        {
                                            !isDirectMessages &&
                                            <ListItemButton 
                                                onClick={() => {
                                                    localStorage.setItem('roomId', r.id.toString());
                                                    navigate('/roomDetails');
                                                }}>
                                                {'>'}
                                            </ListItemButton>
                                        }
                                    </ListItem>
                                ))}
                            </List>
                        </Collapse>
                        <ListItemButton 
                            onClick={() => {
                                toggleFloor(f.floorNumber);
                            }}>
                            {'>'}
                        </ListItemButton>
                    </ListItem>
                ))
            }
        </List>
    )
}

export default FloorsComponent;
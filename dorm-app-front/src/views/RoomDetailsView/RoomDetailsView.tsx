import React, { useEffect, useState } from "react";
import Sidebar from "../../components/Sidebar/Sidebar";
import { Room } from "../../models/Floor";
import { GetRoomById, GetRoomByStudentId } from "../../services/RoomsService";
import { GetPersonIdFromStorage, GetRoleFromStorage } from "../../services/UsersService";
import { UserRole } from "../../models/UserRole";

//import "./RoomDetailsView.css";

const RoomDetailsView = () => {
    const [roomDetails, setRoomDetails] = useState<Room>();

    useEffect(() => {
        if(GetRoleFromStorage() === UserRole.Student){
            const studentId: number = GetPersonIdFromStorage();

            GetRoomByStudentId(studentId)
                .then((res) => {
                    setRoomDetails(res.data);
                })
                .catch((err) => {
                    console.log(err);
                });
        } else {
            const roomId: number = parseInt(localStorage.getItem('roomId') ?? '0');
    
            GetRoomById(roomId)
                .then((res) => {
                    setRoomDetails(res.data);
                })
                .catch((err) => {
                    console.log(err);
                });
        }
    }, [setRoomDetails])

    return (
        <div>
            <Sidebar>
                <h1>Mój pokój</h1>
                Room details
                {roomDetails?.id}
                <ul>
                {
                    roomDetails?.items.map((i) => (<li>{i.id} {i.name}</li>))
                }
                </ul>
                <ul>
                {
                    roomDetails?.problems.map((i) => (<li>ticketId:{i.id} description:{i.description} status:{i.status} itemId:{i.item?.id ?? ''} conservatorId:{i.conservator?.id ?? ''}</li>))
                }
                </ul>
                <ul>
                {
                    roomDetails?.students.map((i) => (<li>{i.name}</li>))
                }
                </ul>
            </Sidebar>
        </div>
    )
}

export default RoomDetailsView;
import axios from "axios";
import config from "../config";

export function GetFloors(){
    return axios({
        method: "GET",
        url: `${config.API_URL}/rooms/floors`,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export function GetRoomById(id: number){
    return axios({
        method: "GET",
        url: `${config.API_URL}/rooms/${id}`,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export function GetRoomByStudentId(studentId: number){
    return axios({
        method: "GET",
        url: `${config.API_URL}/rooms/GetRoomByStudentId/${studentId}`,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}
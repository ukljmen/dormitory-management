import axios from "axios";
import config from "../config";
import { DirectMessageDto } from "../models/DirectMessage";

export function GetDirectMessages(){
    return axios({
        method: "GET",
        url: `${config.API_URL}/DirectMessages`,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export function SendDirectMessage(data: any){
    return axios({
        method: "POST",
        url: `${config.API_URL}/DirectMessages`,
        data: data,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export function UpdateDirectMessage(data: any){
    console.log(data);
    return axios({
        method: "PUT",
        url: `${config.API_URL}/DirectMessages`,
        data: data,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export function DeleteDirectMessage(id: number){
    return axios({
        method: "DELETE",
        url: `${config.API_URL}/DirectMessages/${id}`,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}
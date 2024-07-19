import axios from "axios";
import config from "../config";

export function GetNews(){
    return axios({
        method: "GET",
        url: `${config.API_URL}/announcements`,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export function AddNews(data: any){
    return axios({
        method: "POST",
        url: `${config.API_URL}/announcements`,
        data: data,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export function DeleteNews(id: number){
    return axios({
        method: "DELETE",
        url: `${config.API_URL}/announcements?id=${id}`,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export function UpdateNews(data: any){
    return axios({
        method: "PUT",
        url: `${config.API_URL}/announcements`,
        data: data,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}
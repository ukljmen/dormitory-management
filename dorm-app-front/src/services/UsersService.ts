import axios, { AxiosPromise } from "axios";
import config from "../config";
import { UserRole } from "../models/UserRole";

export function Login(data: LoginRequest): AxiosPromise<LoginResponse>{
    return axios({
        method: "POST",
        url: `${config.API_URL}/users/login`,
        data: data
    })
}

export class LoginRequest{
    login: string = "";
    password: string = "";
}

export class LoginResponse{
    token: string = "";
    userName: string = "";
    role: UserRole = UserRole.Student;
    personId: number = 0;
}

export function AddUser(data: AddUserRequest){
    return axios({
        method: "POST",
        url: `${config.API_URL}/users/createUser`,
        data: data,
        headers: {
            "Authorization": `Bearer ${localStorage.getItem('token')}`
        }
    })
}

export class AddUserRequest{
    userName: string = "";
    firstName: string = "";
    lastName: string = "";
    email: string = "";
    phoneNumber: string = "";
    password: string = "";
    role: number = 0;
    indexNumber?: string;
    floorNumber?: number;
    roomNumber?: number;
}

export function GetRoleFromStorage(): UserRole {
    return parseInt(localStorage.getItem('role') ?? '');
}

export function GetPersonIdFromStorage(): number {
    return parseInt(localStorage.getItem('personId') ?? '');
}
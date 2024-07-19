import React, { useCallback, useState } from "react";
import { useNavigate } from "react-router-dom";

import "./AddUserView.css";
import Sidebar from "../../components/Sidebar/Sidebar";
import { MenuItem, Select } from "@mui/material";
import { UserRole, UserRoles } from "../../models/UserRole";
import { AddUser } from "../../services/UsersService";

const AddUserView = () => {
    const [userName, setUserName] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [indexNumber, setIndexNumber] = useState("");
    const [floorNumber, setFloorNumber] = useState("");
    const [roomNumber, setRoomNumber] = useState("");
    const [role, setRole] = useState("");

    let navigate = useNavigate();

    let doAddUser = useCallback(() => {
        AddUser({
            userName: userName,
            firstName: firstName,
            lastName: lastName,
            password: password,
            email: email,
            phoneNumber: phoneNumber,
            role: parseInt(role),
            indexNumber: indexNumber,
            floorNumber: parseInt(floorNumber),
            roomNumber: parseInt(roomNumber)
        })
        .then((res) => {
            console.log(res);
            alert('sukces');
        })
        .catch((err) => {
            console.log(err);
            alert(err?.response?.data ?? err.message);
        });
    }, [userName, firstName, lastName, password, email, phoneNumber, role, indexNumber, floorNumber, roomNumber]);

    return (
        <div>
            <Sidebar>
                <h1>Dodawanie użytkownika</h1>
                <div className="addUserMain">
                    <form className="form">
                        <div className="inputContainer">
                            <input type="text" autoComplete="off" placeholder="Login" onChange={(l) => { setUserName(l.target.value) }}/>
                        </div>
                        <div className="inputContainer">
                            <input type="text" autoComplete="off" placeholder="Imię" onChange={(l) => { setFirstName(l.target.value) }}/>
                        </div>
                        <div className="inputContainer">
                            <input type="text" autoComplete="off" placeholder="Nazwisko" onChange={(l) => { setLastName(l.target.value) }}/>
                        </div>
                        <div className="inputContainer">
                            <input type="text" autoComplete="off" placeholder="NumerTelefonu" onChange={(l) => { setPhoneNumber(l.target.value) }}/>
                        </div>
                        <div className="inputContainer">
                            <input type="email" autoComplete="off" placeholder="Email" onChange={(l) => { setEmail(l.target.value) }}/>
                        </div>
                        <div className="inputContainer">
                            <input type="password" placeholder="Hasło" onChange={(l) => { setPassword(l.target.value) }}/>
                        </div>
                        <div>
                            <Select
                                className="inputContainer"
                                required
                                value={role}
                                onChange={(event) => { setRole(event.target.value) }}
                            >
                                {
                                    Object.keys(UserRoles).map((roleName: string) => {
                                        return (
                                            <MenuItem key={roleName} value={UserRoles[roleName]}>
                                                {roleName}
                                            </MenuItem>
                                        )
                                    })
                                }
                            </Select>
                        </div>
                        {
                            role == '4' &&
                            <div className="inputContainer">
                                <input type="text" autoComplete="off" placeholder="Numer indeksu"  onChange={(l) => { setIndexNumber(l.target.value) }}/>
                            </div>
                        }
                        {
                            role == '4' &&
                            <div className="inputContainer">
                                <input type="text" autoComplete="off" placeholder="Numer piętra" onChange={(l) => { setFloorNumber(l.target.value) }}/>
                            </div>
                        }
                        {
                            role == '4' &&
                            <div className="inputContainer">
                                <input type="text" autoComplete="off" placeholder="Numer pokoju"  onChange={(l) => { setRoomNumber(l.target.value) }}/>
                            </div>
                        }
                        <button
                            onClick={doAddUser}
                            disabled={
                                !userName || !firstName || !lastName || !email || !phoneNumber || !role || !password 
                            }> Dodaj
                        </button>
                    </form>
                </div>
            </Sidebar>
        </div>
    )
}

export default AddUserView;
import React, { useCallback, useEffect, useState } from "react";
import Sidebar from "../../components/Sidebar/Sidebar";

import "./DirectMessagesView.css";
import { DirectMessage } from "../../models/DirectMessage";
import { DeleteDirectMessage, GetDirectMessages } from "../../services/DirectMessagesService";
import { GetRoleFromStorage } from "../../services/UsersService";
import { UserRole } from "../../models/UserRole";
import { Button, IconButton } from "@mui/material";
import DirectMessageComponent from "../../components/DirectMessageComponent.tsx/DirectMessageComponent";
import DeleteIcon from "@mui/icons-material/Delete"
import FloorsComponent from "../../components/FloorsComponent/FloorsComponent";

const DirectMessagesView = () => {

    const [messagesList, setMessagesList] = useState<DirectMessage[]>([]);
    const [editedMessage, setEditedMessage] = useState<DirectMessage | null>(null);
    const isManager = GetRoleFromStorage() <= UserRole.Manager;
    const [isInputDisplayed, setIsInputDisplayed] = useState(false);
    const [isFloorsView, setIsFloorsView] = useState(false);
    
    useEffect(() => {
        GetDirectMessages()
        .then((res) => {
            console.log(res);
            setMessagesList(res.data);
        })
        .catch((err) => {
            console.log(err);
        })
    }, [])

    const doEdit = (message: DirectMessage) : void => {
        setEditedMessage(message);
        setIsInputDisplayed(true);
    }
    
    const doDelete = useCallback((message: DirectMessage) => {
        DeleteDirectMessage(message.id)
            .then((res) => {
                console.log(res);
                setEditedMessage(null);
                setMessagesList(messagesList.filter((m) => m.id !== res.data.id));
            })
            .catch((err) => {
                console.log(err);
            });
    }, [setMessagesList])

    const doCloseEdit = () => {
        setEditedMessage(null);
        setIsInputDisplayed(false);
    }

    return (
        <div>
            <Sidebar>
                <h1>Komunikaty wewnętrzne</h1>
                {
                    isManager &&
                    <Button onClick={() => {setIsFloorsView(!isFloorsView)}}>{isFloorsView ? 'Historia' : 'Wyślij'}</Button>
                }
                {
                    isFloorsView &&
                    <div className="directMessageMain">
                        <FloorsComponent isDirectMessages={true}/>
                    </div>
                }
                {
                    !isFloorsView &&
                    <div className="directMessageMain">
                        {
                            isInputDisplayed && <IconButton onClick={doCloseEdit}><DeleteIcon /></IconButton>
                        }
                        {
                            isInputDisplayed && 
                            <DirectMessageComponent 
                                input={editedMessage}
                                parentReload={() => { console.log('reload'); } }
                                receivers={editedMessage!.receivers} />
                        }
                        <div>
                            <table className="table">
                                <thead>
                                    <tr>
                                    <th>Wiadomość</th>
                                    {   !isManager &&
                                        <th>Nadawca</th>
                                    }
                                    {
                                        isManager &&
                                        <th>Obiorcy</th>
                                    }
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        messagesList.map((message) => (
                                        <tr key={message.id}>
                                            <td>
                                                <div className="title">
                                                    {message.title}:
                                                </div> 
                                                {message.content}
                                            </td>
                                            {   !isManager &&
                                                <td>
                                                    Nadawca: {message.author.name}
                                                </td>
                                            }
                                            {
                                                isManager &&
                                                <td>
                                                    <ul>
                                                        {message.receivers.map((r) => (
                                                            <li key={r.id}>{r.name}</li>
                                                        ))}
                                                    </ul>
                                                </td>
                                            }
                                            {
                                                isManager &&
                                                <td>
                                                    <Button onClick={() => doEdit(message)}>Edytuj</Button>
                                                </td>
                                            }
                                            {
                                                isManager &&
                                                <td>
                                                    <Button onClick={() => doDelete(message)}>Usuń</Button>
                                                </td>
                                            }
                                        </tr>
                                        ))
                                    }
                                </tbody>
                            </table>
                        </div>
                    </div>
                }
                
            </Sidebar>
        </div>
    )
}

export default DirectMessagesView;

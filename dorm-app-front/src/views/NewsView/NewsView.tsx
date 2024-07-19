import { Button, Icon } from "@mui/material";
import MessageComponent from "../../components/MessageComponent/MessageComponent";
import Sidebar from "../../components/Sidebar/Sidebar"
import { UserRole } from "../../models/UserRole";
import { GetRoleFromStorage } from "../../services/UsersService";
import "./NewsView.css"
import { useCallback, useEffect, useState } from "react";
import { Message } from "../../models/Message";
import { DeleteNews, GetNews } from "../../services/NewsService";
import IconButton from "@mui/material/IconButton"
import DeleteIcon from "@mui/icons-material/Delete"

const NewsView = () =>{

    const isManager = GetRoleFromStorage() <= UserRole.Manager;
    const [isInputHidden, setIsInputHidden] = useState(true);
    const [newsList, setNewsList] = useState<Message[]>([]);
    const [editedNews, setEditedNews] = useState<Message | null>(null);

    let rows: Message[] = [];

    useEffect(() => {
        GetNews()
            .then((res) => {
                console.log(res);
                setNewsList(res.data);
            })
            .catch((err) => {
                console.log(err);
            })
    }, [setNewsList]);

    rows = newsList;

    const doEdit = (message: Message) : void => {
        setEditedNews(message);
        setIsInputHidden(false);
    }
    
    const doDelete = (message: Message) : void => {
        DeleteNews(message.id)
            .then((res) => {
                console.log(res);
                setEditedNews(null);
                GetNews()
                    .then((res) => {
                        console.log(res);
                        setNewsList(res.data);
                    })
                    .catch((err) => {
                        console.log(err);
                    });
            })
            .catch((err) => {
                console.log(err);
            });
    }

    const doCloseMessageDialog = () => {
        setEditedNews(null);
        setIsInputHidden(true);
    }

    const reload = () => {
        console.log('reload');
    }

    return(
        <Sidebar>
            <h1>Aktualności</h1>
            {
                isManager && 
                <Button className="button" onClick={() => setIsInputHidden(!isInputHidden)}>
                    Dodaj
                </Button>
            }
            {
                !isInputHidden && <IconButton onClick={doCloseMessageDialog}><DeleteIcon /></IconButton>
            }
            {
                !isInputHidden && <MessageComponent input={editedNews} parentReload={() => reload()}></MessageComponent>
            }
            <div className="newsMain">
                <table className="table">
                    <thead>
                        <tr>
                        <th>Wiadomość</th>
                        </tr>
                    </thead>
                    <tbody>
                        {rows.map((r) => (
                        <tr key={r.id}>
                            <td>
                                <div className="title">{r.title}: </div> 
                                <div className="content">{r.content}</div>
                                <div className="author">Autor: {r.author.name}</div>
                                <div className="addedTs">Dodano: {new Date(r.addedTS).toLocaleDateString("pl-PL")}</div>
                            </td>
                            {
                                isManager &&
                                <td>
                                    <Button onClick={() => doEdit(r)}>Edytuj</Button>
                                </td>
                            }
                            {
                                isManager &&
                                <td>
                                    <Button onClick={() => doDelete(r)}>Usuń</Button>
                                </td>
                            }
                        </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </Sidebar>  
    )
}

export default NewsView;
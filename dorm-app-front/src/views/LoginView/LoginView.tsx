import { Login, LoginResponse } from "../../services/UsersService";
import { useNavigate } from "react-router-dom";

import "./LoginView.css";
import { useCallback, useState } from "react";
import { Snackbar } from "@mui/material";

const LoginView = () => {

    let navigate = useNavigate();

    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [isSnack, setIsSnack] = useState(false);
    const [snackMessage, setSnackMessage] = useState("Logowanie zakończone sukcesem");

    const doLogin = useCallback(() => {
        Login({
            login: login,
            password: password
        })
        .then((res) => {
            console.log(res);
            setIsSnack(true);
            localStorage.setItem('token', res.data.token);
            localStorage.setItem('role', res.data.role.toString());
            localStorage.setItem('userName', res.data.userName);
            localStorage.setItem('personId', res.data.personId.toString());
            navigate('/news');
        })
        .catch((err) => {
            console.log(err);
            setSnackMessage("Błędny login lub hasło!");
            setIsSnack(true);
        });
    }, [login, password]);

    return (
        <div className="loginMain">
            <div className="form">
                <h1>Logowanie</h1>
                <div className="inputContainer">
                    <input 
                        type="text"
                        autoComplete="off"
                        placeholder="Login"
                        onChange={(l) => {setLogin(l.target.value)}}/>
                </div>
                <div className="inputContainer">
                    <input
                        type="password"
                        placeholder="Hasło"
                        onChange={(l) => {setPassword(l.target.value)}}/>
                </div>
                <button onClick={doLogin}>Zaloguj</button>
            </div>
            <Snackbar
                anchorOrigin={{vertical: 'bottom', horizontal: 'center'}}
                open={isSnack}
                message={snackMessage}
                autoHideDuration={3000}
                onClose={() => {setIsSnack(false)}}/>
        </div>
    )
}

export default LoginView;
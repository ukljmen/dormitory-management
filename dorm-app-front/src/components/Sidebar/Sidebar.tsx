import { useState, ReactNode, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "./Sidebar.css";
import { UserRole } from "../../models/UserRole";
import { Props } from "../../models/Props";
import { GetRoleFromStorage } from "../../services/UsersService";

const Sidebar = ({children}: Props) => {
    let navigate = useNavigate();

    function Items({role}: {role: UserRole}){
        switch (role){
            case UserRole.Admin:
            case UserRole.Manager:
                return (
                    <ul>
                        <li onClick={() => navigate("/news")}>Aktualności</li>
                        <li onClick={() => navigate("/messages")}>Komunikaty wewnętrzne</li>
                        <li onClick={() => navigate("/rooms")}>Zarządzanie pokojami</li>
                        <li onClick={() => navigate("/users")}>Dodaj użytkowników</li>
                    </ul>
                )
            case UserRole.Conservator:
                return (
                    <ul>
                        <li onClick={() => navigate("/news")}>Aktualności</li>
                        <li onClick={() => navigate("/reports")}>Moje zgłoszenia</li>
                    </ul>
                )
            case UserRole.Student:
                return (
                    <ul>
                        <li onClick={() => navigate("/news")}>Aktualności</li>
                        <li onClick={() => navigate("/messages")}>Komunikaty wewnętrzne</li>
                        <li onClick={() => navigate("/reports")}>Moje zgłoszenia</li>
                        <li onClick={() => navigate("/roomDetails")}>Mój pokój</li>
                    </ul>
                )
        }
        return <li onClick={() => navigate("/news")}>Aktualności</li>
    }

    const [isHidden, setHidden] = useState(true);

    const [userName, setUserName] = useState("");
    const [role, setRole] = useState(UserRole.Student);

    const doLogout = () => {
        localStorage.removeItem('token');
        localStorage.removeItem('role');
        localStorage.removeItem('userName');
        localStorage.removeItem('personId');
        navigate("/")
    }

    useEffect(() => {
        const userRole = GetRoleFromStorage();
        if(Number.isNaN(userRole)){
            navigate("/");
        }
        setUserName(localStorage.getItem('userName') ?? '');
        setRole(userRole);
    }, []);

    return(
        <div className="SBcontainer">
            <div className={isHidden ? "SidebarHidden" : "Sidebar"}>
                <nav>
                    <table>
                        <thead>
                            <tr>
                                <th className="thleft">Nazwa użytkownika:</th>
                                <th className="thright">{userName}</th>
                            </tr>
                            <tr>
                                <th className="thleft">Rola:</th>
                                <th className="thright">{UserRole[role]}</th>
                            </tr>
                        </thead>
                    </table>
                    <Items role={role}/>
                    <button onClick={doLogout}>Wyloguj</button>
                </nav>
            </div>
            <div className={isHidden ? "SBoverlayFull" : "SBoverlay"}>
                <button onClick={() => setHidden(prevHidden => !prevHidden)} className="hideButton">{isHidden ? "➡️" : "↩️"}</button>
            </div>
            <div className={isHidden ? "SBmainFull" : "SBmain"}>
                {children}
            </div>
            
        </div>
    )
}

export default Sidebar;
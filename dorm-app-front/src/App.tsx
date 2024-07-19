import React from 'react';
import './App.css';
import LoginView from './views/LoginView/LoginView'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import NewsView from './views/NewsView/NewsView';
import AddUserView from './views/AddUserView/AddUserView';
import ManageRoomsView from './views/ManageRoomsView/ManageRoomsView';
import DirectMessagesView from './views/DirectMessagesView/DirectMessagesView';
import RoomDetailsView from './views/RoomDetailsView/RoomDetailsView';
import ReportsView from './views/ReportsView/ReportsView';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<LoginView/>}/>
          <Route path='/news' element={ <NewsView/>}/>
          <Route path='/rooms' element={ <ManageRoomsView/>}/>
          <Route path='/users' element={ <AddUserView/>}/>
          <Route path='/messages' element={ <DirectMessagesView />}/>
          <Route path='/roomDetails' element={ <RoomDetailsView /> }/>
          <Route path='/reports' element={ <ReportsView/> }/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;

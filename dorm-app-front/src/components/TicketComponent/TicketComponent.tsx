import React from 'react';
import {useState} from 'react';

interface TicketListProps {
  tickets: Ticket[];
}

interface Ticket {
  ticket_id: string;
  t_object: string;
  t_state: string;
  t_date: Date;
}

const TicketList: React.FC<TicketListProps> = ({ tickets }) => {
  const [selectedRow, setSelectedRow] = useState<number | null>(null);

  const handleRowSelect = (index: number) => {
    setSelectedRow(index);
  };

  function AssignTicket() {
    console.log("przydziel zgłoszenie");
  }

  function CloseTicket() {
    console.log("zakoncz zgloszenie");
  }

  if (tickets.length === 0) {
    return (
      <>
        <h1>Zgłoszenia w pokoju:</h1>
        <p>Brak zgłoszeń</p>
      </>
    );
  } else {
    return (
      <>
        <h1>Zgłoszenia w pokoju:</h1>
        <table>
          <thead>
            <tr>
              <th>Wyposażenie pokoju</th>
              <th>Stan przedmiotu</th>
              <th>Data zgłoszenia</th>
              <th>Check</th>
            </tr>
          </thead>
          <tbody>
            {tickets.map((ticket, index) => (
              <tr key={index}>
                <td>{ticket.t_object}</td>
                <td>{ticket.t_state}</td>
                <td>{ticket.t_date.toString()}</td>
                <td>
                  <input
                    type="checkbox"
                    checked={selectedRow === index}
                    onChange={() => handleRowSelect(index)}
                  />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        {tickets}
        <div>

          <button onClick={AssignTicket}>Przydziel zgłoszenie</button>
          <button onClick={CloseTicket}>Zamknij zgłoszenie</button>
        </div>
      </>
    );
  }
};
export default TicketList;